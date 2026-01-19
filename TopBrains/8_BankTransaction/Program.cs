/// <summary>
/// Class representing a bank transaction with nullable integer properties.
/// </summary>
class BankTransaction
{
    // Properties
    public int? IntialBalance { get; set; }
    public int? FinalBalance { get; set; }
    public int? Transaction { get; set; }

    // Constructor
    public BankTransaction(int? intialBalance, int? transaction)
    {
        IntialBalance = intialBalance;
        Transaction = transaction;
    }

    // Method to process the transaction
    public void ProcessTransaction()
    {
        // Check for null values
        if (Transaction > 0)
        {
            FinalBalance = IntialBalance + Transaction;
        }
        // Withdrawal scenario
        else if (Transaction < 0)
        {
            if (Math.Abs(Transaction.Value) > IntialBalance)
            {
                throw new InvalidOperationException("Insufficient funds for the transaction.");
            }
            else
            {
                FinalBalance = IntialBalance - Math.Abs(Transaction.Value);
            }
        }
        // No transaction scenario
        else
        {
            FinalBalance = IntialBalance;
        }
    }
}

class Program
{
    // Main method
    static void Main(string[] args)
    {
        try
        {
            // Example usage
            Console.Write("Enter initial balance: ");
            int initialBalance = int.Parse(Console.ReadLine());
            Console.Write("Enter transaction amount (positive for deposit, negative for withdrawal): ");
            int transactionAmount = int.Parse(Console.ReadLine());
            BankTransaction transaction1 = new BankTransaction(initialBalance, transactionAmount);

            transaction1.ProcessTransaction();
            Console.WriteLine($"Final Balance after deposit: {transaction1.FinalBalance}");

        }
        // Handle insufficient funds scenario
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}