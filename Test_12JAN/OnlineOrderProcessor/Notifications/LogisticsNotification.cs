using Logic;
using Models;
namespace Notifications
{
    public class LogisticsNotification
    {
        public void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            if (newStatus == OrderStatus.Shipped)
            {
                Console.WriteLine($"Logistics: Dispatch started for Order {order.Id}");
            }
        }
    }

}