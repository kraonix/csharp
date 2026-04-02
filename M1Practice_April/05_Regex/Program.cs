using System.Text.RegularExpressions;

class Regex05
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string result = Regex.Replace(input, @"\s", @"_");
        Console.WriteLine(result);
    }
}