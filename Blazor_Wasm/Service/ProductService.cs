using Blazor_Wasm.Service.IService;
using Domain.Dtos;
using Domain.Dtos.API;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Blazor_Wasm.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDto>?> Get()
        {
            var response = await _httpClient.GetAsync("product");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductDto>>(content);
            }

            return null;
        }

        public async Task<ProductDto?> Get(int id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(content);
            }
            else
            {
                var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);
                throw new Exception(responseDto!.Message);
            }
        }
    }
}
