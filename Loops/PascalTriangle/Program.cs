class PascalTriangle
{
    /// <summary>
    /// Program for generating Pascal's Triangle.
    /// </summary>
    static void Main()
    {
        try
        {
            Console.Write("Enter the number of rows for Pascal's Triangle: ");
            int rows = int.Parse(Console.ReadLine()); // Number of rows in Pascal's Triangle

            for (int i = 0; i < rows; i++)
            {
                int number = 1; // First number in each row is always 1
                Console.Write(new string(' ', (rows - i) * 2)); // Print leading spaces for formatting

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(number + "   "); // Print the current number with spacing
                    number = number * (i - j) / (j + 1); // Calculate the next number in the row
                }
                Console.WriteLine(); // Move to the next line after each row
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}