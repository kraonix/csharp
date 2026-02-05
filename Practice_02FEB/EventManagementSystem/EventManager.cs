using System;
using System.Collections.Generic;
using System.Linq;

public class EventManager
{
    private readonly List<Event> _events = new();
    private readonly List<Attendee> _attendees = new();
    private readonly List<Ticket> _tickets = new();

    private int _eventIdCounter = 1;
    private int _attendeeIdCounter = 1;

    // Create Event
    public void CreateEvent(string name, string type, DateTime date,
                            string venue, int capacity, double price)
    {
        _events.Add(new Event
        {
            EventId = _eventIdCounter++,
            EventName = name,
            EventType = type,
            EventDate = date,
            Venue = venue,
            TotalCapacity = capacity,
            TicketsSold = 0,
            TicketPrice = price
        });
    }

    // Add Attendee (helper)
    public int AddAttendee(string name, string email, string phone)
    {
        var attendee = new Attendee
        {
            AttendeeId = _attendeeIdCounter++,
            Name = name,
            Email = email,
            Phone = phone
        };

        _attendees.Add(attendee);
        return attendee.AttendeeId;
    }

    // Book Ticket
    public bool BookTicket(int eventId, int attendeeId, string seatNumber)
    {
        var ev = _events.FirstOrDefault(e => e.EventId == eventId);
        var attendee = _attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);

        if (ev == null || attendee == null)
            return false;

        if (ev.TicketsSold >= ev.TotalCapacity)
            return false;

        ev.TicketsSold++;

        attendee.RegisteredEvents.Add(eventId);

        _tickets.Add(new Ticket
        {
            TicketNumber = Guid.NewGuid().ToString().Substring(0, 8),
            EventId = eventId,
            AttendeeId = attendeeId,
            PurchaseDate = DateTime.Now,
            SeatNumber = seatNumber
        });

        return true;
    }

    // Group Events by Type
    public Dictionary<string, List<Event>> GroupEventsByType()
    {
        return _events
            .GroupBy(e => e.EventType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Upcoming Events
    public List<Event> GetUpcomingEvents(int days)
    {
        DateTime limit = DateTime.Now.AddDays(days);
        return _events
            .Where(e => e.EventDate >= DateTime.Now && e.EventDate <= limit)
            .ToList();
    }

    // Event Revenue
    public double CalculateEventRevenue(int eventId)
    {
        var ev = _events.FirstOrDefault(e => e.EventId == eventId);
        if (ev == null)
            return 0;

        return ev.TicketsSold * ev.TicketPrice;
    }

    // Helpers for menu
    public List<Event> GetAllEvents() => _events;
    public List<Attendee> GetAllAttendees() => _attendees;
}
