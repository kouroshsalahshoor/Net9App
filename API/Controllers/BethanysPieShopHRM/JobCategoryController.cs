using Application.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BethanysPieShopHRM;

[Route("api/[controller]")]
[ApiController]
public class JobCategoryController : Controller
{
    private readonly IJobCategoryRepository _repository;

    public JobCategoryController(IJobCategoryRepository repository)
    {
        _repository = repository;
    }


    // GET: api/<controller>
    [HttpGet]
    public async Task<IActionResult> GetJobCategories()
    {
        return Ok(await _repository.Get());
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobCategoryById(int id)
    {
        return Ok(await _repository.Get(id));
    }
}
