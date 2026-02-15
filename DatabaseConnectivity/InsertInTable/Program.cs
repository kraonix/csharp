using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = @"Server=localhost;Database=LpuCapG;Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Connected to SQL Server successfully!");

            string query = "INSERT INTO dbo.EmployeeCapG (Id ,Name, Salary, DeptId) VALUES (@Id, @Name, @Salary, @DeptId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", 5);
                command.Parameters.AddWithValue("@Name", "Raj");
                command.Parameters.AddWithValue("@Salary", 75000);
                command.Parameters.AddWithValue("@DeptId", 2);

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} row inserted successfully!");
            }
        }
    }
}   