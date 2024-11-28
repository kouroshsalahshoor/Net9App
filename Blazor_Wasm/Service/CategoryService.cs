using Blazor_Wasm.Service.IService;
using Core.Dtos;
using Core.Dtos.API;
using Newtonsoft.Json;

namespace Blazor_Wasm.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CategoryDto>?> Get()
        {
            var response = await _httpClient.GetAsync("category");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CategoryDto>>(content);
            }

            return null;
        }

        public async Task<CategoryDto?> Get(int id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(content);
            }
            else
            {
                var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);
                throw new Exception(responseDto!.Message);
            }
        }
    }
}
