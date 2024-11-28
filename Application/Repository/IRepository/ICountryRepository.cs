using Core.BethanysPieShopHR;

namespace Application.Repository.IRepository;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> Get();
    Task<Country?> Get(int id);
}
