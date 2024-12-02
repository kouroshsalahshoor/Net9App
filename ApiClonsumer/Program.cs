//without cors on api works!!!
using Newtonsoft.Json;

using HttpClient client = new HttpClient();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

try
{
    // Send an HTTP GET request
    HttpResponseMessage response = await client.GetAsync("https://localhost:7135/genres");
    response.EnsureSuccessStatusCode();

    // Read and display the response body
    string responseBody = await response.Content.ReadAsStringAsync();
    var models = JsonConvert.DeserializeObject<List<Genre>>(responseBody);
    //var models = JsonSerializer.Deserialize<List<Genre>>(responseBody); //???

    foreach (var model in models!)
    {
        Console.WriteLine($"Id: {model.Id}, Name: {model.Name}");
    }
}
catch (HttpRequestException e)
{
    Console.WriteLine($"Request error: {e.Message}");
}

internal class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
