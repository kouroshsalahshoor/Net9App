using Domain.BethanysPieShopHR;

namespace Application.Repository.IRepository;

public interface IJobCategoryRepository
{
    IEnumerable<JobCategory> Get();
    JobCategory Get(int id);
}
