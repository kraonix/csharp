class Armstrong
{
    /// <summary>
    /// Program for checking Armstrong numbers.
    /// </summary>
    public static void Main(string[] args)
    {
        // Input number
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int originalNumber = number;
        int sum = 0;
        int digits = number.ToString().Length; // Count number of digits

        while (number > 0) // Extract each digit
        {
            int digit = number % 10;
            sum += (int)Math.Pow(digit, digits); // Raise digit to the power of number of digits
            number /= 10;
        }

        if (sum == originalNumber) // Check if sum equals original number
        {
            Console.WriteLine($"{originalNumber} is an Armstrong number.");
        }
        else
        {
            Console.WriteLine($"{originalNumber} is not an Armstrong number.");
        }
    }
}