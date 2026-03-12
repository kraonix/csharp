using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
public partial class Program
{
    public static void Main()
    {
        // MatchCollection m = Regex.Matches("123Order122343", @"\d+");
        // foreach (Match i in m)
        // {
        //     Console.WriteLine(i.Value);
        // }

        // string mail = "sachin@gmail.com";
        // Match m = Regex.Match(mail, @"^\w+@(gmail|outlook)\.\w+$");
        // Console.WriteLine(m.Success);

        //Q1 Only Digits
        // Match m = Regex.Match("1234", @"^\d+$");
        // Console.WriteLine(m.Success);

        //Q2 Only Alphabets
        // Match m = Regex.Match("asdf", @"^[a-zA-Z]+$");
        // Console.WriteLine(m.Success);

        //Q3 Username Validation
        // Match m = Regex.Match("asd234f", @"^\D[a-zA-Z0-9]+$");
        // Console.WriteLine(m.Success);

        //Q4 All Numbers from a String
        // MatchCollection m = Regex.Matches("123Order122343", @"\d+");
        // foreach (Match i in m)
        // {
        //     Console.WriteLine(i.Value);
        // }

        //Q5 Mail
        // string mail = "sachin@gmail.com";
        // Match m = Regex.Match(mail, @"^\w+@(gmail|outlook)\.\w+$");
        // Console.WriteLine(m.Success);

        //Q6 Phone Number Validation
        // Match m = Regex.Match("9989893890", @"^\d{10}$");
        // Console.WriteLine(m.Success);

        //Q7 Password Validation
        Match m = Regex.Match("Sa@978070", @"^[A-Za-z0-9`~!@#$%^&*()_]+$");
        Console.WriteLine(m.Success);
    }
}