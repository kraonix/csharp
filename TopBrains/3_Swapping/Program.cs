using System;

namespace Swapping
{
    public class Program
    {
        // Method to swap two numbers using ref
        // ref requires variables to be initialized before passing
        static void SwapRef(ref int a, ref int b)
        {
            // Swap logic without using a temporary variable
            a = a + b;
            b = a - b;
            a = a - b;
        }

        // Method to swap two numbers using out
        // out parameters do not require initialization before passing
        static void SwapOut(int a, int b, out int x, out int y)
        {
            // Swap logic without using a temporary variable
            a = a + b;
            b = a - b;
            a = a - b;

            // Assign swapped values to out parameters
            x = a;
            y = b;
        }

        public static void Main()
        {
            // Taking input for ref swap
            Console.WriteLine("Enter x: ");
            int x = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter y: ");
            int y = int.Parse(Console.ReadLine()!);

            // Display values before ref swap
            Console.WriteLine("Before Swap using ref:");
            Console.WriteLine($"x = {x}, y = {y}");

            // Calling ref swap method
            SwapRef(ref x, ref y);

            // Display values after ref swap
            Console.WriteLine("After Swap using ref:");
            Console.WriteLine($"x = {x}, y = {y}");

            Console.WriteLine();

            // Taking input for out swap
            Console.WriteLine("Enter a: ");
            int a = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter b: ");
            int b = int.Parse(Console.ReadLine()!);

            // Display values before out swap
            Console.WriteLine("Before Swap using out:");
            Console.WriteLine($"a = {a}, b = {b}");

            // Declaring variables for out parameters
            int p, q;

            // Calling out swap method
            SwapOut(a, b, out p, out q);

            // Display values after out swap
            Console.WriteLine("After Swap using out:");
            Console.WriteLine($"a = {p}, b = {q}");
        }
    }
}
