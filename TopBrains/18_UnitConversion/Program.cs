using System;

namespace UnitConversion
{
    public class Program
    {
        // User-defined method to convert feet to centimeters
        static double ConvertFeetToCentimeters(int feet)
        {
            // Conversion factor: 1 foot = 30.48 cm
            double centimeters = feet * 30.48;

            // Round result to 2 decimal places (AwayFromZero)
            return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
        }

        // Main method – program execution starts here
        static void Main()
        {
            // Ask user to enter feet value
            Console.WriteLine("Enter value in feet");
            int feet = int.Parse(Console.ReadLine());

            // Call user-defined conversion method
            double result = ConvertFeetToCentimeters(feet);

            // Display the result
            Console.WriteLine("Centimeters: " + result);
        }
    }
}
