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

        var rows = students.AsEnumerable();

        int maxMarks = rows.Max(r => r.Field<int>("Marks"));
        int minMarks = rows.Min(r => r.Field<int>("Marks"));
        double avgMarks = rows.Average(r => r.Field<int>("Marks"));
        int sumMarks = rows.Sum(r => r.Field<int>("Marks"));

        Console.WriteLine($"Max={maxMarks}, Min={minMarks}, Avg={avgMarks:0.00}, Sum={sumMarks}");

        conn.Close();
    }
}
