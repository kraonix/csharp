using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Database connectivity
        using SqlConnection conn = new SqlConnection(@"Server=localhost;Database=CapGStudent;Trusted_Connection=True;TrustServerCertificate=True;");

        conn.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable students = new DataTable();

        adapter.Fill(students);
        conn.Close();

        // Now LINQ works because students is declared
        var toppers = students.AsEnumerable()
        .Where(r => r.Field<int>("Marks") >= 80)
        .Select(r => new
        {
            Id = r.Field<int>("StudentId"),
            Name = r.Field<string>("FullName"),
            Marks = r.Field<int>("Marks")
        }).ToList();

        foreach (var s in toppers)
            Console.WriteLine($"{s.Id} | {s.Name} | {s.Marks}");
        conn.Close();
    }
}
