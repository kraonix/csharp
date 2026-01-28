using System;
using System.Collections.Generic;

class Apartment
{
    private Dictionary<string, double> apartmentDetailsMap = new Dictionary<string, double>();

    // Getter and Setter
    public Dictionary<string, double> ApartmentDetailsMap
    {
        get { return apartmentDetailsMap; }
        set { apartmentDetailsMap = value; }
    }

    // Requirement 1
    public void addApartmentDetails(string apartmentNumber, double rent)
    {
        apartmentDetailsMap[apartmentNumber] = rent;
    }

    // Requirement 2
    public double findTotalRentOfApartmentsInTheGivenRange(double minimumRent, double maximumRent)
    {
        double total = 0;

        foreach (var entry in apartmentDetailsMap)
        {
            if (entry.Value >= minimumRent && entry.Value <= maximumRent)
            {
                total += entry.Value;
            }
        }

        return total;
    }
}

class UserInterface
{
    public static void Main(string[] args)
    {
        Apartment apartment = new Apartment();

        Console.WriteLine("Enter number of details to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the details (Apartment number: Rent)");

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            string apartmentNumber = parts[0];
            double rent = double.Parse(parts[1]);

            apartment.addApartmentDetails(apartmentNumber, rent);
        }

        Console.WriteLine("Enter the range to filter the details");
        double minRent = double.Parse(Console.ReadLine());
        double maxRent = double.Parse(Console.ReadLine());

        double totalRent =
            apartment.findTotalRentOfApartmentsInTheGivenRange(minRent, maxRent);

        Console.WriteLine(
            $"Total Rent in the range {minRent}.0 to {maxRent}.0 USD:{totalRent}.0"
        );
    }
}
