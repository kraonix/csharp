public class Program
{
    public static List<int> Solve(int N, string[] strings)
    {
        List<int> result = new List<int>();
        foreach (var s in strings)
        {
            string temp = s;

            bool Validated = true;
            if (!char.IsLetter(temp[0]))
            {
                Validated = false;
            }
            if(!char.IsDigit(temp[temp.Length - 1]))
            {
                Validated = false;
            }

            if (Validated)
            {
                result.Add(1);
            }
            else
            {
                result.Add(0);
            }

        }
        return result;
    }

    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        string[] strings = new string[N];
        for (int i = 0; i < N; i++)
        {
            strings[i] = Console.ReadLine();
        }

        var Result = Solve(N, strings);
        foreach (var v in Result)
        {
            Console.WriteLine(v);
        }
    }
}