using System;
using System.Collections.Generic;
using System.Linq;
namespace CarRentalSystem
{
    class RentalCar
{
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string CarType { get; set; }
    public bool IsAvailable { get; set; } = true;
    public double DailyRate { get; set; }
}
}