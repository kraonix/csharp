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

        var byCity = students.AsEnumerable()
        .GroupBy(r => r.Field<string>("City"))
        .Select(g => new
        {
            City = g.Key,
            Count = g.Count(),
            AvgMarks = (int)g.Average(x => x.Field<int>("Marks"))
        })
        .OrderByDescending(x => x.AvgMarks)
        .ToList();

        foreach (var g in byCity)
            Console.WriteLine($"{g.City} | Count={g.Count} | AvgMarks={g.AvgMarks}");

        conn.Close();
    }
}
