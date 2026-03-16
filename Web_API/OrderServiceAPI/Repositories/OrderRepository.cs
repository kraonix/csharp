using OrderServiceAPI.Models;

namespace OrderServiceAPI.Repositories;

public class OrderRepository : IOrderRepository
{
    private static List<Order> orders = new List<Order>()
    {
        new Order
        {
            Id = 1,
            UserId = 1,
            TotalAmount = 60000,
            Status = "Placed",
            OrderDate = DateTime.Now
        },
        new Order
        {
            Id = 2,
            UserId = 2,
            TotalAmount = 30000,
            Status = "Shipped",
            OrderDate = DateTime.Now
        }
    };

    public List<Order> GetAll()
    {
        return orders;
    }

    public Order GetById(int id)
    {
        return orders.FirstOrDefault(o => o.Id == id);
    }

    public List<Order> GetByUser(int userId)
    {
        return orders.Where(o => o.UserId == userId).ToList();
    }

    public void Add(Order order)
    {
        order.Id = orders.Max(o => o.Id) + 1;
        order.OrderDate = DateTime.Now;
        order.Status = "Placed";

        orders.Add(order);
    }

    public void Update(Order order)
    {
        var existingOrder = orders.FirstOrDefault(o => o.Id == order.Id);
        if (existingOrder != null)
        {
            existingOrder.UserId = order.UserId;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.Status = order.Status;
        }
    }

    public void Delete(int id)
    {
        var order = orders.FirstOrDefault(o => o.Id == id);

        if (order != null)
        {
            orders.Remove(order);
        }
    }
}