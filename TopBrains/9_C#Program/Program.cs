using System;
using System.Text;
namespace MahirlAndAlphabets
{
    public class Program
    {
        // Method to check if a character is a vowel
        static bool IsVowel(char c)
        {
            c = char.ToLower(c);
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
        static void Main()
        {
            // Read the first and second words
            Console.WriteLine("Enter first word :");
            string word1 = Console.ReadLine()!;
            Console.WriteLine("Enter second word :");
            string word2 = Console.ReadLine()!;
            StringBuilder step1Result = new StringBuilder();
            foreach (char c in word1)
            {
                char lowerChar = char.ToLower(c);
                // Check if character is a consonant
                if (!IsVowel(lowerChar))
                {
                    // If consonant exists in second word, skip it
                    if (word2.ToLower().Contains(lowerChar))
                        continue;
                }
                // Keep vowels and non-common consonants
                step1Result.Append(c);
            }
            StringBuilder finalResult = new StringBuilder();
            for (int i = 0; i < step1Result.Length; i++)
            {
                // Add character only if it is not same as previous character
                if (i == 0 || step1Result[i] != step1Result[i - 1])
                {
                    finalResult.Append(step1Result[i]);
                }
            }

            // Output the final processed string
            Console.WriteLine("Final word :");
            Console.WriteLine(finalResult.ToString());
        }
    }
}
