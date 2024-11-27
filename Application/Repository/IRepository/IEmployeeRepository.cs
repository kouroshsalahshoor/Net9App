using Domain.BethanysPieShopHR;

namespace Application.Repository.IRepository;

public interface IEmployeeRepository
{
    IEnumerable<Employee> Get();
    Employee? Get(int id);
    Employee Add(Employee model);
    Employee? Update(Employee model);
    void Delete(int id);
}
