using API.Utilities;
using Core;
using Core.Dtos.API;
using Core.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.Account
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApiSettings _apiSettings;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> Logger,
            RoleManager<IdentityRole> roleManager,
            IOptions<ApiSettings> options
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = Logger;
            _roleManager = roleManager;
            _apiSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded == false)
            {
                return BadRequest(new ResponseDto()
                {
                    IsSuccessful = false,
                    Errors = result.Errors.Select(x => x.Description).ToList(),
                });
            }

            result = await _userManager.AddToRoleAsync(user, dto.Role);
            if (result.Succeeded == false)
            {
                return BadRequest(new ResponseDto()
                {
                    IsSuccessful = false,
                    Errors = result.Errors.Select(x => x.Description).ToList(),
                });
            }

            return StatusCode(StatusCodes.Status201Created);
            //return Ok(new ResponseDto { IsSuccessful = true });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                return Unauthorized(new ResponseDto()
                {
                    IsSuccessful = false,
                    Message = "Invalid Authentication"
                });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (result.Succeeded == false)
            {
                return Unauthorized(new ResponseDto()
                {
                    IsSuccessful = false,
                    Message = "Invalid Authentication"
                });
            }

            var signInCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);

            var tokenOptions = new JwtSecurityToken(
                issuer: _apiSettings.ValidIssuer,
                audience: _apiSettings.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signInCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new ResponseDto
            {
                IsSuccessful = true,
                Token = token,
                UserDto = new ApplicationUserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    FirstName = user.FirstName!,
                    LastName = user.LastName!,
                    Roles = claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
                }
            });
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiSettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Id", user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);
            //var roles = await _userManager.GetRolesAsync(await _userManager.FindByNameAsync(user.UserName));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
