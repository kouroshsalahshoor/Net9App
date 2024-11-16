using Shared.Dtos;

namespace Application.Repository;

public interface ICatalogRepository
{
    Task<CategoryDto> Create(CategoryDto dto);
    Task<CategoryDto> Update(CategoryDto dto);
    Task<int> Delete(int id);
    Task<CategoryDto> Get(int id);
    Task<IEnumerable<CategoryDto>> Get();
}
