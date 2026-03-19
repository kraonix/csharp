namespace Shared.Models;

public class PaymentMessage
{
    public string OrderId { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public List<CartItem> Items { get; set; } = new();
}
