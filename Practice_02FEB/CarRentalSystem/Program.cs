using System;
using System.Collections.Generic;
using System.Linq;
namespace CarRentalSystem
{
    class Program
{
    static void Main()
    {
        RentalManager manager = new RentalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== CAR RENTAL AGENCY ===");
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. Rent Car");
            Console.WriteLine("3. View Available Cars by Type");
            Console.WriteLine("4. View Active Rentals");
            Console.WriteLine("5. Calculate Revenue");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("License Plate: ");
                        string license = Console.ReadLine();
                        Console.Write("Make: ");
                        string make = Console.ReadLine();
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Type (Sedan/SUV/Van): ");
                        string type = Console.ReadLine();
                        Console.Write("Daily Rate: ");
                        double rate = double.Parse(Console.ReadLine());
                        manager.AddCar(license, make, model, type, rate);
                        Console.WriteLine("Car added");
                        break;

                    case 2:
                        Console.Write("License Plate: ");
                        string rentLicense = Console.ReadLine();
                        Console.Write("Customer Name: ");
                        string customer = Console.ReadLine();
                        Console.Write("Start Date (yyyy-MM-dd): ");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Days: ");
                        int days = int.Parse(Console.ReadLine());

                        bool rented = manager.RentCar(rentLicense, customer, start, days);
                        Console.WriteLine(rented ? "Car rented successfully" : "Car not available");
                        break;

                    case 3:
                        var grouped = manager.GroupCarsByType();
                        foreach (var g in grouped)
                        {
                            Console.WriteLine($"\n{g.Key}:");
                            foreach (var c in g.Value)
                                Console.WriteLine($"{c.LicensePlate} | {c.Make} {c.Model}");
                        }
                        break;

                    case 4:
                        foreach (var r in manager.GetActiveRentals())
                            Console.WriteLine($"{r.RentalId} | {r.CustomerName} | {r.LicensePlate} | Until {r.EndDate}");
                        break;

                    case 5:
                        Console.WriteLine("Total Revenue: " + manager.CalculateTotalRentalRevenue());
                        break;

                    case 0:
                        exit = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
}