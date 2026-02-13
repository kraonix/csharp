using System;
using System.Linq;

class Program
{
    public static bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email)
            && email.EndsWith("@gmail.com")
            && email.Count(c => c == '@') == 1
            && email.Count(c => c == '.') == 1
            && !email.Any(c => "&,{}()[]".Contains(c))
            && email.Length < 130;
    }

    public static void Main()
    {
        while (true)
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(email))
                break;
            
            bool isValid = IsValidEmail(email);
            Console.WriteLine($"Validity of gmail: {isValid}\n");
        }
    }
}
