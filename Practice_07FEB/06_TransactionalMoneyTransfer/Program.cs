class Program
{
    static void Main()
    {
        var bank = new BankService();

        try
        {
            var result = bank.Transfer("A1", "A2", 200);
            Console.WriteLine(result.Message);
        }
        catch (DomainException ex)
        {
            Console.WriteLine($"Domain Error: {ex.Message}");
        }

        bank.PrintBalances();
        bank.PrintAuditLog();
    }
}
