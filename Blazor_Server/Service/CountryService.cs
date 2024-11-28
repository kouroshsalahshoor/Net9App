using Blazor_Server.Service.IService;
using Core.BethanysPieShopHR;
using System.Text.Json;

namespace Blazor_Server.Service;

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Country>> Get()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
            (await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Country> Get(int id)
    {
        return await JsonSerializer.DeserializeAsync<Country>
            (await _httpClient.GetStreamAsync($"api/country{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}