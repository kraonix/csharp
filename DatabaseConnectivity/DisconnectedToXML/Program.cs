using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs = @"Server=localhost;Database=LpuCapG;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT Id, Name, Salary, DeptId FROM dbo.EmployeeCapG";

        using SqlConnection con = new SqlConnection(cs);
        using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

        DataSet ds = new();
        adapter.Fill(ds, "Employees");

        string filePath = "Employees.xml";
        ds.WriteXml(filePath);

        Console.WriteLine($"XML file saved: {filePath}");
    }
}