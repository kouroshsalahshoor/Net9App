using Application.Repository.IRepository;
using Core.BethanysPieShopHR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BethanysPieShopHRM;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _repository;

    public EmployeeController(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        return Ok(await _repository.Get());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        return Ok(await _repository.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
            return BadRequest();

        if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
        {
            ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdEmployee = await _repository.Add(employee);

        return Created("employee", createdEmployee);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
            return BadRequest();

        if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
        {
            ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var employeeToUpdate = await _repository.Get(employee.Id);

        if (employeeToUpdate == null)
            return NotFound();

        await _repository.Update(employee);

        return NoContent(); //success
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        if (id == 0)
            return BadRequest();

        var employeeToDelete = await _repository.Get(id);
        if (employeeToDelete == null)
            return NotFound();

        await _repository.Delete(id);

        return NoContent();//success
    }
}
