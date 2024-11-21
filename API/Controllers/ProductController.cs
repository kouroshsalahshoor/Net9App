using Application.Repository;
using Domain.Dtos.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productRepository.Get());
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

            var dto = await _productRepository.Get(id.Value);
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
