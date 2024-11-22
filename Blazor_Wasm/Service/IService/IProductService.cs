using Domain.Dtos;

namespace Blazor_Wasm.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>?> Get();
        Task<ProductDto?> Get(int id);
    }
}
