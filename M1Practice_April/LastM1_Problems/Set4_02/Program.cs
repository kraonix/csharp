using System.Collections.Generic;

public class ExamManager
{
    public Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();
    public Dictionary<string, Dictionary<string, int>> subjectRecords = new Dictionary<string, Dictionary<string, int>>();

    public void ADD(string studentID, string subject, int marks)
    {
        // Add student if not exists
        if (!studentRecords.ContainsKey(studentID))
            studentRecords[studentID] = new Dictionary<string, int>();

        // Add subject if not exists
        if (!subjectRecords.ContainsKey(subject))
            subjectRecords[subject] = new Dictionary<string, int>();

        // Update student record
        studentRecords[studentID][subject] = marks;

        // Update subject record
        subjectRecords[subject][studentID] = marks;
    }

    public void REMOVE(string studentID, string subject)
    {

    }

    public void TOP(string subject)
    {
        int max = 0;
        string maxHolder = "none";
        if (subjectRecords.ContainsKey(subject))
        {
            foreach (var record in subjectRecords[subject])
            {
                if (record.Value > max)
                {
                    max = record.Value;
                    maxHolder = record.Key;
                }
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(subject + " " + maxHolder + " " + max);
        Console.ResetColor();
    }

    public void RESULT()
    {

    }
}

public class Set4_02
{
    static ExamManager manager = new ExamManager();

    public static void Resolver(string input)
    {
        List<string> temp = input.Split(' ').ToList();

        if (temp[0] == "ADD")
        {
            manager.ADD(temp[1], temp[2], int.Parse(temp[3]));
        }
        else if (temp[0] == "REMOVE")
        {
            manager.REMOVE(temp[1], temp[2]);
        }
        else if (temp[0] == "TOP")
        {
            manager.TOP(temp[1]);
        }
        else if (temp[0] == "RESULT")
        {
            manager.RESULT();
        }

    }

    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string input = "";
        for (int i = 0; i < N; i++)
        {
            input = Console.ReadLine();
            Resolver(input);
        }
    }
}