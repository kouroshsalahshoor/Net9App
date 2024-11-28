using Core.Dtos;

namespace Application.Repository;

public interface IProductRepository
{
    Task<ProductDto> Create(ProductDto dto);
    Task<ProductDto> Update(ProductDto dto);
    Task<int> Delete(int id);
    Task<ProductDto?> Get(int id);
    Task<IEnumerable<ProductDto>> Get();
}
