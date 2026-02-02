using System;

class Program
{
    // Method to calculate the area of a circle for a given radius
    static double CalculateCircleArea(double radius)
    {
        // Area formula: π * r * r
        double area = Math.PI * radius * radius;
        // Round the result to 2 decimal places
        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        double radius = 5.5;

        double result = CalculateCircleArea(radius);
        Console.WriteLine(result);
    }
}
