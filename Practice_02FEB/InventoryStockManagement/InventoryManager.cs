using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    private readonly List<Product> _products = new();
    private readonly List<StockMovement> _movements = new();
    private int _movementCounter = 1;

    // Add Product
    public void AddProduct(string code, string name, string category,
                           string supplier, double price,
                           int stock, int minLevel)
    {
        _products.Add(new Product
        {
            ProductCode = code,
            ProductName = name,
            Category = category,
            Supplier = supplier,
            UnitPrice = price,
            CurrentStock = stock,
            MinimumStockLevel = minLevel
        });
    }

    // Update Stock
    public bool UpdateStock(string productCode, string movementType,
                            int quantity, string reason)
    {
        var product = _products.FirstOrDefault(p => p.ProductCode == productCode);
        if (product == null || quantity <= 0)
            return false;

        if (movementType == "Out" && product.CurrentStock < quantity)
            return false;

        if (movementType == "In")
            product.CurrentStock += quantity;
        else if (movementType == "Out")
            product.CurrentStock -= quantity;
        else
            return false;

        _movements.Add(new StockMovement
        {
            MovementId = _movementCounter++,
            ProductCode = productCode,
            MovementDate = DateTime.Now,
            MovementType = movementType,
            Quantity = quantity,
            Reason = reason
        });

        return true;
    }

    // Group Products by Category
    public Dictionary<string, List<Product>> GroupProductsByCategory()
    {
        return _products
            .GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Low Stock Products
    public List<Product> GetLowStockProducts()
    {
        return _products
            .Where(p => p.CurrentStock <= p.MinimumStockLevel)
            .ToList();
    }

    // Stock Value by Category
    public Dictionary<string, int> GetStockValueByCategory()
    {
        return _products
            .GroupBy(p => p.Category)
            .ToDictionary(
                g => g.Key,
                g => (int)g.Sum(p => p.UnitPrice * p.CurrentStock)
            );
    }

    // Helpers for menu
    public List<Product> GetAllProducts() => _products;
}
