using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieBooking
{
    class Program
    {
        static void Main()
        {
            TheaterManager manager = new TheaterManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MOVIE THEATER BOOKING SYSTEM ===");
                Console.WriteLine("1. Add Screening");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. View Screenings Grouped by Movie");
                Console.WriteLine("4. View Available Screenings");
                Console.WriteLine("5. Calculate Total Revenue");
                Console.WriteLine("6. View All Screenings");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Movie Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Show Time (yyyy-MM-dd HH:mm): ");
                            DateTime time = DateTime.Parse(Console.ReadLine());

                            Console.Write("Screen Number: ");
                            string screen = Console.ReadLine();

                            Console.Write("Total Seats: ");
                            int seats = int.Parse(Console.ReadLine());

                            Console.Write("Ticket Price: ");
                            double price = double.Parse(Console.ReadLine());

                            manager.AddScreening(title, time, screen, seats, price);
                            Console.WriteLine("Screening added successfully");
                            break;

                        case 2:
                            Console.Write("Movie Title: ");
                            string bookTitle = Console.ReadLine();

                            Console.Write("Show Time (yyyy-MM-dd HH:mm): ");
                            DateTime bookTime = DateTime.Parse(Console.ReadLine());

                            Console.Write("Number of Tickets: ");
                            int tickets = int.Parse(Console.ReadLine());

                            bool success = manager.BookTickets(bookTitle, bookTime, tickets);
                            Console.WriteLine(success ? "Tickets booked successfully" : "Not enough seats available");
                            break;

                        case 3:
                            var grouped = manager.GroupScreeningsByMovie();
                            foreach (var g in grouped)
                            {
                                Console.WriteLine($"\nMovie: {g.Key}");
                                foreach (var s in g.Value)
                                    Console.WriteLine($"{s.ShowTime} | Screen {s.ScreenNumber} | Available: {s.AvailableSeats}");
                            }
                            break;

                        case 4:
                            Console.Write("Minimum seats required: ");
                            int minSeats = int.Parse(Console.ReadLine());

                            var available = manager.GetAvailableScreenings(minSeats);
                            foreach (var s in available)
                                Console.WriteLine($"{s.MovieTitle} | {s.ShowTime} | Seats: {s.AvailableSeats}");
                            break;

                        case 5:
                            Console.WriteLine("Total Revenue: " + manager.CalculateTotalRevenue());
                            break;

                        case 6:
                            foreach (var s in manager.GetAllScreenings())
                                Console.WriteLine($"{s.MovieTitle} | {s.ShowTime} | Screen {s.ScreenNumber} | Booked: {s.BookedSeats}");
                            break;

                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
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