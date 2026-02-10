// 4) Convert sync to async
// Start with a sync method that waits using Thread.Sleep. Convert it to async using Task.Delay and return Task.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        DoWork();
        Console.WriteLine("Main finished");
    }

    static void DoWork()
    {
        Console.WriteLine("Work started");
        Thread.Sleep(3000);                             // blocks thread for 2 seconds
        Console.WriteLine("Work finished");
        Thread.Sleep(3000);
    }
}
