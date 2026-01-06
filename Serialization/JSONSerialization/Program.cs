using System.Text.Json;

// ==================== STUDENT ======================
public class Student
{
    public string? Name { get; set; }
    public List<string> Subjects { get; set; } = new();
    public List<int> Marks { get; set; } = new();
}

// ==================== COLLECTION ===================
public class Students
{
    public List<Student> Items { get; set; } = new();
}

// ==================== PROGRAM ======================
public class Program
{
    public static void Main(string[] args)
    {
        Student s1 = new Student
        {
            Name = "Sachin",
            Subjects = { "Maths", "Physics", "CS" },
            Marks = { 90, 90, 90 }
        };

        Student s2 = new Student
        {
            Name = "Sahil",
            Subjects = { "Maths", "Chemistry", "CS" },
            Marks = { 88, 92, 91 }
        };

        Students students = new Students
        {
            Items = { s1, s2 }
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(students, options);
        File.WriteAllText("students.json", json);

        Console.WriteLine("students.json created successfully");
    }
}
