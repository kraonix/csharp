using CartServiceAPI.Models;

namespace CartServiceAPI.Repositories;

public interface ICartRepository
{
    List<CartItem> GetAll();

    List<CartItem> GetByUser(int userId);

    void Add(CartItem item);

    void Remove(int id);
}