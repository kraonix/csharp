public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public readonly object LockObj = new object();
}

public class TransferResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
}
