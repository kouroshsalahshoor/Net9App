using Application.Repository.IRepository;
using Core.BethanysPieShopHR;
using Infrastructure.Data;

namespace Application.Repository;

public class JobCategoryRepository : IJobCategoryRepository
{
    private readonly ApplicationDbContext _db;

    public JobCategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<JobCategory>> Get() => _db.JobCategories;

    public async Task<JobCategory> Get(int id) => _db.JobCategories.FirstOrDefault(c => c.Id == id)!;
}
