using System;
using System.Collections.Generic;

public class TicketService
{
    private Dictionary<int, Seat> _seats;
    
    // Lock object (important)
    private readonly object _lockObject = new object();

    public TicketService(int totalSeats)
    {
        _seats = new Dictionary<int, Seat>();

        for (int i = 1; i <= totalSeats; i++)
        {
            _seats[i] = new Seat
            {
                SeatNo = i,
                IsBooked = false
            };
        }
    }

    public bool BookSeat(int seatNo, string userId)
    {
        // Critical Section
        lock (_lockObject)
        {
            if (!_seats.ContainsKey(seatNo))
                return false;

            var seat = _seats[seatNo];

            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            seat.BookedBy = userId;

            return true;
        }
    }
}
