using System;
using System.Collections.Generic;
using System.Linq;

public class RealEstateManager
{
    private readonly List<Property> _properties = new();
    private readonly List<Client> _clients = new();
    private readonly List<Viewing> _viewings = new();

    private int _clientCounter = 1;
    private int _viewingCounter = 1;
    private int _propertyCounter = 1;

    // Add Property
    public void AddProperty(string address, string type, int bedrooms,
                            double area, double price, string owner)
    {
        _properties.Add(new Property
        {
            PropertyId = $"PR{_propertyCounter:D3}",
            Address = address,
            PropertyType = type,
            Bedrooms = bedrooms,
            AreaSqFt = area,
            Price = price,
            Status = "Available",
            Owner = owner
        });
        _propertyCounter++;
    }

    // Add Client
    public void AddClient(string name, string contact, string type,
                          double budget, List<string> requirements)
    {
        _clients.Add(new Client
        {
            ClientId = _clientCounter++,
            Name = name,
            Contact = contact,
            ClientType = type,
            Budget = budget,
            Requirements = requirements
        });
    }

    // Schedule Viewing
    public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
    {
        var property = _properties.FirstOrDefault(p => p.PropertyId == propertyId);
        var client = _clients.FirstOrDefault(c => c.ClientId == clientId);

        if (property == null || client == null || property.Status != "Available")
            return false;

        _viewings.Add(new Viewing
        {
            ViewingId = _viewingCounter++,
            PropertyId = propertyId,
            ClientId = clientId,
            ViewingDate = date
        });

        return true;
    }

    // Group Properties by Type
    public Dictionary<string, List<Property>> GroupPropertiesByType()
    {
        return _properties
            .GroupBy(p => p.PropertyType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Properties in Budget
    public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
    {
        return _properties
            .Where(p => p.Price >= minPrice &&
                        p.Price <= maxPrice &&
                        p.Status == "Available")
            .ToList();
    }

    // Helpers for menu
    public List<Property> GetAllProperties() => _properties;
    public List<Client> GetAllClients() => _clients;
}
