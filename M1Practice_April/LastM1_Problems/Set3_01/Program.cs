using System.Text.RegularExpressions;

public class Set3_01
{
    public static bool Validator(string input)
    {
        List<string> address = input.Split("::").ToList();
        List<string> IP = address[0].Split(':').ToList();
        List<string> Mac = address[1].Split(':').ToList();
        
        //IP Check
        if(IP.Count != 8) return false;
        foreach(var temp in IP)
        {
            if(Regex.IsMatch(temp, @"^[0-9a-fA-F]{1,4}$") == false)
            {
                return false;
            }
        }

        //Mac Check
        if(Mac.Count != 6) return false;
        foreach(var temp in Mac)
        {
            if(Regex.IsMatch(temp, @"^[0-9A-F]{2}$") == false)
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string input = "";
        for(int i = 0; i < N; i++)
        {
            input = Console.ReadLine();
            if (Validator(input))
            {
                Console.WriteLine("AUTHENTIC DEVICE");
            }
            else
            {
                Console.WriteLine("REJECTED DEVICE");
            }
        }
    }
}