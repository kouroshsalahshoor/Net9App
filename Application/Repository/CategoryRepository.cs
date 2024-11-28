using AutoMapper;
using Core;
using Core.Dtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;

        //https://docs.automapper.org/en/stable/Getting-started.html
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDto>().ReverseMap());
        _mapper = config.CreateMapper();
    }
    public async Task<CategoryDto> Create(CategoryDto dto)
    {
        Category model = _mapper.Map<Category>(dto);

        model.CreatedBy = "";
        model.CreatedOn = DateTime.Now;

        await _db.Categories.AddAsync(model);
        await _db.SaveChangesAsync();

        return _mapper.Map<CategoryDto>(model);
    }

    public async Task<int> Delete(int id)
    {
        var model = await _db.Categories.FirstOrDefaultAsync(x=> x.Id == id);
        if (model is not null)
        {
            _db.Categories.Remove(model);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<CategoryDto?> Get(int id)
    {
        var model = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (model is not null)
        {
            return _mapper.Map<CategoryDto>(model);
        }
        return null;
    }

    public async Task<CategoryDto>? GetByName(string name)
    {
        if (string.IsNullOrEmpty(name) == false)
        {
            var model = await _db.Categories.FirstOrDefaultAsync(x => x.Name == name);
            if (model is not null)
            {
                return _mapper.Map<CategoryDto>(model);
            }
        }
        return null!;
    }

    public async Task<IEnumerable<CategoryDto>> Get()
    {
        return _mapper.Map<IEnumerable<CategoryDto>>(_db.Categories);
    }

    public async Task<CategoryDto> Update(CategoryDto dto)
    {
        var model = await _db.Categories.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (model is not null)
        {
            model.Name = dto.Name;

            model.LastModifiedBy = "";
            model.LastModifiedOn = DateTime.Now;

            _db.Categories.Update(model);
            await _db.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(model);
        }
        return new CategoryDto();
    }
}
