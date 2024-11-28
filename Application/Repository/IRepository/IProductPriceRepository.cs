using Core.Dtos;

namespace Application.Repository;

public interface IProductPriceRepository
{
    Task<ProductPriceDto> Create(ProductPriceDto dto);
    Task<ProductPriceDto> Update(ProductPriceDto dto);
    Task<int> Delete(int id);
    Task<ProductPriceDto?> Get(int id);
    Task<IEnumerable<ProductPriceDto>> Get();
    Task<IEnumerable<ProductPriceDto>> GetForProductId(int productId);
}
