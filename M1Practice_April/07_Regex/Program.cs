using System.Text.RegularExpressions;

class Regex07
{
    public static void Main()
    {
        string input = Console.ReadLine();
        bool result = Regex.IsMatch(input, @"^[6789][0-9]{9}$");
        Console.WriteLine(result);
    }
}