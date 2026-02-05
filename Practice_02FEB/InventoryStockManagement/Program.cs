using System;

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        // -------- Hardcoded Initial Data --------
        manager.AddProduct("PR001", "Laptop", "Electronics",
            "Dell", 65000, 10, 5);

        manager.AddProduct("PR002", "Printer", "Electronics",
            "HP", 12000, 4, 5);

        manager.AddProduct("PR003", "Office Chair", "Furniture",
            "IKEA", 8000, 15, 5);
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nINVENTORY STOCK MANAGEMENT");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. Group Products by Category");
            Console.WriteLine("4. View Low Stock Products");
            Console.WriteLine("5. View Stock Value by Category");
            Console.WriteLine("6. View All Products");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Product Code: ");
                    string code = Console.ReadLine();

                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Supplier: ");
                    string supplier = Console.ReadLine();

                    Console.Write("Unit Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Initial Stock: ");
                    int stock = int.Parse(Console.ReadLine());

                    Console.Write("Minimum Stock Level: ");
                    int min = int.Parse(Console.ReadLine());

                    manager.AddProduct(code, name, category,
                        supplier, price, stock, min);

                    Console.WriteLine("Product added successfully.");
                    break;

                case 2:
                    Console.Write("Product Code: ");
                    string pcode = Console.ReadLine();

                    Console.Write("Movement Type (In/Out): ");
                    string type = Console.ReadLine();

                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    Console.Write("Reason (Purchase/Sale/Return): ");
                    string reason = Console.ReadLine();

                    Console.WriteLine(manager.UpdateStock(pcode, type, qty, reason)
                        ? "Stock updated successfully."
                        : "Stock update failed.");
                    break;

                case 3:
                    var grouped = manager.GroupProductsByCategory();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nCategory: {g.Key}");
                        foreach (var p in g.Value)
                        {
                            Console.WriteLine(
                                $"{p.ProductCode} - {p.ProductName} | Stock: {p.CurrentStock}");
                        }
                    }
                    break;

                case 4:
                    var lowStock = manager.GetLowStockProducts();
                    if (lowStock.Count == 0)
                    {
                        Console.WriteLine("No low stock products.");
                    }
                    else
                    {
                        foreach (var p in lowStock)
                        {
                            Console.WriteLine(
                                $"{p.ProductCode} - {p.ProductName} | Stock: {p.CurrentStock}");
                        }
                    }
                    break;

                case 5:
                    var values = manager.GetStockValueByCategory();
                    foreach (var v in values)
                    {
                        Console.WriteLine($"{v.Key} - Total Value: {v.Value}");
                    }
                    break;

                case 6:
                    foreach (var p in manager.GetAllProducts())
                    {
                        Console.WriteLine(
                            $"{p.ProductCode} - {p.ProductName} | {p.Category} | Stock: {p.CurrentStock}");
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
