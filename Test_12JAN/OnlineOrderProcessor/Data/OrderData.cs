using Logic;
using Models;

namespace Data
{
    public static class OrderData
    {
        private static readonly Dictionary<int, Order> _orders = new();

        public static IReadOnlyDictionary<int, Order> Orders => _orders;

        public static void AddOrder(Order order)
        {
            _orders[order.Id] = order;
        }

        public static Order? GetById(int id)
        {
            return _orders.TryGetValue(id, out var order) ? order : null;
        }

        public static IReadOnlyList<Order> GetAll()
        {
            return _orders.Values.ToList();
        }

        public static int GetNextOrderId()
        {
            return _orders.Count == 0 ? 100 : _orders.Keys.Max() + 1;
        }

    }
}
