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

        var sorted = students.AsEnumerable()
        .OrderByDescending(r => r.Field<int>("Marks"))
        .ThenBy(r => r.Field<string>("FullName"))
        .Select(r => new
        {
            Name = r.Field<string>("FullName"),
            Marks = r.Field<int>("Marks")
        }).ToList();

        Console.WriteLine("Sorted by Marks desc, then Name:");
        foreach (var s in sorted)
            Console.WriteLine($"{s.Name} - {s.Marks}");

        conn.Close();
    }
}
