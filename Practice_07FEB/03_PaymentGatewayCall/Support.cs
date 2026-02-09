public class PaymentRequest
{
    public decimal Amount { get; set; }
}

public class PaymentResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}
