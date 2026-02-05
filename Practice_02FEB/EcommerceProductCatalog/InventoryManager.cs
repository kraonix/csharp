using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    private readonly List<Product> _products = new();
    private int _productCounter = 1;

    // Add Product with auto-generated ProductCode
    public void AddProduct(string name, string category, double price, int stock)
    {
        string code = $"P{_productCounter:D3}";
        _productCounter++;

        _products.Add(new Product
        {
            ProductCode = code,
            ProductName = name,
            Category = category,
            Price = price,
            StockQuantity = stock
        });
    }

    // Group Products by Category
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        return new SortedDictionary<string, List<Product>>(
            _products
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.ToList())
        );
    }

    // Update Stock
    public bool UpdateStock(string productCode, int quantity)
    {
        var product = _products.FirstOrDefault(p => p.ProductCode == productCode);
        if (product == null || product.StockQuantity < quantity)
            return false;

        product.StockQuantity -= quantity;
        return true;
    }

    // Get Products Below Price
    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return _products
            .Where(p => p.Price <= maxPrice)
            .ToList();
    }

    // Category Stock Summary
    public Dictionary<string, int> GetCategoryStockSummary()
    {
        return _products
            .GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.Sum(p => p.StockQuantity));
    }

    // Helper
    public List<Product> GetAllProducts() => _products;
}
