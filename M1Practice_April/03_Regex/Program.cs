using System.Text.RegularExpressions;

public class Regex03
{
    public static void Main()
    {
        string name = Console.ReadLine();
        bool result = Regex.IsMatch(name, @"^[A][a-z]+$");
        Console.WriteLine(result);
    }
}