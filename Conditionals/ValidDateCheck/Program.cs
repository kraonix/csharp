class ValidDateCheck
{
    /// <summary>
    /// Program for checking if a date is valid.
    /// </summary>
    /// <param name="args"></param>
    
    ///Leap year check method
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
    public static void Main(String[] args)
    {
        // Input day, month, and year
        Console.Write("Enter Day: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Enter Month: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter Year: ");
        int year = int.Parse(Console.ReadLine());

        // Check if the date is valid
        bool isValidDate = false;

        // Days in each month
        int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        // Adjust for leap years
        if (IsLeapYear(year))
        {
            daysInMonth[2] = 29;
        }

        // Validate month and day
        if (month >= 1 && month <= 12)
        {
            if (day >= 1 && day <= daysInMonth[month])
            {
                isValidDate = true;
            }
        }

        Console.WriteLine(isValidDate ? "Valid Date" : "Invalid Date"); 
    }
}