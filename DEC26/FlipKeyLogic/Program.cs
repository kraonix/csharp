using System;
namespace FlipKeyLogic
{
//•	Remove all characters whose ASCII values are even numbers.
//•	Reverse the remaining characters.
//•	In the reversed string, convert characters that have even positioned character (0 based index) to uppercase.Refer to the sample input and output.
//Return the generated key. 
    public class Program
    {
        // The function cleanses and inverts the input string based on specified rules.
        public string? CleanseAndInvert(string input)
        {
            // Validate input
            if (input == null || input.Length < 6)
            {
                return string.Empty;
            }
            // Check for non-alphabetic characters
            foreach (char c in input)
            {
                if(!char.IsLetter(c))
                {
                    return string.Empty;
                }
            }
        
            // Process the input string
            input = input.ToLower();
            string result = string.Empty;
            for(int i = 0; i < input.Length; i++)
            {
                if(((int)input[i]) % 2 != 0)
                {
                    result += input[i];
                }
            }
            // Convert even positioned characters to uppercase
            for (int i = result.Length - 1; i >= 0; i--)
            {
                if ((result.Length - 1 - i) % 2 == 0)
                {
                    result = result.Remove(i, 1).Insert(i, result[i].ToString().ToUpper());
                }
            }
            // Reverse the string
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            result = new string(charArray);
            return result;
        }
        static void Main(string[] args)
        {
            // Example usage
            Program p = new Program();
            Console.WriteLine("Enter the input string:");
            string? input = Console.ReadLine();
            Console.WriteLine(p.CleanseAndInvert(input));
        }
    }
}
