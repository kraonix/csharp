using ProductServiceAPI.Models;

namespace ProductServiceAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private static List<Product> products = new List<Product>()
    {
        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 999.99m, Stock = 50 },
        new Product { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 599.99m, Stock = 100 },
        new Product { Id = 3, Name = "Desk Chair", Category = "Furniture", Price = 150.00m, Stock = 20 }
    };

    public List<Product> GetAll()
    {
        return products;
    }

    public Product GetById(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Product product)
    {
        product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
        products.Add(product);
    }

    public void Update(Product product)
    {
        var existing = products.FirstOrDefault(p => p.Id == product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Category = product.Category;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
        }
    }

    public void Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
        }
    }
}