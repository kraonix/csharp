
public class Program
{
    /// <summary>
    /// Prints the multiplication table of a given number up to a specified limit.
    /// </summary>
    /// <param name="number"></param>
    /// <param name="upto"></param>
    public static void MultiplicationTable(int number, int upto)
    {
        // Print multiplication table
        foreach(var i in Enumerable.Range (1, upto - 1))
        {
            Console.Write($"{i * number}, ");
        }
        Console.Write($"{upto * number}");
    }
    public static void Main(string[] args)
    {
        // Example usage
        Console.Write("Enter a Number : ");
        int Number = int.Parse(Console.ReadLine());
        Console.Write("Multiplication Table upto : ");
        int Upto = int.Parse(Console.ReadLine());
        Console.WriteLine();

        // Display multiplication table
        Console.Write($"Multiplication Table of {Number}, upto {Upto} : ");
        MultiplicationTable(Number, Upto);
    }
}
