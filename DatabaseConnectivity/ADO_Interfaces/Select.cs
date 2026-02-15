using Microsoft.Data.SqlClient;

public interface IGetEmployees
{
    void GetAll(SqlConnection con);
}

public class GetEmployees : IGetEmployees
{
    public void GetAll(SqlConnection con)
    {
        string sql = @"SELECT Id, Name, Salary, DeptId FROM dbo.EmployeeCapG ORDER BY Id";

        using var cmd = new SqlCommand(sql, con);
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("Employee List:\n");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]} | {reader["Name"]} | {reader["DeptId"]} | {reader["Salary"]}");
        }
    }
}
