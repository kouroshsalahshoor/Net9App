using Application.Repository;
using Core;
using Core.Dtos.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =Constants.Role_Admin)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryRepository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id <= 0 || id is null)
            {
                return BadRequest(new ResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid Id"
                });
            }

            var dto = await _categoryRepository.Get(id.Value);
            if (dto == null)
            {
                return BadRequest(new ResponseDto
                {
                    IsSuccessful = false,
                    Message = "Not Found"
                });
            }

            return Ok(dto);
        }
    }
}
