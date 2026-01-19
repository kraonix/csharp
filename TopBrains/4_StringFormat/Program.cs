using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

// Define a record to hold student information
public record Student(string Name, int Score);
public static class StudentProcessor
{
    /// <summary>
    /// Builds a JSON string of students with scores above a minimum threshold.
    /// </summary>

    public static string BuildJson(string[] items, int minScore)
    {
        // Validate input
        if (items == null || items.Length == 0)
            return "[]";

        // Map to hold the highest score for each student
        var map = new Dictionary<string, int>();

        // Process each item
        foreach (var item in items)
        {
            // Split the item into name and score
            int idx = item.IndexOf(':');
            if (idx <= 0 || idx == item.Length - 1)
                continue;

            // Extract name and score
            string name = item[..idx];

            // Parse score
            if (!int.TryParse(item[(idx + 1)..], out int score))
                continue;

            // Skip scores below the minimum threshold
            if (score < minScore)
                continue;

            // Update the map with the highest score for the student
            if (!map.ContainsKey(name) || map[name] < score)
                map[name] = score;
        }

        // Convert the dictionary to a list of Student records
        var students = new List<Student>(map.Count);
        foreach (var kv in map)
            students.Add(new Student(kv.Key, kv.Value));

        // Sort the students by score (descending) and then by name (ascending)
        students.Sort((a, b) =>
        {
            int scoreCompare = b.Score.CompareTo(a.Score);
            return scoreCompare != 0 ? scoreCompare : string.Compare(a.Name, b.Name);
        });

        // Serialize the list of students to JSON
        return JsonSerializer.Serialize(students);
    }
}
public class Program
{
    // Example usage
    public static void Main(string[] args)
    {
        string[] items =
        {
            "Alice:90",
            "Bob:85",
            "Charlie:90",
            "Dave:70",
            "Eve:88"
        };

        int minScore = 85;

        string json = StudentProcessor.BuildJson(items, minScore);

        Console.WriteLine(json);
    }
}