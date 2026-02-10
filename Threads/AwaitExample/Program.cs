using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await Task.Delay(1000);
        Console.WriteLine("A");
        await PrintAfterDelayAsync();
        await Task.Delay(1000);
        Console.WriteLine("C");
    }

    static async Task PrintAfterDelayAsync()
    {
        Console.WriteLine("B1");
        await Task.Delay(5000);
        Console.WriteLine("B2");
    }
}

// Expected output order:
// (pause ~1000ms)
// A
// B1
// (pause ~5000ms)
// B2
//(pause ~1000ms)
// C