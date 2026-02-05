using System.Collections.Generic;

public class Account
{
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public string AccountType { get; set; }   // Savings / Current / Fixed
    public double Balance { get; set; }
    public List<Transaction> TransactionHistory { get; set; } = new();
}
