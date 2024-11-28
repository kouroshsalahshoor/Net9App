using Core.BethanysPieShopHR;

namespace Application.Repository.IRepository;

public interface IJobCategoryRepository
{
    Task<IEnumerable<JobCategory>> Get();
    Task<JobCategory> Get(int id);
}
