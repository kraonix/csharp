using Models;

namespace Data
{
    public static class ProductData
    {
        private static readonly List<Product> _products = new()
        {
            new Product(1, "Laptop", 50000),
            new Product(2, "Mouse", 800),
            new Product(3, "Keyboard", 1500),
            new Product(4, "Monitor", 25000),
            new Product(5, "Headphones", 2000)
        };

        public static IReadOnlyList<Product> Products => _products;

        public static Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static void AddProduct(int id, string name, decimal price)
        {
            _products.Add(new Product(id, name, price));
        }
    }
}
