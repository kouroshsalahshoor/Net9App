using Blazor_Wasm.Service.IService;
using Newtonsoft.Json;

namespace Blazor_Wasm.Service
{
    public class WebPageContentService : IWebPageContentService
    {
        private readonly HttpClient _httpClient;

        public WebPageContentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get()
        {
            var response = await _httpClient.GetAsync("WebPageContent");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                //var result = JsonConvert.DeserializeObject<string>(content)!;
                return result;
            }

            return string.Empty;
        }
    }
}
