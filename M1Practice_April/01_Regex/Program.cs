using System.Text.RegularExpressions;

public class Rexex01
{
    public static void Main()
    {
        string input = Console.ReadLine();
        bool result = Regex.IsMatch(input, @"^[0-9]+$");
        Console.WriteLine(result);
    }
}