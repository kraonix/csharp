using ExamSchedule.Model;
using ExamSchedule.Data;

public class Program{
    public static void Main(string[] args)
    {
        var localStudents = DataBank.GetStudents();
        var localSessions = DataBank.GetSessions();

        Console.Write($"\nStudent Names: ");
        foreach(var s in localStudents)
        {
            Console.Write($"{s.Name} | ");
        }

        Console.WriteLine($"\n\nSession Details: ");
        foreach(var s in localSessions)
        {
            Console.WriteLine($"ID: {s.Id} => Description: {s.Description}");
        }
    }
}