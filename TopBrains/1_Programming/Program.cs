using System;
namespace Programmining
{
    public class Program
    {
        // Method to calculate sum of digits of a number
        static int SumOfDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
        // Method to check whether a number is prime
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static void Main()
        {
            Console.WriteLine("Enter m: ");
            int m = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine()!);
            int count = 0;
            // Loop through numbers from m to n (inclusive)
            for (int x = m; x <= n; x++)
            {
                // Check only non-prime positive integers
                if (!IsPrime(x) && x > 0)
                {
                    int sX = SumOfDigits(x);
                    int sXSquared = SumOfDigits(x * x);

                    // Check Lucky Number condition
                    if (sXSquared == sX * sX)
                    {
                        count++;
                    }
                }
            }
            // Output the result
            Console.WriteLine(count);
        }
    }
}
