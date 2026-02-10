// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();
    
    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
        bool shouldAdd = true;
        foreach(var v in _products){
            if(product.Id == v.Id){
                shouldAdd = false;
                break;
            }
        }
        if(product.Price <= 0) shouldAdd = false;
        if(string.IsNullOrWhiteSpace(product.Name)) shouldAdd = false;
        
        if(shouldAdd){
            _products.Add(product);
        }else{
            throw new ArgumentException("Error");
        }
        
    }
    
    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        bool ok = true;
        if (predicate == null) ok = false;
        
        if(ok)
            return _products.Where(predicate);
        else
            throw new ArgumentException("Error");
    }
    
    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        decimal result = 0m;
        foreach(var v in _products){
            result += v.Price;
        }

        return result;
    }
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        bool ok = true;
        if (product == null) 
            ok = false;

        if (discountPercentage < 0 || discountPercentage > 100) 
            ok = false;
        if(ok){
            _product = product;
            _discountPercentage = discountPercentage;
        }else{
            throw new ArgumentException("Error");
        }
    }
    
    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
    
    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price:C} | " +
           $"Discount: {_discountPercentage}% | " +
           $"Final: {DiscountedPrice:C}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        // b) Find the most expensive product
        // c) Group products by category
        // d) Apply 10% discount to Electronics over $500
        
        //a--------------------------------------------------------
        foreach(var v in products){
            Console.WriteLine($"Name : {v.Name} => Price : {v.Price}");
        }
        
        //b--------------------------------------------------------
        var mostExpensive = products.OrderByDescending(p => p.Price).FirstOrDefault();
        
        //c--------------------------------------------------------
        var grouped = products.GroupBy(p => p.Category);

        foreach (var group in grouped)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var item in group)
            {
                Console.WriteLine($"  {item.Name}");
            }
        }
        
        //d--------------------------------------------------------
        var discounted = products
        .Where(p => p.Category == Category.Electronics && p.Price > 500)
        .Select(p => new DiscountedProduct<T>(p, 10));

        foreach (var item in discounted)
        {
            Console.WriteLine(item);
        }
        
    }
    
    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully
        if (products == null || priceAdjuster == null)
        return;

        foreach (var product in products)
        {
            try
            {
                decimal newPrice = priceAdjuster(product);
    
                if (product is ElectronicProduct ep)
                {
                    ep.Price = newPrice;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product {product.Name}: {ex.Message}");
            }
        }
    }
}


public class Program
{
    public static void Main()
    {
        // Create repository
        var repo = new ProductRepository<ElectronicProduct>();

        // Create some products
        var p1 = new ElectronicProduct
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200,
            WarrantyMonths = 24,
            Brand = "Dell"
        };

        var p2 = new ElectronicProduct
        {
            Id = 2,
            Name = "Headphones",
            Price = 300,
            WarrantyMonths = 12,
            Brand = "Sony"
        };

        var p3 = new ElectronicProduct
        {
            Id = 3,
            Name = "Gaming Monitor",
            Price = 700,
            WarrantyMonths = 36,
            Brand = "LG"
        };

        // Add products
        repo.AddProduct(p1);
        repo.AddProduct(p2);
        repo.AddProduct(p3);

        // Show total value
        Console.WriteLine($"\nTotal Inventory Value: {repo.CalculateTotalValue():C}");
        Console.WriteLine("--------------------------------------------------");

        // Find expensive products
        var expensive = repo.FindProducts(p => p.Price > 500);
        Console.WriteLine("Products above ₹500:");
        foreach (var item in expensive)
        {
            Console.WriteLine($"{item.Name} - {item.Price:C}");
        }

        Console.WriteLine("--------------------------------------------------");

        // Process products
        var manager = new InventoryManager();
        manager.ProcessProducts(new List<ElectronicProduct> { p1, p2, p3 });

        Console.WriteLine("--------------------------------------------------");

        // Bulk update prices (increase by 5%)
        manager.UpdatePrices(
            new List<ElectronicProduct> { p1, p2, p3 },
            product => product.Price * 1.05m
        );

        Console.WriteLine("After 5% Price Increase:");
        foreach (var product in new List<ElectronicProduct> { p1, p2, p3 })
        {
            Console.WriteLine($"{product.Name} - {product.Price:C}");
        }
    }
}