using CartServiceAPI.Models;

namespace CartServiceAPI.Services;

public interface ICartService
{
    List<CartItem> GetCart();

    List<CartItem> GetUserCart(int userId);

    void AddToCart(CartItem item);

    void RemoveFromCart(int id);
}