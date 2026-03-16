using OrderServiceAPI.Models;

namespace OrderServiceAPI.Repositories;

public interface IOrderRepository
{
    List<Order> GetAll();

    Order GetById(int id);

    List<Order> GetByUser(int userId);

    void Add(Order order);

    void Update(Order order);

    void Delete(int id);
}