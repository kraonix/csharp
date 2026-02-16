using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

string cs = @"Server=localhost;Database=CapGStudent;Trusted_Connection=True;TrustServerCertificate=True;";

DataTable students = new DataTable();
DataTable enrollments = new DataTable();
DataTable courses = new DataTable();

// 1) Load data (Disconnected mode)
using (var con = new SqlConnection(cs))
{
    con.Open();
    new SqlDataAdapter("SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con).Fill(students);
    new SqlDataAdapter("SELECT StudentId, CourseId FROM Enrollments", con).Fill(enrollments);
    new SqlDataAdapter("SELECT CourseId, CourseName FROM Courses", con).Fill(courses);
}

Console.WriteLine("=== Top 3 Students (by marks) ===");
var top3 = students.AsEnumerable()
    .OrderByDescending(r => r.Field<int>("Marks"))
    .Take(3)
    .Select(r => $"{r.Field<string>("FullName")} - {r.Field<int>("Marks")}")
    .ToList();
top3.ForEach(Console.WriteLine);

Console.WriteLine("\n=== City-wise Average Marks ===");
var cityAvg = students.AsEnumerable()
    .GroupBy(r => r.Field<string>("City"))
    .Select(g => new { City = g.Key, Avg = g.Average(x => x.Field<int>("Marks")) })
    .OrderByDescending(x => x.Avg)
    .ToList();

foreach (var x in cityAvg)
    Console.WriteLine($"{x.City} -> Avg: {x.Avg:0.00}");

Console.WriteLine("\n=== Active Students with Courses ===");
var report =
    from s in students.AsEnumerable()
    join e in enrollments.AsEnumerable()
        on s.Field<int>("StudentId") equals e.Field<int>("StudentId")
    join c in courses.AsEnumerable()
        on e.Field<int>("CourseId") equals c.Field<int>("CourseId")
    where s.Field<bool>("IsActive") == true
    select new
    {
        Student = s.Field<string>("FullName"),
        Course = c.Field<string>("CourseName")
    };

foreach (var row in report)
    Console.WriteLine($"{row.Student} -> {row.Course}");