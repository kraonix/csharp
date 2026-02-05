using System;
using System.Collections.Generic;
using System.Linq;
namespace CarRentalSystem
{
    class RentalManager
{
    private List<RentalCar> cars = new List<RentalCar>();
    private List<Rental> rentals = new List<Rental>();
    private int rentalIdCounter = 1;

    public void AddCar(string license, string make, string model, string type, double rate)
    {
        cars.Add(new RentalCar
        {
            LicensePlate = license,
            Make = make,
            Model = model,
            CarType = type,
            DailyRate = rate
        });
    }

    public bool RentCar(string license, string customer, DateTime start, int days)
    {
        RentalCar car = cars.FirstOrDefault(c => c.LicensePlate == license && c.IsAvailable);
        if (car == null)
            return false;

        car.IsAvailable = false;

        rentals.Add(new Rental
        {
            RentalId = rentalIdCounter++,
            LicensePlate = license,
            CustomerName = customer,
            StartDate = start,
            EndDate = start.AddDays(days),
            TotalCost = days * car.DailyRate
        });

        return true;
    }

    public Dictionary<string, List<RentalCar>> GroupCarsByType()
    {
        return cars.Where(c => c.IsAvailable)
                   .GroupBy(c => c.CarType)
                   .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Rental> GetActiveRentals()
    {
        return rentals.Where(r => r.EndDate >= DateTime.Now).ToList();
    }

    public double CalculateTotalRentalRevenue()
    {
        return rentals.Sum(r => r.TotalCost);
    }

    public List<RentalCar> GetAllCars() => cars;
}
}