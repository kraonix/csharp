class Program
{
    /// <summary>
    /// GCD of two Integers 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> GCD of a and b </returns>
    public static int GCD(int a, int b)
    {
        int Larger = a > b ? a : b;
        int Smaller = a < b ? a : b;

        if (Smaller == 0) 
            return Larger;
        else
            return GCD(Smaller, Larger % Smaller);
    }
    public static void Main(string[] args)
    {
        //Main Method
        Console.Write("Enter Two Integers : ");
        int First = int.Parse(Console.ReadLine());
        int Second = int.Parse(Console.ReadLine());

        int Gcd = GCD(First, Second);
        Console.WriteLine($"Greatest Common Divisor of {First} and {Second} is: {Gcd}");
    }
}