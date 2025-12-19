class LeapYear
{
    /// <summary>
    /// Program for checking leap years.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine(IsLeapYear(year) ? $"{year} is a leap year." : $"{year} is not a leap year.");
    }

    static bool IsLeapYear(int year)
    {
        if (year % 4 == 0)
        {
            if (year % 100 == 0)
            {
                if (year % 400 == 0)
                {
                    return true; // Divisible by 400
                }
                return false; // Divisible by 100 but not by 400
            }
            return true; // Divisible by 4 but not by 100
        }
        return false; // Not divisible by 4
    }
}