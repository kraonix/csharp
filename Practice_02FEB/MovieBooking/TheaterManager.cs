using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieBooking
{
    class TheaterManager
    {
        private List<MovieScreening> screenings = new List<MovieScreening>();

        public void AddScreening(string title, DateTime time, string screen, int seats, double price)
        {
            screenings.Add(new MovieScreening
            {
                MovieTitle = title,
                ShowTime = time,
                ScreenNumber = screen,
                TotalSeats = seats,
                TicketPrice = price,
                BookedSeats = 0
            });
        }

        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            MovieScreening screening = screenings.FirstOrDefault(
                s => s.MovieTitle.Equals(movieTitle, StringComparison.OrdinalIgnoreCase)
                  && s.ShowTime == showTime
            );

            if (screening == null)
                throw new Exception("Screening not found");

            if (screening.AvailableSeats < tickets)
                return false;

            screening.BookedSeats += tickets;
            return true;
        }

        public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
        {
            return screenings
                .GroupBy(s => s.MovieTitle)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public double CalculateTotalRevenue()
        {
            return screenings.Sum(s => s.BookedSeats * s.TicketPrice);
        }

        public List<MovieScreening> GetAvailableScreenings(int minSeats)
        {
            return screenings
                .Where(s => s.AvailableSeats >= minSeats)
                .OrderBy(s => s.ShowTime)
                .ToList();
        }

        public List<MovieScreening> GetAllScreenings()
        {
            return screenings;
        }
    }

}