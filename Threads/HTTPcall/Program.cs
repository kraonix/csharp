using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiClient
{
    private readonly HttpClient _http = new HttpClient();

    public Task<string> GetHomePageHtmlAsync1()
    {
        return _http.GetStringAsync("https://book-bounty-theta.vercel.app/");
    }

    public Task<string> GetHomePageHtmlAsync2()
    {
        return _http.GetStringAsync("https://google.com/");
    }
}

class Program
{
    static async Task Main()
    {
        var client = new ApiClient();

        // Start both tasks without awaiting immediately
        Task<string> task1 = client.GetHomePageHtmlAsync1();
        Task<string> task2 = client.GetHomePageHtmlAsync2();

        // Await both together
        string[] results = await Task.WhenAll(task1, task2);

        Console.WriteLine("Response 1:\n" + results[0] + "\n");
        Console.WriteLine("Response 2:\n" + results[1] + "\n");
    }
}
