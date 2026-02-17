using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
public enum Location
{
    Mumbai, Pune, Chennai, Delhi, Kolkata, Bangalore
}


public enum Core
{
    DotNet, Java, Oracle, Testing
}

public class Application
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public Location CurrentLocation { get; set; }
    public Location PreferredLocation { get; set; }
    public Core Core { get; set; }
    public int PassingYear { get; set; }
}


public static class ApplicationUtility
{
    private static readonly string FilePath = "applications.json";

    // Save list to JSON file
    public static void Save(List<Application> applications)
    {
        var json = JsonSerializer.Serialize(
            applications,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(FilePath, json);
    }

    // Read list from JSON file
    public static List<Application> Load()
    {
        if (!File.Exists(FilePath))
            return new List<Application>();

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Application>>(json)
               ?? new List<Application>();
    }

    // Action 1: Filter by Core
    public static List<Application> GetByCore(Core core)
    {
        return Load().Where(a => a.Core == core).ToList();
    }

    // Action 2: Filter by Preferred Location
    public static List<Application> GetByPreferredLocation(Location location)
    {
        return Load().Where(a => a.PreferredLocation == location).ToList();
    }

    // Action 3: Filter by Passing Year
    public static List<Application> GetByPassingYear(int year)
    {
        return Load().Where(a => a.PassingYear == year).ToList();
    }
}



public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Campus Hire System =====");
            Console.WriteLine("1. Add Application");
            Console.WriteLine("2. View All Applications");
            Console.WriteLine("3. Filter By Core");
            Console.WriteLine("4. Filter By Preferred Location");
            Console.WriteLine("5. Filter By Passing Year");
            Console.WriteLine("6. Exit");
            Console.Write("Select option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddApplication();
                    break;

                case "2":
                    ViewAll();
                    break;

                case "3":
                    FilterByCore();
                    break;

                case "4":
                    FilterByLocation();
                    break;

                case "5":
                    FilterByYear();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void AddApplication()
    {
        var applications = ApplicationUtility.Load();

        Console.Write("Id: ");
        string id = Console.ReadLine() ?? "";

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Select Current Location:");
        foreach (var loc in Enum.GetValues<Location>())
            Console.WriteLine($"{(int)loc} - {loc}");

        Location current = (Location)int.Parse(Console.ReadLine()!);

        Console.WriteLine("Select Preferred Location:");
        foreach (var loc in Enum.GetValues<Location>())
            Console.WriteLine($"{(int)loc} - {loc}");

        Location preferred = (Location)int.Parse(Console.ReadLine()!);

        Console.WriteLine("Select Core:");
        foreach (var core in Enum.GetValues<Core>())
            Console.WriteLine($"{(int)core} - {core}");

        Core selectedCore = (Core)int.Parse(Console.ReadLine()!);

        Console.Write("Passing Year: ");
        int year = int.Parse(Console.ReadLine()!);

        applications.Add(new Application
        {
            Id = id,
            Name = name,
            CurrentLocation = current,
            PreferredLocation = preferred,
            Core = selectedCore,
            PassingYear = year
        });

        ApplicationUtility.Save(applications);

        Console.WriteLine("Application saved successfully.");
    }

    private static void ViewAll()
    {
        var applications = ApplicationUtility.Load();

        if (!applications.Any())
        {
            Console.WriteLine("No applications found.");
            return;
        }

        foreach (var app in applications)
        {
            Print(app);
        }
    }

    private static void FilterByCore()
    {
        Console.WriteLine("Select Core:");
        foreach (var core in Enum.GetValues<Core>())
            Console.WriteLine($"{(int)core} - {core}");

        Core selectedCore = (Core)int.Parse(Console.ReadLine()!);

        var results = ApplicationUtility.GetByCore(selectedCore);

        DisplayResults(results);
    }

    private static void FilterByLocation()
    {
        Console.WriteLine("Select Preferred Location:");
        foreach (var loc in Enum.GetValues<Location>())
            Console.WriteLine($"{(int)loc} - {loc}");

        Location location = (Location)int.Parse(Console.ReadLine()!);

        var results = ApplicationUtility.GetByPreferredLocation(location);

        DisplayResults(results);
    }

    private static void FilterByYear()
    {
        Console.Write("Enter Passing Year: ");
        int year = int.Parse(Console.ReadLine()!);

        var results = ApplicationUtility.GetByPassingYear(year);

        DisplayResults(results);
    }

    private static void DisplayResults(List<Application> apps)
    {
        if (!apps.Any())
        {
            Console.WriteLine("No matching records found.");
            return;
        }

        foreach (var app in apps)
        {
            Print(app);
        }
    }

    private static void Print(Application app)
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Id: {app.Id}");
        Console.WriteLine($"Name: {app.Name}");
        Console.WriteLine($"Current Location: {app.CurrentLocation}");
        Console.WriteLine($"Preferred Location: {app.PreferredLocation}");
        Console.WriteLine($"Core: {app.Core}");
        Console.WriteLine($"Passing Year: {app.PassingYear}");
    }
}