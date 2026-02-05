using System;
using RMM;

class Program
{
    static void Main()
    {
        MenuItemUtility util = new MenuItemUtility();

        // Seed some default items
        util.AddMenuItem("Paneer Butter Masala", "Main Course", 250, true);
        util.AddMenuItem("Chicken Biryani", "Main Course", 320, false);
        util.AddMenuItem("Veg Burger", "Fast Food", 120, true);
        util.AddMenuItem("French Fries", "Fast Food", 90, true);
        util.AddMenuItem("Cold Coffee", "Beverages", 80, true);

        while (true)
        {
            Console.WriteLine("\n====== Restaurant Menu Manager ======");
            Console.WriteLine("1. Add Menu Item");
            Console.WriteLine("2. Group Items By Category");
            Console.WriteLine("3. Show Vegetarian Items");
            Console.WriteLine("4. Average Price By Category");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Item Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Is Vegetarian (true/false): ");
                    bool isVeg = bool.Parse(Console.ReadLine());

                    util.AddMenuItem(name, category, price, isVeg);
                    Console.WriteLine("Item added successfully!");
                    break;

                case 2:
                    var grouped = util.GroupItemsByCategory();
                    foreach (var cat in grouped)
                    {
                        Console.WriteLine($"\nCategory: {cat.Key}");
                        foreach (var item in cat.Value)
                        {
                            Console.WriteLine($"  {item.ItemName} - Rs. {item.Price} - {(item.IsVegetarian ? "Veg" : "Non-Veg")}");
                        }
                    }
                    break;

                case 3:
                    var vegItems = util.GetVegetarianItems();
                    Console.WriteLine("\nVegetarian Menu:");
                    foreach (var item in vegItems)
                    {
                        Console.WriteLine($"{item.ItemName} - Rs. {item.Price}");
                    }
                    break;

                case 4:
                    Console.Write("Enter Category: ");
                    string catName = Console.ReadLine();
                    double avg = util.CalculateAveragePriceByCategory(catName);
                    Console.WriteLine($"Average price in {catName}: Rs. {avg}");
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
