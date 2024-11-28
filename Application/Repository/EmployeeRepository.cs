using Application.Repository.IRepository;
using Core.BethanysPieShopHR;
using Infrastructure.Data;

namespace Application.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _db;

    public EmployeeRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Employee> Get()
    {
        return _db.Employees;
    }

    public Employee? Get(int id)
    {
        return _db.Employees.FirstOrDefault(c => c.Id == id);
    }

    public Employee Add(Employee model)
    {
        var addedEntity = _db.Employees.Add(model);
        _db.SaveChanges();
        return addedEntity.Entity;
    }

    public Employee? Update(Employee model)
    {
        var foundModel = _db.Employees.FirstOrDefault(e => e.Id == model.Id);

        if (foundModel != null)
        {
            foundModel.CountryId = model.CountryId;
            foundModel.MaritalStatus = model.MaritalStatus;
            foundModel.BirthDate = model.BirthDate;
            foundModel.City = model.City;
            foundModel.Email = model.Email;
            foundModel.FirstName = model.FirstName;
            foundModel.LastName = model.LastName;
            foundModel.Gender = model.Gender;
            foundModel.PhoneNumber = model.PhoneNumber;
            foundModel.Smoker = model.Smoker;
            foundModel.Street = model.Street;
            foundModel.Zip = model.Zip;
            foundModel.JobCategoryId = model.JobCategoryId;
            foundModel.Comment = model.Comment;
            foundModel.ExitDate = model.ExitDate;
            foundModel.JoinedDate = model.JoinedDate;

            _db.SaveChanges();

            return foundModel;
        }

        return null;
    }

    public void Delete(int id)
    {
        var foundEmployee = _db.Employees.FirstOrDefault(e => e.Id == id);
        if (foundEmployee == null) return;

        _db.Employees.Remove(foundEmployee);
        _db.SaveChanges();
    }
}
