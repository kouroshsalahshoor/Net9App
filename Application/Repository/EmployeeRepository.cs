using Application.Repository.IRepository;
using Core.BethanysPieShopHR;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _db;

    public EmployeeRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Employee>> Get()
    {
        return await _db.Employees.ToListAsync();
    }

    public async Task<Employee?> Get(int id)
    {
        return await _db.Employees.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Employee> Add(Employee model)
    {
        model.CreatedBy = "";
        model.CreatedOn = DateTime.Now;

        var addedEntity = await _db.Employees.AddAsync(model);
        await _db.SaveChangesAsync();
        return addedEntity.Entity;
    }

    public async Task<Employee?> Update(Employee model)
    {
        var foundModel = await _db.Employees.FirstOrDefaultAsync(e => e.Id == model.Id);

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

            foundModel.LastModifiedBy = "";
            foundModel.LastModifiedOn = DateTime.Now;

            await _db.SaveChangesAsync();

            return foundModel;
        }

        return null;
    }

    public async Task Delete(int id)
    {
        var foundEmployee = await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
        if (foundEmployee == null) return;

        _db.Employees.Remove(foundEmployee);
        await _db.SaveChangesAsync();
    }
}
