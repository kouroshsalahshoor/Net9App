using Application.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BethanysPieShopHRM;

[Route("api/[controller]")]
[ApiController]
public class CountryController : Controller
{
    private readonly ICountryRepository _repository;

    public CountryController(ICountryRepository repository)
    {
        _repository = repository;
    }

    // GET: api/<controller>
    [HttpGet]
    public IActionResult GetCountries()
    {
        return Ok(_repository.Get());
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public IActionResult GetCountryById(int id)
    {
        return Ok(_repository.Get(id));
    }
}
