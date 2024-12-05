using Core;
using Core.Dtos.API;
using Core.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> Logger,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = Logger;
            _roleManager = roleManager;
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
                    Errors = result.Errors.Select(x=>x.Description),
                });
            }

            result = await _userManager.AddToRoleAsync(user, dto.Role);
            if (result.Succeeded == false)
            {
                return BadRequest(new ResponseDto()
                {
                    IsSuccessful = false,
                    Errors = result.Errors.Select(x => x.Description),
                });
            }

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
