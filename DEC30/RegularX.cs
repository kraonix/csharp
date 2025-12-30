using System;
namespace RegularX
{
    // Validate email address using regular expression
    class RegularExpression
    {
        public static void Main(string[] args)
        {
            string? input = Console.ReadLine();
            // Regular expression pattern for validating email addresses
            if (input != null && System.Text.RegularExpressions.Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Console.WriteLine("Valid email address.");
            }
            else
            {
                Console.WriteLine("Invalid email address.");
            }
        }
    }
}