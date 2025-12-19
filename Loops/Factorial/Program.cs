class Factorial
{
    /// <summary>
    /// Program for calculating the factorial of a number.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        // Input a number
        Console.Write("Enter a number to compute its factorial: ");
        int number = int.Parse(Console.ReadLine());

        // Initialize factorial result
        long factorial = 1;

        // Calculate factorial using a loop
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        // Output the result
        Console.WriteLine($"Factorial of {number} is {factorial}");
    }
}