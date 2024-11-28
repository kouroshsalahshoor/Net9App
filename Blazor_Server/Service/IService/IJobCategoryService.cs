using Core.BethanysPieShopHR;

namespace Blazor_Server.Service.IService;

public interface IJobCategoryService
{
    Task<IEnumerable<JobCategory>> Get();
    Task<JobCategory> Get(int id);
}
