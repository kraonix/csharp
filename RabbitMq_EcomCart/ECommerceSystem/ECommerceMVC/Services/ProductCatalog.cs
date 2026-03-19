using Shared.Models;

namespace ECommerceMVC.Services;

public class ProductCatalog
{
    public List<Product> Products { get; } = new()
    {
        new Product { Id = 1, Name = "Wireless Headphones", Price = 2499.00m, Description = "Premium noise-cancelling wireless headphones", ImageUrl = "https://placehold.co/300x200/6366f1/white?text=Headphones" },
        new Product { Id = 2, Name = "Mechanical Keyboard", Price = 3999.00m, Description = "RGB mechanical gaming keyboard", ImageUrl = "https://placehold.co/300x200/8b5cf6/white?text=Keyboard" },
        new Product { Id = 3, Name = "USB-C Hub", Price = 1299.00m, Description = "7-in-1 multiport USB-C hub adapter", ImageUrl = "https://placehold.co/300x200/06b6d4/white?text=USB+Hub" },
        new Product { Id = 4, Name = "Webcam HD 1080p", Price = 2199.00m, Description = "Full HD webcam with built-in microphone", ImageUrl = "https://placehold.co/300x200/10b981/white?text=Webcam" },
        new Product { Id = 5, Name = "Gaming Mouse", Price = 1799.00m, Description = "Precision gaming mouse with 12000 DPI", ImageUrl = "https://placehold.co/300x200/f59e0b/white?text=Mouse" },
        new Product { Id = 6, Name = "27\" Monitor", Price = 18999.00m, Description = "4K IPS display with 144Hz refresh rate", ImageUrl = "https://placehold.co/300x200/ef4444/white?text=Monitor" },
    };

    public Product? GetById(int id) => Products.FirstOrDefault(p => p.Id == id);
}
