using System.Text.RegularExpressions;

public class Regex02
{
    public static void Main()
    {
        string name = Console.ReadLine();
        bool result = Regex.IsMatch(name, @"^[A-Z][a-z]+$");
        Console.WriteLine(result);
    }
}