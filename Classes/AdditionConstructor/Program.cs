class AdditionConstructor
{
    /// <summary>
    /// Addition inside a Constructor
    /// </summary>
    public int Number1 {get; set;}
    public int Number2 {get; set;}

    public int Sum {get;}

    public AdditionConstructor(int a, int b) // Parameterized Constructor
    {
        this.Number1 = a;
        this.Number2 = b;

        this.Sum = Number1 + Number2;

        Console.WriteLine($"{Number1} + {Number2} = {Sum}\n");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Two Numbers: ");
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());

        AdditionConstructor add = new AdditionConstructor(n1, n2);
    }
}