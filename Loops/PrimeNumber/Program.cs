class PrimeNumber
{
    /// <summary>
    /// Program for checking prime numbers.
    /// </summary>
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        bool isPrime = true;

        if (number < 2)
        {
            isPrime = false; // Numbers less than 2 are not prime
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(number); i++) // Check up to the square root of the number
            {
                if (number % i == 0) // Check for factors
                {
                    isPrime = false;
                    break;
                }
            }
        }

        Console.WriteLine(isPrime ? $"{number} is prime" : $"{number} is not prime"); // Output result
    }
}