public class Set1_01
{
    public static string Encoder(string input)
    {
        string result = "";
        int size = input.Length;

        foreach(char i in input)
        {
            result += (char)((int)i - size);
        }

        return result;
    }
    public static void Main()
    {
        string input = Console.ReadLine();
        string result = Encoder(input);
        Console.WriteLine(result);
    }
}