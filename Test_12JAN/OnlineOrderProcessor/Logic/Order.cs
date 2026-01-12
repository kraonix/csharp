using Models;
using Services;

namespace Logic
{
    public delegate void OrderStatusChangedHandler(Order order, OrderStatus oldStatus, OrderStatus newStatus);

    public class Order
    {
        public int Id { get; }
        public Customer Customer { get; }
        public OrderStatus CurrentStatus { get; private set; }

        private readonly List<OrderItem> _items = new();
        private readonly List<OrderStatusLog> _history = new();

        public IReadOnlyList<OrderItem> Items => _items;
        public IReadOnlyList<OrderStatusLog> History => _history;

        public OrderStatusChangedHandler? StatusChanged;

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
            CurrentStatus = OrderStatus.Created;
        }

        public void AddItem(Product product, int qty)
        {
            _items.Add(new OrderItem(product, qty));
        }

        public decimal CalculateTotal()
        {
            decimal subtotal = _items.Sum(i => i.Total);
            decimal tax = subtotal * 0.18m;
            return subtotal + tax;
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            if (!IsValidTransition(CurrentStatus, newStatus))
            {
                Console.WriteLine($"Invalid transition: {CurrentStatus} → {newStatus} for Order {Id}");
                Console.ResetColor();
                return;
            }

            var oldStatus = CurrentStatus;
            CurrentStatus = newStatus;

            _history.Add(new OrderStatusLog(oldStatus, newStatus));

            StatusChanged?.Invoke(this, oldStatus, newStatus);
        }

        private bool IsValidTransition(OrderStatus from, OrderStatus to)
        {
            if (from == OrderStatus.Cancelled) return false;

            return from switch
            {
                OrderStatus.Created => to == OrderStatus.Paid || to == OrderStatus.Cancelled,
                OrderStatus.Paid => to == OrderStatus.Packed,
                OrderStatus.Packed => to == OrderStatus.Shipped,
                OrderStatus.Shipped => to == OrderStatus.Delivered,
                _ => false
            };
        }
    }
}