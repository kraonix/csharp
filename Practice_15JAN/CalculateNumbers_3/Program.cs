public class Program
{
    public static List<int> NumberList = new List<int>();

    public static void AddNumbers(int Numbers)
    {
        NumberList.Add(Numbers);
    }

    public static double GetGPAScored()
    {
        double Credit = 3;
        int Sum = NumberList.Sum();

        double GPA = ((Sum * Credit) / (NumberList.Count * Credit)) / 10;

        return GPA;
    }

    public static char GetGradeScored(double GPA)
    {
        if (GPA == 10)
            return 'S';
        else if (GPA >= 9)
            return 'A';
        else if (GPA >= 8)
            return 'B';
        else if (GPA >= 7)
            return 'C';
        else if (GPA >= 6)
            return 'D';
        else if (GPA >= 5)
            return 'E';
        else
            return ' ';
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Total Subjects: ");
        int Total = int.Parse(Console.ReadLine());

        int Marks = 0;
        for (int i = 0; i < Total; i++)
        {
            Console.Write($"Enter Marks for Subject {i + 1} : ");
            Marks = int.Parse(Console.ReadLine());

            AddNumbers(Marks);
        }

        Console.WriteLine($"GPA Scored: {GetGPAScored()}");
        Console.WriteLine($"Grade Scored: {GetGradeScored(GetGPAScored())}");
    }
}