using Domain.Dtos;

namespace Blazor_Wasm.Service.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>?> Get();
        Task<CategoryDto?> Get(int id);
    }
}
