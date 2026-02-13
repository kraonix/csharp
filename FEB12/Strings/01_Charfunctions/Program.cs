using System;
using System.Text;

class Program
{
    static void Main()
    {
        string sample = "AbC12 @#\t\nⅨ😊";
        Console.WriteLine("=== Character Method Demonstration ===\n");
        
        foreach (char c in sample)
        {
            DisplayCharacterAnalysis(c);
        }

        DemonstrateParsing();
        DemonstrateComparison();
        DemonstrateConversion();
        DisplayCharLimits();
        
        Console.WriteLine("\n=== End of Demonstration ===");
    }

    static void DisplayCharacterAnalysis(char c)
    {
        Console.WriteLine($"Character: {c}");
        Console.WriteLine($"IsDigit: {char.IsDigit(c)}");
        Console.WriteLine($"IsLetter: {char.IsLetter(c)}");
        Console.WriteLine($"IsLetterOrDigit: {char.IsLetterOrDigit(c)}");
        Console.WriteLine($"IsUpper: {char.IsUpper(c)}");
        Console.WriteLine($"IsLower: {char.IsLower(c)}");
        Console.WriteLine($"IsWhiteSpace: {char.IsWhiteSpace(c)}");
        Console.WriteLine($"IsSymbol: {char.IsSymbol(c)}");
        Console.WriteLine($"IsPunctuation: {char.IsPunctuation(c)}");
        Console.WriteLine($"IsControl: {char.IsControl(c)}");
        Console.WriteLine($"IsNumber (Unicode aware): {char.IsNumber(c)}");
        Console.WriteLine($"IsSeparator: {char.IsSeparator(c)}");
        Console.WriteLine($"IsSurrogate: {char.IsSurrogate(c)}");
        Console.WriteLine($"IsHighSurrogate: {char.IsHighSurrogate(c)}");
        Console.WriteLine($"IsLowSurrogate: {char.IsLowSurrogate(c)}");
        Console.WriteLine($"ToUpper: {char.ToUpper(c)}");
        Console.WriteLine($"ToLower: {char.ToLower(c)}");
        Console.WriteLine($"ToUpperInvariant: {char.ToUpperInvariant(c)}");
        Console.WriteLine($"ToLowerInvariant: {char.ToLowerInvariant(c)}");
        Console.WriteLine($"Unicode Category: {char.GetUnicodeCategory(c)}");
        Console.WriteLine("--------------------------------------");
    }

    static void DemonstrateParsing()
    {
        char numericChar = '9';
        int parsedValue = int.Parse(numericChar.ToString());
        Console.WriteLine($"Parsed '9' to int: {parsedValue}");

        char command = 'A';
        if (char.TryParse(command.ToString(), out char result))
        {
            Console.WriteLine($"TryParse successful: {result}");
        }
    }

    static void DemonstrateComparison()
    {
        char x = 'a';
        char y = 'A';
        Console.WriteLine($"Equals ignoring case: {char.ToUpper(x).Equals(char.ToUpper(y))}");
        Console.WriteLine($"CompareTo example (a vs b): {'a'.CompareTo('b')}");
    }

    static void DemonstrateConversion()
    {
        char letter = 'Z';
        Console.WriteLine($"Char to string: {letter}");
    }

    static void DisplayCharLimits()
    {
        Console.WriteLine($"Char MinValue: {(int)char.MinValue}");
        Console.WriteLine($"Char MaxValue: {(int)char.MaxValue}");
    }
}
