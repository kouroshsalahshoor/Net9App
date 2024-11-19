using Domain.Dtos;

namespace Application.Repository;

public interface ICategoryRepository
{
    Task<CategoryDto> Create(CategoryDto dto);
    Task<CategoryDto> Update(CategoryDto dto);
    Task<int> Delete(int id);
    Task<CategoryDto> Get(int id);
    Task<CategoryDto>? GetByName(string name);
    Task<IEnumerable<CategoryDto>> Get();
}
