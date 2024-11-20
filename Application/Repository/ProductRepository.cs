using AutoMapper;
using Domain;
using Domain.Dtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;

        var config = new MapperConfiguration(x =>
        {
            x.CreateMap<Category, CategoryDto>().ReverseMap();
            x.CreateMap<Product, ProductDto>().ReverseMap();
        });
        _mapper = config.CreateMapper();
    }
    public async Task<ProductDto> Create(ProductDto dto)
    {
        dto.Category = null;
        Product model = _mapper.Map<Product>(dto);

        await _db.Products.AddAsync(model);
        await _db.SaveChangesAsync();

        return _mapper.Map<ProductDto>(model);
    }

    public async Task<int> Delete(int id)
    {
        var model = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (model is not null)
        {
            _db.Products.Remove(model);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<ProductDto> Get(int id)
    {
        var model = await _db.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        if (model is not null)
        {
            return _mapper.Map<ProductDto>(model);
        }
        return new ProductDto();
    }

    public async Task<IEnumerable<ProductDto>> Get()
    {
        var models = await _db.Products.Include(x => x.Category).ToListAsync();
        var dtos = _mapper.Map<IEnumerable<ProductDto>>(models);
        return dtos;
    }

    public async Task<ProductDto> Update(ProductDto dto)
    {
        var model = await _db.Products.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (model is not null)
        {
            model.Name = dto.Name;
            model.Description = dto.Description;
            model.ImageUrl = dto.ImageUrl;
            model.CategoryId = dto.CategoryId;

            _db.Products.Update(model);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductDto>(model);
        }
        return new ProductDto();
    }
}
