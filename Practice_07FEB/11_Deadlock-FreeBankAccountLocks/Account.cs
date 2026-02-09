public class Account
{
    public string AccountId { get; }
    public decimal Balance { get; set; }

    public readonly object LockObj = new object();

    public Account(string id, decimal balance)
    {
        AccountId = id;
        Balance = balance;
    }
}
