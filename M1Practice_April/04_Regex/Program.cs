using System.Text.RegularExpressions;

public class Regex04
{
    public static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"[0-9]+");

        foreach(Match i in matches)
        {
            Console.Write(i + " ");
        }
    }
}