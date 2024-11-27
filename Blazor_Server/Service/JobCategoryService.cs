using Blazor_Server.Service.IService;
using Domain.BethanysPieShopHR;
using System.Text.Json;

namespace Blazor_Server.Service;

public class JobCategoryService : IJobCategoryService
{
    private readonly HttpClient _httpClient;

    public JobCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<JobCategory>> Get()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
            (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<JobCategory> Get(int jobCategoryId)
    {
        return await JsonSerializer.DeserializeAsync<JobCategory>
            (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}
