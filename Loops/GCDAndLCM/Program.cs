class GCDAndLCM
{
    // Function to compute GCD using Euclidean algorithm
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Function to compute LCM
    static int LCM(int a, int b)
    {
        return (a / GCD(a, b)) * b;
    }

    /// <summary>
    /// Program for calculating GCD and LCM of two numbers.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        // Input two numbers
        Console.WriteLine("Enter two numbers:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        // Calculate GCD and LCM
        int gcd = GCD(num1, num2);
        int lcm = LCM(num1, num2);

        Console.WriteLine($"GCD: {gcd}");
        Console.WriteLine($"LCM: {lcm}");
    }
}