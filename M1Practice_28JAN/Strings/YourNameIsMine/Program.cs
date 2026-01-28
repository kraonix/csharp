using System.Reflection.Emit;

class Progran
{
    public static void Valid(string name1, string name2)
    {
        bool name1Valid = true;
        bool name2Valid = true;

        foreach (char c in name1)
        {
            if (!char.IsLetter(c))
                name1Valid = false;
        }
        foreach (char c in name2)
        {
            if (!char.IsLetter(c))
                name2Valid = false;
        }

        if (name1Valid == true && name2Valid == true)
        {
            Checker(name1, name2);
        }
        else if (name1Valid == false && name2Valid == true)
        {
            Console.WriteLine($"{name1} is Invalid!");
        }
        else if (name1Valid == true && name2Valid == false)
        {
            Console.WriteLine($"{name2} is Invalid!");
        }
        else
        {
            Console.WriteLine($"{name1} and {name2} both are Invaild!");
        }
    }
    public static void Checker(string name1, string name2)
    {
        int smallerLength = name1.Length < name2.Length ? name1.Length : name2.Length;

        SortedDictionary<char, int> freq1 = new SortedDictionary<char, int>();
        SortedDictionary<char, int> freq2 = new SortedDictionary<char, int>();

        foreach (char c in name1)
        {
            if (freq1.ContainsKey(c))
                freq1[c]++;
            else
                freq1[c] = 1;
        }

        foreach (char c in name2)
        {
            if (freq2.ContainsKey(c))
                freq2[c]++;
            else
                freq2[c] = 1;
        }

        bool CheckedComp = true;

        foreach (var kv in freq1)
        {
            if (!freq2.ContainsKey(kv.Key) || freq2[kv.Key] != kv.Value)
            {
                CheckedComp = false;
                break;
            }
        }

        if (CheckedComp == true)
        {
            Console.WriteLine("Made For Each Other");
            Console.WriteLine($"{Math.Abs(name1.Length - name2.Length)}");
        }
        else
        {
            Console.WriteLine("Not Made For Each Other!");
            Console.WriteLine($"{Math.Abs(name1.Length - name2.Length)}");
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter name 1: ");
        string name1 = Console.ReadLine();

        Console.Write("Enter name 2: ");
        string name2 = Console.ReadLine();

        name1 = name1.ToLower().Trim();
        name2 = name2.ToLower().Trim();

        Valid(name1, name2);
    }
}