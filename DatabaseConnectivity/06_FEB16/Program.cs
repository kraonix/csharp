using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            @"Server=localhost;Database=CapGStudent;Trusted_Connection=True;TrustServerCertificate=True;";

        DataTable students = new DataTable();
        DataTable enrollments = new DataTable();
        DataTable courses = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            using (SqlDataAdapter da1 = new SqlDataAdapter(
                "SELECT StudentId, FullName, City, Marks, IsActive FROM Students", conn))
            {
                da1.Fill(students);
            }

            using (SqlDataAdapter da2 = new SqlDataAdapter(
                "SELECT StudentId, CourseId FROM Enrollments", conn))
            {
                da2.Fill(enrollments);
            }

            using (SqlDataAdapter da3 = new SqlDataAdapter(
                "SELECT CourseId, CourseName FROM Courses", conn))
            {
                da3.Fill(courses);
            }
        }

        Console.WriteLine("Data loaded successfully.\n");

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
            City = s.Field<string>("City"),
            Marks = s.Field<int>("Marks"),
            Course = c.Field<string>("CourseName")
        };

        foreach (var row in report)
            Console.WriteLine($"{row.Student} | {row.City} | {row.Marks} | {row.Course}");
    }
}
