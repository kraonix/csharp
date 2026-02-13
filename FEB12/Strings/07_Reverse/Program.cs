class Program
{
    static string Reverse(string input)
    {
        return new string(input.Reverse().ToArray());
    }
    
    static void Main()
    {
        Console.WriteLine(Reverse(Console.ReadLine()));
    }
}
