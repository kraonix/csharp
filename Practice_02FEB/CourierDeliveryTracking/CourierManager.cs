using System;
using System.Collections.Generic;
using System.Linq;

public class CourierManager
{
    private readonly List<Package> _packages = new();
    private readonly List<DeliveryStatus> _statuses = new();
    private int _trackingCounter = 1;

    // Add Package
    public void AddPackage(string sender, string receiver, string address,
                           double weight, string type, double cost)
    {
        string tracking = $"TRK{_trackingCounter:D4}";
        _trackingCounter++;

        _packages.Add(new Package
        {
            TrackingNumber = tracking,
            SenderName = sender,
            ReceiverName = receiver,
            DestinationAddress = address,
            Weight = weight,
            PackageType = type,
            ShippingCost = cost
        });

        _statuses.Add(new DeliveryStatus
        {
            TrackingNumber = tracking,
            CurrentStatus = "Dispatched",
            EstimatedDelivery = DateTime.Now.AddDays(5)
        });
    }

    // Update Delivery Status
    public bool UpdateStatus(string trackingNumber, string status,
                             string checkpoint)
    {
        var delivery = _statuses.FirstOrDefault(s => s.TrackingNumber == trackingNumber);
        if (delivery == null)
            return false;

        delivery.CurrentStatus = status;
        delivery.Checkpoints.Add(checkpoint);

        if (status == "Delivered")
            delivery.ActualDelivery = DateTime.Now;

        return true;
    }

    // Group Packages by Type
    public Dictionary<string, List<Package>> GroupPackagesByType()
    {
        return _packages
            .GroupBy(p => p.PackageType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Packages by Destination City
    public List<Package> GetPackagesByDestination(string city)
    {
        return _packages
            .Where(p => p.DestinationAddress
                .Contains(city, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Delayed Packages
    public List<Package> GetDelayedPackages()
    {
        var delayedTracking = _statuses
            .Where(s => s.CurrentStatus != "Delivered"
                        && DateTime.Now > s.EstimatedDelivery)
            .Select(s => s.TrackingNumber)
            .ToList();

        return _packages
            .Where(p => delayedTracking.Contains(p.TrackingNumber))
            .ToList();
    }

    // Helpers for menu
    public List<Package> GetAllPackages() => _packages;
    public List<DeliveryStatus> GetAllStatuses() => _statuses;
}
