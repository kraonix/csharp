using System;
using System.Collections.Generic;

public class Solution
{
    public static string EqualSum(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return "-404";
        }

        s = s.ToLower();

        Dictionary<char, int> Alphas = new();

        int j = 1;
        for (char c = 'a'; c <= 'z'; c++)
        {
            Alphas[c] = j;
            j++;
        }

        int totalSum = 0;
        foreach (char c in s)
        {
            totalSum += Alphas[c];
        }

        int leftSum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int currentValue = Alphas[s[i]];
            int rightSum = totalSum - leftSum - currentValue;

            if (leftSum == rightSum)
            {
                return s[i].ToString() + $" at {i} index";
            }

            leftSum += currentValue;
        }

        return "-404";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();
        Console.WriteLine(Solution.EqualSum(s));
    }
}
