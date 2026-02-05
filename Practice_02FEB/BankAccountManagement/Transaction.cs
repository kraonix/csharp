using System;

public class Transaction
{
    public string TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Type { get; set; }   // Deposit / Withdrawal
    public double Amount { get; set; }
    public string Description { get; set; }
}
