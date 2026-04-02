using System.Text.RegularExpressions;

class Regex06
{
    public static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, "[aeiou]");
        Console.WriteLine(matches.Count);
    }
}