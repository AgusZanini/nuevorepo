using System.Net.Http.Json;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Post>> GetMyModelsAsync()
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/");
        response.EnsureSuccessStatusCode();

        var myModels = await response.Content.ReadFromJsonAsync<IEnumerable<Post>>();
        return myModels;
    }
}
