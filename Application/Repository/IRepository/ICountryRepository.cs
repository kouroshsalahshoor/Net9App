using Domain.BethanysPieShopHR;

namespace Application.Repository.IRepository;

public interface ICountryRepository
{
    IEnumerable<Country> Get();
    Country? Get(int id);
}
