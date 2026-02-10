using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await SaveAsync();                          // Task (no return)
        int total = await GetTotalAsync();          // Task<int> (returns value)
        string name = await GetGreetingAsync("Sachin");
        Console.WriteLine(name + " " + total);
    }

    static async Task<string> GetGreetingAsync(string name)
    {
        await Task.Delay(2000);                     // pretend network delay
        return $"Hello, {name}!";
    }
    static async Task SaveAsync()
    {
        await Task.Delay(3000);                     // pretend we saved to DB
        Console.WriteLine("Saved!");
    }

    static async Task<int> GetTotalAsync()
    {
        await Task.Delay(3000);                     // pretend we calculated
        return 42;
    }
}