using Application.Repository.IRepository;
using Core.BethanysPieShopHR;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _db;

    public CountryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Country>> Get()
    {
        return await _db.Countries.ToListAsync();
    }

    public async Task<Country?> Get(int id)
    {
        return await _db.Countries.FirstOrDefaultAsync(c => c.Id == id);
    }
}
