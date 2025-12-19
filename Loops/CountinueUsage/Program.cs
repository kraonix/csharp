class CountinueUsage
{
    /// <summary>
    /// Program to demonstrate the use of 'continue' statement.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        for (int i = 1; i <= 50; i++) // Loop from 1 to 50
        {
            if (i % 3 == 0) // Check if the number is a multiple of 3
            {
                continue; // Skip multiples of 3
            }
            Console.WriteLine(i + " "); // Print only numbers not divisible by 3
        }
    }
}