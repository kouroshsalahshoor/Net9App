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
    public IActionResult GetJobCategories()
    {
        return Ok(_repository.Get());
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public IActionResult GetJobCategoryById(int id)
    {
        return Ok(_repository.Get(id));
    }
}
