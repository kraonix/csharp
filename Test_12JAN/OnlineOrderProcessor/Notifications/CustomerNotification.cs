using Logic;
using Models;
namespace Notifications
{
    public class CustomerNotification
    {
        public void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            Console.WriteLine($"Customer Alert: Order {order.Id} changed from {oldStatus} → {newStatus}");
        }
    }

}