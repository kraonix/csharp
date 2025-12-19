class Fibonacci
{
    /// <summary>
    /// Program for generating Fibonacci series.
    /// </summary>
    /// <param name="afaw"></param>
    public static void Main(String[] afaw)
    {
        // Initialize the first two terms
        int a = 0, b = 1, c, i, number;
        Console.Write("Enter the number of terms: ");
        number = int.Parse(Console.ReadLine());

        // Print the Fibonacci series
        Console.WriteLine("Fibonacci Series:");
        for (i = 0; i < number; i++)
        {
            Console.Write(a + " ");
            c = a + b;
            a = b;
            b = c;
        }
    }
}