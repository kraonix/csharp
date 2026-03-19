using Shared.Models;
using System.Collections.Concurrent;

namespace CartApi.Services;

public class InMemoryCartStore
{
    private readonly ConcurrentDictionary<int, CartItem> _items = new();

    public void AddOrUpdate(CartItem item)
    {
        _items.AddOrUpdate(
            item.ProductId,
            item,
            (_, existing) =>
            {
                existing.Quantity += item.Quantity;
                return existing;
            });
    }

    public List<CartItem> GetAll() => _items.Values.ToList();

    public decimal GetTotal() => _items.Values.Sum(i => i.Price * i.Quantity);

    public void Clear() => _items.Clear();
}
