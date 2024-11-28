using Blazor_Wasm.Service.IService;
using Core.Dtos;
using Core.Dtos.API;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Blazor_Wasm.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseServerUrl;

        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseServerUrl = _configuration.GetSection("BaseServerUrl").Value!;
        }
        public async Task<IEnumerable<ProductDto>?> Get()
        {
            var response = await _httpClient.GetAsync("product");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dtos = JsonConvert.DeserializeObject<List<ProductDto>>(content);
                foreach (var dto in dtos!)
                {
                    dto.ImageUrl = _baseServerUrl + dto.ImageUrl;
                }
                return dtos;
            }

            return null;
        }

        public async Task<ProductDto?> Get(int id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var dto = JsonConvert.DeserializeObject<ProductDto>(content);

                dto.ImageUrl = _baseServerUrl + dto.ImageUrl;

                return dto;
            }
            else
            {
                var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);
                throw new Exception(responseDto!.Message);
            }
        }
    }
}
