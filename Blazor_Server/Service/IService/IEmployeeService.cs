using Domain.BethanysPieShopHR;

namespace Blazor_Server.Service.IService;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> Get();
    Task<Employee> Get(int id);
    Task<Employee> Add(Employee model);
    Task Update(Employee model);
    Task Delete(int id);
}
