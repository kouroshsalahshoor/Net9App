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
    public IActionResult GetAllEmployees()
    {
        return Ok(_repository.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        return Ok(_repository.Get(id));
    }

    [HttpPost]
    public IActionResult CreateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
            return BadRequest();

        if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
        {
            ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdEmployee = _repository.Add(employee);

        return Created("employee", createdEmployee);
    }

    [HttpPut]
    public IActionResult UpdateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
            return BadRequest();

        if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
        {
            ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var employeeToUpdate = _repository.Get(employee.Id);

        if (employeeToUpdate == null)
            return NotFound();

        _repository.Update(employee);

        return NoContent(); //success
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        if (id == 0)
            return BadRequest();

        var employeeToDelete = _repository.Get(id);
        if (employeeToDelete == null)
            return NotFound();

        _repository.Delete(id);

        return NoContent();//success
    }
}
