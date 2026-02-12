// Q2) Most Frequent Character (tie → smallest ASCII)
// Question: Print the character with highest frequency. If tie, print the smallest character.
using System;
using System.Collections.Generic;
using System.Linq;

public static class Solution
{
    public static string Solve(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";

        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char ch in s)
        {
            freq[ch] = freq.ContainsKey(ch) ? freq[ch] + 1 : 1;
        }

        var best = freq.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First();

        return best.Key.ToString();
    }
}

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(Solution.Solve(s));
    }
}
