using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        DeliveryManager manager = new DeliveryManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nONLINE FOOD DELIVERY SYSTEM");
            Console.WriteLine("1. Add Restaurant");
            Console.WriteLine("2. Add Food Item");
            Console.WriteLine("3. Place Order");
            Console.WriteLine("4. View Restaurants Grouped by Cuisine");
            Console.WriteLine("5. View Pending Orders");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter restaurant name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter cuisine type: ");
                    string cuisine = Console.ReadLine();

                    Console.Write("Enter location: ");
                    string location = Console.ReadLine();

                    Console.Write("Enter delivery charge: ");
                    double charge = double.Parse(Console.ReadLine());

                    manager.AddRestaurant(name, cuisine, location, charge);
                    Console.WriteLine("Restaurant added successfully.");
                    break;

                case 2:
                    Console.Write("Enter restaurant ID: ");
                    int restaurantId = int.Parse(Console.ReadLine());

                    Console.Write("Enter food item name: ");
                    string itemName = Console.ReadLine();

                    Console.Write("Enter category: ");
                    string category = Console.ReadLine();

                    Console.Write("Enter price: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.AddFoodItem(restaurantId, itemName, category, price);
                    Console.WriteLine("Food item added successfully.");
                    break;

                case 3:
                    Console.Write("Enter customer ID: ");
                    int customerId = int.Parse(Console.ReadLine());

                    Console.Write("Enter food item IDs (comma separated): ");
                    string[] ids = Console.ReadLine().Split(',');

                    List<int> itemIds = new();
                    foreach (string id in ids)
                        itemIds.Add(int.Parse(id.Trim()));

                    bool placed = manager.PlaceOrder(customerId, itemIds);
                    Console.WriteLine(placed
                        ? "Order placed successfully."
                        : "Order could not be placed.");
                    break;

                case 4:
                    var grouped = manager.GroupRestaurantsByCuisine();
                    foreach (var group in grouped)
                    {
                        Console.WriteLine($"\nCuisine: {group.Key}");
                        foreach (var r in group.Value)
                        {
                            Console.WriteLine($"{r.RestaurantId} - {r.Name} ({r.Location})");
                        }
                    }
                    break;

                case 5:
                    var orders = manager.GetPendingOrders();
                    if (orders.Count == 0)
                    {
                        Console.WriteLine("No pending orders.");
                    }
                    else
                    {
                        foreach (var o in orders)
                        {
                            Console.WriteLine(
                                $"Order ID: {o.OrderId}, Customer ID: {o.CustomerId}, Total Amount: {o.TotalAmount}");
                        }
                    }
                    break;

                case 0:
                    exit = true;
                    Console.WriteLine("Exiting application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
