using OrderServiceAPI.Models;
using OrderServiceAPI.Repositories;

namespace OrderServiceAPI.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public List<Order> GetOrders()
    {
        return _repository.GetAll();
    }

    public Order GetOrder(int id)
    {
        return _repository.GetById(id);
    }

    public List<Order> GetUserOrders(int userId)
    {
        return _repository.GetByUser(userId);
    }

    public void CreateOrder(Order order)
    {
        _repository.Add(order);
    }

    public void UpdateOrder(Order order)
    {
        _repository.Update(order);
    }

    public void CancelOrder(int id)
    {
        _repository.Delete(id);
    }
}