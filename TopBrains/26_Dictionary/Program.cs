using System;
using System.Collections.Generic;
namespace Dictionary
{
class Program
{
    // Method to calculate total salary for given employee IDs
    static int GetTotalSalary(List<int> ids, Dictionary<int, int> employeeSalary)
    {
        int totalSalary = 0; // Stores the sum of salaries

        // Loop through each employee ID
        foreach (int id in ids)
        {
            // Check if the ID exists in the dictionary
            if (employeeSalary.ContainsKey(id))
            {
                totalSalary += employeeSalary[id]; // Add salary to total
            }
        }

        return totalSalary; // Return the final salary sum
    }

    static void Main()
    {
        // List of employee IDs
        List<int> ids = new List<int> { 1, 4, 5 };

        // Dictionary storing EmployeeId as key and Salary as value
        Dictionary<int, int> employeeSalary = new Dictionary<int, int>
        {
            { 1, 20000 },
            { 4, 40000 },
            { 5, 15000 }
        };

        // Calculate total salary
        int result = GetTotalSalary(ids, employeeSalary);

        // Print the output
        Console.WriteLine(result);
    }
}
}