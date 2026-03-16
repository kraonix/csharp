using CartServiceAPI.Models;

namespace CartServiceAPI.Repositories;

public class CartRepository : ICartRepository
{
    private static List<CartItem> cartItems = new List<CartItem>()
    {
        new CartItem { Id = 1, UserId = 1, ProductId = 2, Quantity = 1 },
        new CartItem { Id = 2, UserId = 2, ProductId = 1, Quantity = 2 }
    };

    public List<CartItem> GetAll()
    {
        return cartItems;
    }

    public List<CartItem> GetByUser(int userId)
    {
        return cartItems.Where(c => c.UserId == userId).ToList();
    }

    public void Add(CartItem item)
    {
        item.Id = cartItems.Max(c => c.Id) + 1;
        cartItems.Add(item);
    }

    public void Remove(int id)
    {
        var item = cartItems.FirstOrDefault(c => c.Id == id);

        if (item != null)
        {
            cartItems.Remove(item);
        }
    }
}