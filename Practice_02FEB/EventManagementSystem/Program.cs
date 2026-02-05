using System;

class Program
{
    static void Main()
    {
        EventManager manager = new EventManager();

        // -------- Hardcoded Initial Data --------
        manager.CreateEvent("Rock Night", "Concert",
            DateTime.Now.AddDays(5), "City Arena", 200, 1500);

        manager.CreateEvent("Tech Summit", "Conference",
            DateTime.Now.AddDays(15), "Convention Hall", 300, 2500);

        manager.CreateEvent("Photography Basics", "Workshop",
            DateTime.Now.AddDays(8), "Studio A", 50, 1200);

        int a1 = manager.AddAttendee("Rahul Sharma", "rahul@mail.com", "9876543210");
        int a2 = manager.AddAttendee("Neha Verma", "neha@mail.com", "9123456780");
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nEVENT MANAGEMENT SYSTEM");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Add Attendee");
            Console.WriteLine("3. Book Ticket");
            Console.WriteLine("4. Group Events by Type");
            Console.WriteLine("5. View Upcoming Events");
            Console.WriteLine("6. Calculate Event Revenue");
            Console.WriteLine("7. View All Events");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Event Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Event Type (Concert/Conference/Workshop): ");
                    string type = Console.ReadLine();

                    Console.Write("Event Date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Venue: ");
                    string venue = Console.ReadLine();

                    Console.Write("Total Capacity: ");
                    int cap = int.Parse(Console.ReadLine());

                    Console.Write("Ticket Price: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.CreateEvent(name, type, date, venue, cap, price);
                    Console.WriteLine("Event created successfully.");
                    break;

                case 2:
                    Console.Write("Name: ");
                    string aname = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();

                    int aid = manager.AddAttendee(aname, email, phone);
                    Console.WriteLine($"Attendee added with ID: {aid}");
                    break;

                case 3:
                    Console.WriteLine("Available Events:");
                    foreach (var e in manager.GetAllEvents())
                        Console.WriteLine($"{e.EventId} - {e.EventName}");

                    Console.Write("Event ID: ");
                    int eid = int.Parse(Console.ReadLine());

                    Console.WriteLine("Attendees:");
                    foreach (var a in manager.GetAllAttendees())
                        Console.WriteLine($"{a.AttendeeId} - {a.Name}");

                    Console.Write("Attendee ID: ");
                    int attId = int.Parse(Console.ReadLine());

                    Console.Write("Seat Number: ");
                    string seat = Console.ReadLine();

                    Console.WriteLine(manager.BookTicket(eid, attId, seat)
                        ? "Ticket booked successfully."
                        : "Ticket booking failed.");
                    break;

                case 4:
                    var grouped = manager.GroupEventsByType();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nType: {g.Key}");
                        foreach (var e in g.Value)
                            Console.WriteLine($"{e.EventId} - {e.EventName}");
                    }
                    break;

                case 5:
                    Console.Write("Enter number of days: ");
                    int days = int.Parse(Console.ReadLine());

                    var upcoming = manager.GetUpcomingEvents(days);
                    foreach (var e in upcoming)
                    {
                        Console.WriteLine(
                            $"{e.EventName} on {e.EventDate:d} at {e.Venue}");
                    }
                    break;

                case 6:
                    Console.Write("Event ID: ");
                    int revId = int.Parse(Console.ReadLine());

                    double revenue = manager.CalculateEventRevenue(revId);
                    Console.WriteLine($"Total Revenue: {revenue}");
                    break;

                case 7:
                    foreach (var e in manager.GetAllEvents())
                    {
                        Console.WriteLine(
                            $"{e.EventId} - {e.EventName} | Sold: {e.TicketsSold}/{e.TotalCapacity}");
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
