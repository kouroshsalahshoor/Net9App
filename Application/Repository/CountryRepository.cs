using Application.Repository.IRepository;
using Domain.BethanysPieShopHR;
using Infrastructure.Data;

namespace Application.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _db;

    public CountryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Country> Get()
    {
        return _db.Countries;
    }

    public Country? Get(int id)
    {
        return _db.Countries.FirstOrDefault(c => c.Id == id);
    }
}
