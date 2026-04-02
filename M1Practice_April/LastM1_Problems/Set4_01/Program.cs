using System.Text.RegularExpressions;

public class Set4_01
{
    public static bool Validator(string input)
    {
        return Regex.IsMatch(input, @"^[a-z]{3,}\.[a-z]{3,}[0-9]{4,}\@(hr|it|finance|admin)\.company\.com$");
    }
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string input = "";
        for(int i = 0; i < N; i++)
        {
            input = Console.ReadLine();
            if (Validator(input))
            {
                Console.WriteLine("VALID");
            }
            else
            {
                Console.WriteLine("INVALID");
            }
        }
    }
}