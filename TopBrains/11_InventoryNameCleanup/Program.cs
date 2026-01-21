using System.Globalization;
using System.Text;

class InventoryNameCleanUp
{
    /// <summary>
    /// Given a product name string, remove:
    ///        All duplicate consecutive characters
    ///        Trim extra spaces
    ///        Convert to TitleCase
    /// </summary>

    public static string Cleaner(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return string.Empty;

        var sb = new StringBuilder();
        char prev = '\0';

        // Remove duplicate consecutive characters
        foreach (char c in name)
        {
            if (c != prev)
                sb.Append(c);

            prev = c;
        }

        // Trim and normalize spaces
        string cleaned = sb.ToString();
        cleaned = string.Join(" ", cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        // Convert to Title Case
        TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
        return textInfo.ToTitleCase(cleaned.ToLowerInvariant());
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter Product Name: ");
        string Name = Console.ReadLine();

        string CleanedName = Cleaner(Name);

        Console.WriteLine($"Cleaned Name: {CleanedName}");
    }
}