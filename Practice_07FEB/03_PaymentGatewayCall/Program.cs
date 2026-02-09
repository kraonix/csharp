class Program
{
    static async Task Main()
    {
        var gateway = new PaymentGateway();
        var cts = new CancellationTokenSource();

        Console.WriteLine("Starting payment simulation...\n");

        for (int i = 1; i <= 10; i++)
        {
            try
            {
                var request = new PaymentRequest { Amount = 100 };

                var result = await gateway.ProcessPaymentAsync(request, cts.Token);

                Console.WriteLine($"Attempt {i}: {result.Message}");

                await Task.Delay(1000);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was cancelled.");
                break;
            }
        }

        Console.WriteLine("\nWaiting 35 seconds for circuit reset...");
        await Task.Delay(35000);

        Console.WriteLine("\nTrying again after cooldown...");

        var finalResult = await gateway.ProcessPaymentAsync(
            new PaymentRequest { Amount = 200 },
            cts.Token);

        Console.WriteLine($"Final Attempt: {finalResult.Message}");
    }
}