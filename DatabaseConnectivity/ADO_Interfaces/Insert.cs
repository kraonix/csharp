using Microsoft.Data.SqlClient;
using System;


public interface IInsertEmployee
{
    void Insert(SqlConnection con, int id, string name, decimal salary, int dept);
}

public class InsertEmployee : IInsertEmployee
{
    public void Insert(SqlConnection con, int id, string name, decimal salary, int dept)
    {
        const string sql = @"INSERT INTO dbo.EmployeeCapG (Id, Name, Salary, DeptId) VALUES (@id, @name, @salary, @dept)";

        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@dept", dept);
        cmd.Parameters.AddWithValue("@salary", salary);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Employee Inserted Successfully\n");
    }
}
