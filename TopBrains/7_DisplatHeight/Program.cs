using System;
namespace DisplayHeight
{
    public class Program
    {
        // Method to determine height category based on given height
        static string HeightCategory(int height)
        {
            // If height is less than 150 cm, category is Short
            if (height < 150)
            {
                return "Short";
            }
            // If height is between 150 cm and 179 cm, category is Average
            else if (height >= 150 && height < 180)
            {
                return "Average";
            }
            // If height is 180 cm or more, category is Tall
            else
            {
                return "Tall";
            }
        }
        static void Main()
        {
            // Ask the user to enter height in centimeters
            Console.WriteLine("Enter the height in cm: ");

            // Read height input from user
            int height = int.Parse(Console.ReadLine()!);

            // Call method to get height category
            string category = HeightCategory(height);

            // Display the height category
            Console.WriteLine(category);
        }
    }
}
