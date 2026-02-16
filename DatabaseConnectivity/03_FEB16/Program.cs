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
        string city = "Pune";

        var puneStudents = students.AsEnumerable()
            .Where(r => r.Field<string>("City") == city)
            .Select(r => r.Field<string>("FullName"))
            .ToList();

        Console.WriteLine("Students in Pune:");
        puneStudents.ForEach(Console.WriteLine);
        conn.Close();
    }
}
