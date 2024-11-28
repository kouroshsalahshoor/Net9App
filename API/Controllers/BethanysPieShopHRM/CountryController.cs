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
    public async Task<IActionResult> GetCountries()
    {
        return Ok(await _repository.Get());
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountryById(int id)
    {
        return Ok(await _repository.Get(id));
    }
}
