using Core.BethanysPieShopHR;

namespace Application.Repository.IRepository;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> Get();
    Task<Employee?> Get(int id);
    Task<Employee> Add(Employee model);
    Task<Employee?> Update(Employee model);
    Task Delete(int id);
}
