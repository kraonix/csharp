using System;

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        // -------- Hardcoded Initial Data --------
        manager.AddProduct("Laptop", "Electronics", 65000, 10);
        manager.AddProduct("Smartphone", "Electronics", 30000, 15);
        manager.AddProduct("T-Shirt", "Clothing", 999, 40);
        manager.AddProduct("Jeans", "Clothing", 1999, 25);
        manager.AddProduct("C# Programming", "Books", 799, 20);
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nE-COMMERCE PRODUCT CATALOG");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Display Products Grouped by Category");
            Console.WriteLine("3. Update Stock");
            Console.WriteLine("4. Find Products Below Price");
            Console.WriteLine("5. View Category Stock Summary");
            Console.WriteLine("6. View All Products");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category (Electronics/Clothing/Books): ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Stock Quantity: ");
                    int stock = int.Parse(Console.ReadLine());

                    manager.AddProduct(name, category, price, stock);
                    Console.WriteLine("Product added successfully.");
                    break;

                case 2:
                    var grouped = manager.GroupProductsByCategory();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nCategory: {g.Key}");
                        foreach (var p in g.Value)
                        {
                            Console.WriteLine(
                                $"{p.ProductCode} - {p.ProductName} | ₹{p.Price} | Stock: {p.StockQuantity}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Product Code: ");
                    string code = Console.ReadLine();

                    Console.Write("Quantity Sold: ");
                    int qty = int.Parse(Console.ReadLine());

                    Console.WriteLine(manager.UpdateStock(code, qty)
                        ? "Stock updated successfully."
                        : "Stock update failed.");
                    break;

                case 4:
                    Console.Write("Enter max price: ");
                    double maxPrice = double.Parse(Console.ReadLine());

                    var cheapProducts = manager.GetProductsBelowPrice(maxPrice);
                    foreach (var p in cheapProducts)
                    {
                        Console.WriteLine(
                            $"{p.ProductCode} - {p.ProductName} | ₹{p.Price}");
                    }
                    break;

                case 5:
                    var summary = manager.GetCategoryStockSummary();
                    foreach (var s in summary)
                    {
                        Console.WriteLine($"{s.Key} : Total Stock = {s.Value}");
                    }
                    break;

                case 6:
                    foreach (var p in manager.GetAllProducts())
                    {
                        Console.WriteLine(
                            $"{p.ProductCode} - {p.ProductName} | {p.Category} | ₹{p.Price} | Stock: {p.StockQuantity}");
                    }
                    break;

                case 0:
                    exit = true;
                    Console.WriteLine("Exiting application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
