public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<FoodItem> Items { get; set; } = new();
    public DateTime OrderTime { get; set; }
    public string Status { get; set; }
    public double TotalAmount { get; set; }
}
