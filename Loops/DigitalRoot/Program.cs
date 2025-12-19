class DigitalRoot
{
    // Method to compute the Digital Root of a number
    public static int Compute(int n)
    {
        while (n >= 10) // Continue until n is a single digit
        {
            int sum = 0;
            while (n > 0) // Sum the digits of n
            {
                sum += n % 10;
                n /= 10;
            }
            n = sum; // Update n to the sum of its digits
        }
        return n;
    }

    /// <summary>
    /// Program for calculating the Digital Root of a number.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(String[] args)
    {
        // Input a number
        Console.Write("Enter a number to find its Digital Root: ");
        int number = int.Parse(Console.ReadLine());

        int digitalRoot = Compute(number); // Calculate Digital Root
        Console.WriteLine($"The Digital Root of {number} is: {digitalRoot}");
    }
}