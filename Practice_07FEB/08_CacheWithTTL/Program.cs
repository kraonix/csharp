class Program
{
    static void Main()
    {
        var cache = new AdvancedCache<string, string>(2);

        cache.Set("A", "Apple", 5);
        cache.Set("B", "Banana", 5);

        Console.WriteLine(cache.Get("A")); // Apple

        cache.Set("C", "Cherry", 5); // Evicts B (LRU)

        Console.WriteLine(cache.Get("B")); // null (evicted)

        Console.WriteLine("Waiting for TTL expiry...");
        System.Threading.Thread.Sleep(6000);

        Console.WriteLine(cache.Get("A")); // null (expired)
    }
}
