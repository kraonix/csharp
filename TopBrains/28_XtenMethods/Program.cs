using System;
using System.Collections.Generic;

static class Extensions
{
    // Custom DistinctBy extension method
    // Extracts the name for the first occurrence of each unique id
    public static string[] DistinctBy(this string[] items)
    {
        HashSet<string> seenIds = new HashSet<string>(); // Tracks ids already encountered
        List<string> result = new List<string>();        // Stores distinct names in order

        // Iterate through each input item
        foreach (string item in items)
        {
            // Split input string into id and name
            string[] parts = item.Split(':');

            string id = parts[0];
            string name = parts[1];

            // Add only if id is encountered for the first time
            if (seenIds.Add(id))
            {
                result.Add(name);
            }
        }

        // Convert list to array as required by output
        return result.ToArray();
    }
}

class Program
{
    static void Main()
    {
        string[] items = { "1:John", "2:Alice", "1:Mike", "3:Bob", "2:Eve" };

        string[] distinctNames = items.DistinctBy();

        foreach (var name in distinctNames)
        {
            Console.WriteLine(name);
        }
    }
}
