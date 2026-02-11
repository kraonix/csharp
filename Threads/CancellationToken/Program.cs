using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(1600);                                          // auto-cancel after 1.2 seconds

        try
        {
            await LongOperationAsync(cts.Token);
            Console.WriteLine("Completed");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Cancelled");
        }
    }

    static async Task LongOperationAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine("Step " + i);
            await Task.Delay(300, token);                               // delay that can be cancelled
        }
    }
}