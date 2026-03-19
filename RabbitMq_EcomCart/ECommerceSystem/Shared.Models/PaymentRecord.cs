namespace Shared.Models;

public class PaymentRecord
{
    public string OrderId { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime ProcessedAt { get; set; }
    public string Status { get; set; } = "Success";
    public List<CartItem> Items { get; set; } = new();
}
