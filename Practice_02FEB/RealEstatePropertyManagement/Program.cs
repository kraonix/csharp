using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        RealEstateManager manager = new RealEstateManager();

        // -------- Hardcoded Initial Data --------
        manager.AddProperty("MG Road, Bangalore", "Apartment",
            2, 1200, 7500000, "Mr. Rao");

        manager.AddProperty("Whitefield, Bangalore", "Villa",
            4, 3000, 18500000, "Mrs. Sharma");

        manager.AddProperty("Indiranagar, Bangalore", "House",
            3, 1800, 11000000, "Mr. Verma");

        manager.AddClient("Amit", "9876543210", "Buyer",
            12000000, new List<string> { "3BHK", "Parking" });

        manager.AddClient("Neha", "9123456780", "Renter",
            40000, new List<string> { "2BHK", "Near Metro" });
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nREAL ESTATE PROPERTY MANAGEMENT");
            Console.WriteLine("1. Add Property");
            Console.WriteLine("2. Add Client");
            Console.WriteLine("3. Schedule Viewing");
            Console.WriteLine("4. Group Properties by Type");
            Console.WriteLine("5. Find Properties in Budget");
            Console.WriteLine("6. View All Properties");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Address: ");
                    string address = Console.ReadLine();

                    Console.Write("Property Type (Apartment/House/Villa): ");
                    string type = Console.ReadLine();

                    Console.Write("Bedrooms: ");
                    int beds = int.Parse(Console.ReadLine());

                    Console.Write("Area (sq ft): ");
                    double area = double.Parse(Console.ReadLine());

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Owner: ");
                    string owner = Console.ReadLine();

                    manager.AddProperty(address, type, beds, area, price, owner);
                    Console.WriteLine("Property added successfully.");
                    break;

                case 2:
                    Console.Write("Client Name: ");
                    string cname = Console.ReadLine();

                    Console.Write("Contact: ");
                    string contact = Console.ReadLine();

                    Console.Write("Client Type (Buyer/Renter): ");
                    string ctype = Console.ReadLine();

                    Console.Write("Budget: ");
                    double budget = double.Parse(Console.ReadLine());

                    Console.Write("Requirements (comma separated): ");
                    var req = new List<string>(
                        Console.ReadLine().Split(',', StringSplitOptions.TrimEntries));

                    manager.AddClient(cname, contact, ctype, budget, req);
                    Console.WriteLine("Client registered successfully.");
                    break;

                case 3:
                    Console.WriteLine("Available Properties:");
                    foreach (var p in manager.GetAllProperties())
                        Console.WriteLine($"{p.PropertyId} - {p.Address}");

                    Console.Write("Property ID: ");
                    string pid = Console.ReadLine();

                    Console.WriteLine("Clients:");
                    foreach (var c in manager.GetAllClients())
                        Console.WriteLine($"{c.ClientId} - {c.Name}");

                    Console.Write("Client ID: ");
                    int cid = int.Parse(Console.ReadLine());

                    Console.Write("Viewing Date (yyyy-mm-dd): ");
                    DateTime vdate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine(manager.ScheduleViewing(pid, cid, vdate)
                        ? "Viewing scheduled successfully."
                        : "Viewing scheduling failed.");
                    break;

                case 4:
                    var grouped = manager.GroupPropertiesByType();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nProperty Type: {g.Key}");
                        foreach (var p in g.Value)
                            Console.WriteLine($"{p.PropertyId} - {p.Address}");
                    }
                    break;

                case 5:
                    Console.Write("Min Price: ");
                    double min = double.Parse(Console.ReadLine());

                    Console.Write("Max Price: ");
                    double max = double.Parse(Console.ReadLine());

                    var list = manager.GetPropertiesInBudget(min, max);
                    foreach (var p in list)
                    {
                        Console.WriteLine(
                            $"{p.PropertyId} - {p.Address} | Price: {p.Price}");
                    }
                    break;

                case 6:
                    foreach (var p in manager.GetAllProperties())
                    {
                        Console.WriteLine(
                            $"{p.PropertyId} | {p.PropertyType} | {p.Address} | {p.Status}");
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
