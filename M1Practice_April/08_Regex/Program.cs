using System.Text.RegularExpressions;

class Regex08
{
    public static void Main()
    {
        string input = Console.ReadLine();
        bool result = Regex.IsMatch(input, @"^[a-zA-z0-9]+@[a-z]+\.[a-z]{2,3}");
        Console.WriteLine(result);
    }
}