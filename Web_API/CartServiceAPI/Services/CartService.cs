using CartServiceAPI.Models;
using CartServiceAPI.Repositories;

namespace CartServiceAPI.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _repository;

    public CartService(ICartRepository repository)
    {
        _repository = repository;
    }

    public List<CartItem> GetCart()
    {
        return _repository.GetAll();
    }

    public List<CartItem> GetUserCart(int userId)
    {
        return _repository.GetByUser(userId);
    }

    public void AddToCart(CartItem item)
    {
        _repository.Add(item);
    }

    public void RemoveFromCart(int id)
    {
        _repository.Remove(id);
    }
}