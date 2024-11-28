using Core.BethanysPieShopHR;

namespace Blazor_Server.Service.IService;

public interface ICountryService
{
    Task<IEnumerable<Country>> Get();
    Task<Country> Get(int countryId);
}
