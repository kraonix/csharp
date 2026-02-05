using System;

class Program
{
    static void Main()
    {
        AirlineManager manager = new AirlineManager();

        // -------- Hardcoded Initial Data --------
        manager.AddFlight("AI101", "Delhi", "Mumbai",
            DateTime.Now.AddHours(3),
            DateTime.Now.AddHours(5),
            180, 5500);

        manager.AddFlight("AI202", "Delhi", "Bangalore",
            DateTime.Now.AddHours(4),
            DateTime.Now.AddHours(7),
            150, 6200);

        manager.AddFlight("AI303", "Mumbai", "Delhi",
            DateTime.Now.AddHours(6),
            DateTime.Now.AddHours(8),
            200, 5400);
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nFLIGHT BOOKING SYSTEM");
            Console.WriteLine("1. Add Flight");
            Console.WriteLine("2. Book Flight");
            Console.WriteLine("3. Search Flights");
            Console.WriteLine("4. Group Flights by Destination");
            Console.WriteLine("5. Calculate Flight Revenue");
            Console.WriteLine("6. View All Flights");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Flight Number: ");
                    string number = Console.ReadLine();

                    Console.Write("Origin: ");
                    string origin = Console.ReadLine();

                    Console.Write("Destination: ");
                    string destination = Console.ReadLine();

                    Console.Write("Departure (yyyy-mm-dd hh:mm): ");
                    DateTime depart = DateTime.Parse(Console.ReadLine());

                    Console.Write("Arrival (yyyy-mm-dd hh:mm): ");
                    DateTime arrive = DateTime.Parse(Console.ReadLine());

                    Console.Write("Total Seats: ");
                    int seats = int.Parse(Console.ReadLine());

                    Console.Write("Ticket Price: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.AddFlight(number, origin, destination,
                        depart, arrive, seats, price);

                    Console.WriteLine("Flight added successfully.");
                    break;

                case 2:
                    Console.Write("Flight Number: ");
                    string fno = Console.ReadLine();

                    Console.Write("Passenger Name: ");
                    string passenger = Console.ReadLine();

                    Console.Write("Seats to book: ");
                    int bookSeats = int.Parse(Console.ReadLine());

                    Console.Write("Seat Class (Economy/Business): ");
                    string seatClass = Console.ReadLine();

                    Console.WriteLine(manager.BookFlight(fno, passenger, bookSeats, seatClass)
                        ? "Booking successful."
                        : "Booking failed.");
                    break;

                case 3:
                    Console.Write("Origin: ");
                    string so = Console.ReadLine();

                    Console.Write("Destination: ");
                    string sd = Console.ReadLine();

                    Console.Write("Date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    var results = manager.SearchFlights(so, sd, date);
                    foreach (var f in results)
                    {
                        Console.WriteLine(
                            $"{f.FlightNumber} | {f.DepartureTime} | Seats Left: {f.AvailableSeats}");
                    }
                    break;

                case 4:
                    var grouped = manager.GroupFlightsByDestination();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nDestination: {g.Key}");
                        foreach (var f in g.Value)
                            Console.WriteLine($"{f.FlightNumber} from {f.Origin}");
                    }
                    break;

                case 5:
                    Console.Write("Flight Number: ");
                    string revFlight = Console.ReadLine();

                    double revenue = manager.CalculateTotalRevenue(revFlight);
                    Console.WriteLine($"Total Revenue: {revenue}");
                    break;

                case 6:
                    foreach (var f in manager.GetAllFlights())
                    {
                        Console.WriteLine(
                            $"{f.FlightNumber} | {f.Origin} -> {f.Destination} | Seats: {f.AvailableSeats}/{f.TotalSeats}");
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
