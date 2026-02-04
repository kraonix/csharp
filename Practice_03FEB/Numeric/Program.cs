using System;
class InputHandler
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter a number: ");
                int number=int.Parse(Console.ReadLine());
                Console.WriteLine($"Valid number: {number}");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, try again");
            }
        }
    }
}