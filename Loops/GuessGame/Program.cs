class GuessGame
{
    /// <summary>
    /// Program for a number guessing game.
    /// </summary>
    /// <param name="afdad"></param>
    public static void Main(String[] afdad)
    {
        try
        {
            int number = 67; // Predefined number to guess
            int guess = 0; // User's guess

            do
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine()); // Read user input

                if (guess < number) // Guess is too low
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > number) // Guess is too high
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else // Correct guess
                {
                    Console.WriteLine("Congratulations! You've guessed the number.");
                }
            } while (guess != number); // Repeat until the correct guess
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid integer."); // Handle non-integer inputs
        }
    }
}