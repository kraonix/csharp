class StrongNumber
{
    static int CalculateFactorial(int num)
    {
        int fact = 1;
        for (int i = 1; i <= num; i++)
        {
            fact *= i;
        }
        return fact;
    }

    /// <summary>
    /// Program for checking Strong Numbers.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        try
        {
            // Input a number
            Console.Write("Enter a number to check if it is a Strong Number: ");
            int number = int.Parse(Console.ReadLine());
            int sumOfFactorials = 0;
            int temp = number;

            // Calculate sum of factorials of each digit
            while (temp != 0)
            {
                int digit = temp % 10;
                sumOfFactorials += CalculateFactorial(digit);
                temp /= 10;
            }

            if (sumOfFactorials == number)
            {
                Console.WriteLine($"{number} is a Strong Number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a Strong Number.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}