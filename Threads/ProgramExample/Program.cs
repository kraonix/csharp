using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting...");

        string data = await GetDataAsync();

        Console.WriteLine("Received: " + data);
        Console.WriteLine("Done.");
    }

    static async Task<string> GetDataAsync()
    {
        // Simulate slow work (like HTTP/DB/file)
        await Task.Delay(1000);
        return "DATA-123";
    }
}