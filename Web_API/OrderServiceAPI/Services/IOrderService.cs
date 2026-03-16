using OrderServiceAPI.Models;

namespace OrderServiceAPI.Services;

public interface IOrderService
{
    List<Order> GetOrders();

    Order GetOrder(int id);

    List<Order> GetUserOrders(int userId);

    void CreateOrder(Order order);

    void UpdateOrder(Order order);

    void CancelOrder(int id);
}