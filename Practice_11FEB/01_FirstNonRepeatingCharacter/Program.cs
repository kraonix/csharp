// Q1) First Non-Repeating Character
// Question: Given a string, print the first character with frequency = 1. If none, print -1.

using System;
using System.Collections.Generic;

public static class Solution
{
    public static string Solve(string s)
    {
        if (string.IsNullOrEmpty(s)) return "-1";

        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char ch in s)
        {
            freq[ch] = freq.ContainsKey(ch) ? freq[ch] + 1 : 1;
        }

        foreach (char ch in s)
        {
            if (freq[ch] == 1) return ch.ToString();
        }

        return "-1";
    }
}
public class Program
{
    public static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(Solution.Solve(s));
    }
}
