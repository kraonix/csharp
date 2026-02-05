using System;
using System.Collections.Generic;
using System.Linq;

public class AirlineManager
{
    private readonly List<Flight> _flights = new();
    private readonly List<Booking> _bookings = new();

    // Add Flight
    public void AddFlight(string number, string origin, string destination,
                          DateTime depart, DateTime arrive,
                          int seats, double price)
    {
        _flights.Add(new Flight
        {
            FlightNumber = number,
            Origin = origin,
            Destination = destination,
            DepartureTime = depart,
            ArrivalTime = arrive,
            TotalSeats = seats,
            AvailableSeats = seats,
            TicketPrice = price
        });
    }

    // Book Flight
    public bool BookFlight(string flightNumber, string passenger,
                           int seats, string seatClass)
    {
        var flight = _flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        if (flight == null || seats <= 0 || seats > flight.AvailableSeats)
            return false;

        double multiplier = seatClass == "Business" ? 1.5 : 1.0;
        double fare = seats * flight.TicketPrice * multiplier;

        flight.AvailableSeats -= seats;

        _bookings.Add(new Booking
        {
            BookingId = Guid.NewGuid().ToString().Substring(0, 8),
            FlightNumber = flightNumber,
            PassengerName = passenger,
            SeatsBooked = seats,
            SeatClass = seatClass,
            TotalFare = fare
        });

        return true;
    }

    // Group Flights by Destination
    public Dictionary<string, List<Flight>> GroupFlightsByDestination()
    {
        return _flights
            .GroupBy(f => f.Destination)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Search Flights
    public List<Flight> SearchFlights(string origin, string destination,
                                      DateTime date)
    {
        return _flights
            .Where(f =>
                f.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase) &&
                f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase) &&
                f.DepartureTime.Date == date.Date)
            .ToList();
    }

    // Calculate Revenue
    public double CalculateTotalRevenue(string flightNumber)
    {
        return _bookings
            .Where(b => b.FlightNumber == flightNumber)
            .Sum(b => b.TotalFare);
    }

    // Helpers for menu
    public List<Flight> GetAllFlights() => _flights;
}
