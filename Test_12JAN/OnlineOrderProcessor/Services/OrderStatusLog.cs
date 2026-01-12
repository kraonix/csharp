using Models;

namespace Services
{
    public class OrderStatusLog
    {
        public OrderStatus OldStatus { get; }
        public OrderStatus NewStatus { get; }
        public DateTime TimeStamp { get; }

        public OrderStatusLog(OrderStatus oldStatus, OrderStatus newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
            TimeStamp = DateTime.Now;
        }
    }
}