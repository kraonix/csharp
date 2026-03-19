using Shared.Models;

namespace ProductApi.Services;

public class ProductRepository
{
    public List<Product> Products { get; } = new()
    {
        new Product { Id = 1, Name = "Wireless Headphones", Price = 2499.00m, Description = "Premium noise-cancelling wireless headphones" },
        new Product { Id = 2, Name = "Mechanical Keyboard", Price = 3999.00m, Description = "RGB mechanical gaming keyboard" },
        new Product { Id = 3, Name = "USB-C Hub", Price = 1299.00m, Description = "7-in-1 multiport USB-C hub adapter" },
        new Product { Id = 4, Name = "Webcam HD 1080p", Price = 2199.00m, Description = "Full HD webcam with built-in microphone" },
        new Product { Id = 5, Name = "Gaming Mouse", Price = 1799.00m, Description = "Precision gaming mouse with 12000 DPI" },
        new Product { Id = 6, Name = "27\" Monitor", Price = 18999.00m, Description = "4K IPS display with 144Hz refresh rate" },
    };

    public Product? GetById(int id) => Products.FirstOrDefault(p => p.Id == id);
}
