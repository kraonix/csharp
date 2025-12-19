class Palindrome
{
    /// <summary>
    /// Program for checking palindromes.
    /// </summary>
    static void Main()
    {
        // Input string
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        string reversed = "";

        // Reverse the string
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }

        // Check if the string is a palindrome
        if (input == reversed)
        {
            Console.WriteLine("The string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome.");
        }
    }
}