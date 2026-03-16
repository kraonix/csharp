using Newtonsoft.Json;
using System.Text;

namespace ECommerceMVC.Services;

public class ApiService
{
    private readonly HttpClient _client;

    public ApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<T>> GetAsync<T>(string url)
    {
        var response = await _client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<T>>(data) ?? new List<T>();
    }

    public async Task<T?> GetSingleAsync<T>(string url)
    {
        var response = await _client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(data);
    }

    public async Task PostAsync<T>(string url, T item)
    {
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task PutAsync<T>(string url, T item)
    {
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string url)
    {
        var response = await _client.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }
}