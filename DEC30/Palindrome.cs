using System;
using System.Text;
namespace LogicalPrograms
{
    public static class Palindrome
    {
        // Extension method to check for palindrome
        public static bool IsPalindrome(this string name)
        {
            // Remove spaces and convert to lowercase for uniformity
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Input string cannot be null or empty.");
            // Clean the input string
            string cleaned = name.Replace(" ", "").ToLower();
            StringBuilder reverse = new StringBuilder();
            // Build the reverse of the cleaned string
            for (int i = cleaned.Length - 1; i >= 0; i--)
            {
                reverse.Append(cleaned[i]);
            }
            return cleaned == reverse.ToString();
        }
    }
}
