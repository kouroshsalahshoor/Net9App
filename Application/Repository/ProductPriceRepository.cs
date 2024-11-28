using AutoMapper;
using Core;
using Core.Dtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ProductPriceRepository : IProductPriceRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductPriceRepository(ApplicationDbContext db)
    {
        _db = db;

        //https://docs.automapper.org/en/stable/Getting-started.html
        var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductPrice, ProductPriceDto>().ReverseMap());
        _mapper = config.CreateMapper();
    }
    public async Task<ProductPriceDto> Create(ProductPriceDto dto)
    {
        ProductPrice model = _mapper.Map<ProductPrice>(dto);

        await _db.ProductPrices.AddAsync(model);
        await _db.SaveChangesAsync();

        return _mapper.Map<ProductPriceDto>(model);
    }

    public async Task<int> Delete(int id)
    {
        var model = await _db.ProductPrices.FirstOrDefaultAsync(x=> x.Id == id);
        if (model is not null)
        {
            _db.ProductPrices.Remove(model);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<ProductPriceDto?> Get(int id)
    {
        var model = await _db.ProductPrices.FirstOrDefaultAsync(x => x.Id == id);
        if (model is not null)
        {
            return _mapper.Map<ProductPriceDto>(model);
        }
        return null;
    }

    public async Task<IEnumerable<ProductPriceDto>> GetForProductId(int productId)
    {
        var models = _db.ProductPrices.Where(x => x.ProductId == productId);
        if (models is not null)
        {
            return _mapper.Map<IEnumerable<ProductPriceDto>>(models);
        }
        return new List<ProductPriceDto>();
    }

    public async Task<IEnumerable<ProductPriceDto>> Get()
    {
        return _mapper.Map<IEnumerable<ProductPriceDto>>(_db.ProductPrices);
    }

    public async Task<ProductPriceDto> Update(ProductPriceDto dto)
    {
        var model = await _db.ProductPrices.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (model is not null)
        {
            model.Price = dto.Price;
            model.Size = dto.Size;
            model.ProductId = dto.ProductId;

            _db.ProductPrices.Update(model);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductPriceDto>(model);
        }
        return new ProductPriceDto();
    }
}
