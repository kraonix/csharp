class Program
{
    static void Main()
    {
        RateLimiter limiter = new RateLimiter();
        string clientId = "Client1";

        Console.WriteLine("Sending 6 requests immediately:");

        for (int i = 1; i <= 6; i++)
        {
            bool allowed = limiter.AllowRequest(clientId, DateTime.UtcNow);
            Console.WriteLine($"Request {i}: {allowed}");
            Thread.Sleep(1000); // 1 second apart
        }

        Console.WriteLine("\nWaiting 5 seconds...");
        Thread.Sleep(5000);

        Console.WriteLine("\nSending another request:");
        bool result = limiter.AllowRequest(clientId, DateTime.UtcNow);
        Console.WriteLine($"New Request Allowed: {result}");
    }
}