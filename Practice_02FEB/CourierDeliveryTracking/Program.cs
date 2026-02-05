using System;

class Program
{
    static void Main()
    {
        CourierManager manager = new CourierManager();

        // -------- Hardcoded Initial Data --------
        manager.AddPackage("Amit", "Rahul", "Mumbai, Maharashtra",
            2.5, "Parcel", 350);

        manager.AddPackage("Neha", "Sneha", "Delhi, India",
            0.8, "Document", 120);

        manager.AddPackage("CompanyX", "ClientY", "Bangalore, Karnataka",
            5.0, "Fragile", 800);
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nCOURIER DELIVERY TRACKING SYSTEM");
            Console.WriteLine("1. Add Package");
            Console.WriteLine("2. Update Delivery Status");
            Console.WriteLine("3. Group Packages by Type");
            Console.WriteLine("4. Track Packages by Destination");
            Console.WriteLine("5. View Delayed Packages");
            Console.WriteLine("6. View All Packages");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Sender Name: ");
                    string sender = Console.ReadLine();

                    Console.Write("Receiver Name: ");
                    string receiver = Console.ReadLine();

                    Console.Write("Destination Address: ");
                    string address = Console.ReadLine();

                    Console.Write("Weight: ");
                    double weight = double.Parse(Console.ReadLine());

                    Console.Write("Package Type (Document/Parcel/Fragile): ");
                    string type = Console.ReadLine();

                    Console.Write("Shipping Cost: ");
                    double cost = double.Parse(Console.ReadLine());

                    manager.AddPackage(sender, receiver, address,
                        weight, type, cost);

                    Console.WriteLine("Package registered successfully.");
                    break;

                case 2:
                    Console.Write("Tracking Number: ");
                    string track = Console.ReadLine();

                    Console.Write("New Status (Dispatched/InTransit/Delivered): ");
                    string status = Console.ReadLine();

                    Console.Write("Checkpoint Info: ");
                    string checkpoint = Console.ReadLine();

                    Console.WriteLine(manager.UpdateStatus(track, status, checkpoint)
                        ? "Status updated successfully."
                        : "Status update failed.");
                    break;

                case 3:
                    var grouped = manager.GroupPackagesByType();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nPackage Type: {g.Key}");
                        foreach (var p in g.Value)
                        {
                            Console.WriteLine(
                                $"{p.TrackingNumber} - {p.ReceiverName}");
                        }
                    }
                    break;

                case 4:
                    Console.Write("Enter destination city: ");
                    string city = Console.ReadLine();

                    var list = manager.GetPackagesByDestination(city);
                    foreach (var p in list)
                    {
                        Console.WriteLine(
                            $"{p.TrackingNumber} - {p.DestinationAddress}");
                    }
                    break;

                case 5:
                    var delayed = manager.GetDelayedPackages();
                    if (delayed.Count == 0)
                    {
                        Console.WriteLine("No delayed packages.");
                    }
                    else
                    {
                        foreach (var p in delayed)
                        {
                            Console.WriteLine(
                                $"{p.TrackingNumber} - {p.DestinationAddress}");
                        }
                    }
                    break;

                case 6:
                    foreach (var p in manager.GetAllPackages())
                    {
                        Console.WriteLine(
                            $"{p.TrackingNumber} | {p.PackageType} | {p.DestinationAddress}");
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
