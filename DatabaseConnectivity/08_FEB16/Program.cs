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

        bool anyInactive = rows.Any(r => r.Field<bool>("IsActive") == false);
        bool allHaveMarks = rows.All(r => r.Field<int>("Marks") >= 0);

        var firstTopper = rows
            .Where(r => r.Field<int>("Marks") >= 90)
            .Select(r => r.Field<string>("FullName"))
            .FirstOrDefault();

        Console.WriteLine("Any inactive? " + anyInactive);
        Console.WriteLine("All have marks? " + allHaveMarks);
        Console.WriteLine("First topper: " + firstTopper);

        conn.Close();
    }
}
