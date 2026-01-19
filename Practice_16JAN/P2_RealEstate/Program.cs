using System;
using System.Collections.Generic;
using System.Linq;

// ---------- Interface ----------
public interface IRealEstateListing
{
    int? ID { get; set; }
    string? Title { get; set; }
    string? Description { get; set; }
    int? Price { get; set; }
    string? Location { get; set; }
}

// ---------- Model ----------
public class RealEstateListing : IRealEstateListing
{
    public int? ID { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Price { get; set; }
    public string? Location { get; set; }
}

// ---------- App Logic ----------
public class RealEstateApp
{
    private readonly List<IRealEstateListing> _listing = new();

    public void AddListing(IRealEstateListing listing)
    {
        _listing.Add(listing);
        Console.WriteLine("Property Added Successfully!");
    }

    public void RemoveListing(int listingID)
    {
        var property = _listing.FirstOrDefault(p => p.ID == listingID);

        if (property != null)
        {
            _listing.Remove(property);
            Console.WriteLine($"Property with ID {listingID} removed successfully!");
        }
        else
        {
            Console.WriteLine("Property not found.");
        }
    }

    public void GetListings()
    {
        if (_listing.Count == 0)
        {
            Console.WriteLine("No Properties Available.");
            return;
        }

        Console.WriteLine("\nAll Properties:");
        foreach (var property in _listing)
        {
            Print(property);
        }
    }

    public void GetListingsByLocation(string location)
    {
        var filtered = _listing
            .Where(p => p.Location != null &&
                        p.Location.Contains(location, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine("No Properties Found in this Location!");
            return;
        }

        Console.WriteLine("\nProperties by Location:");
        foreach (var property in filtered)
        {
            Print(property);
        }
    }

    public void GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        var filtered = _listing
            .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
            .ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine("No Properties Found in this Price Range!");
            return;
        }

        Console.WriteLine("\nProperties by Price Range:");
        foreach (var property in filtered)
        {
            Print(property);
        }
    }

    private void Print(IRealEstateListing property)
    {
        Console.WriteLine($"{property.ID} | {property.Title} | {property.Description} | {property.Price} | {property.Location}");
    }
}

// ---------- Program ----------
public class Program
{
    public static void Main(string[] args)
    {
        RealEstateApp app = new();

        while (true)
        {
            Console.WriteLine("\nReal Estate Management");
            Console.WriteLine("1. Add Property");
            Console.WriteLine("2. Remove Property");
            Console.WriteLine("3. View All Properties");
            Console.WriteLine("4. Search by Location");
            Console.WriteLine("5. Search by Price Range");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine()!);

                    Console.Write("Title: ");
                    string title = Console.ReadLine()!;

                    Console.Write("Description: ");
                    string desc = Console.ReadLine()!;

                    Console.Write("Price: ");
                    int price = int.Parse(Console.ReadLine()!);

                    Console.Write("Location: ");
                    string location = Console.ReadLine()!;

                    app.AddListing(new RealEstateListing
                    {
                        ID = id,
                        Title = title,
                        Description = desc,
                        Price = price,
                        Location = location
                    });
                    break;

                case 2:
                    Console.Write("Enter Property ID to remove: ");
                    app.RemoveListing(int.Parse(Console.ReadLine()!));
                    break;

                case 3:
                    app.GetListings();
                    break;

                case 4:
                    Console.Write("Enter Location: ");
                    app.GetListingsByLocation(Console.ReadLine()!);
                    break;

                case 5:
                    Console.Write("Min Price: ");
                    int min = int.Parse(Console.ReadLine()!);
                    Console.Write("Max Price: ");
                    int max = int.Parse(Console.ReadLine()!);
                    app.GetListingsByPriceRange(min, max);
                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }
    }
}