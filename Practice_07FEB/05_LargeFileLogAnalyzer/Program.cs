class Program
{
    static void Main()
    {
        var analyzer = new LogAnalyzer();

        var topErrors = analyzer.GetTopErrors("large_log.txt", 3);

        foreach (var error in topErrors)
        {
            Console.WriteLine($"{error.ErrorCode} - {error.Count}");
        }
    }
}
