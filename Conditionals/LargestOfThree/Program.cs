class LargetOfThree
{
    public static void Main(string[] args)
    {
        // Input three numbers
        Console.WriteLine("Enter three numbers:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        // Determine and print the largest number
        if(a > b && a > c)
            Console.WriteLine(a);
        else if(b > a && b > c)
            Console.WriteLine(b);
        else
            Console.WriteLine(c);

    }
}