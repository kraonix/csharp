using System.Collections.Generic;
using System.Linq;

public static class FakeDataStore
{
    public static List<Department> Departments { get; set; } = new List<Department>
    {
        new Department { DepartmentId = 1, Name = "HR" },
        new Department { DepartmentId = 2, Name = "IT" },
        new Department { DepartmentId = 3, Name = "Finance" },
        new Department { DepartmentId = 4, Name = "Marketing" }
    };

    public static List<Employee> Employees { get; set; } = new List<Employee>
    {
        new Employee { EmployeeId = 1, Name = "Anuska", Salary = 50000, DepartmentId = 2 },
        new Employee { EmployeeId = 2, Name = "Rahul", Salary = 45000, DepartmentId = 1 },
        new Employee { EmployeeId = 3, Name = "Priya", Salary = 60000, DepartmentId = 3 },
        new Employee { EmployeeId = 4, Name = "Arjun", Salary = 55000, DepartmentId = 2 },
        new Employee { EmployeeId = 5, Name = "Sneha", Salary = 48000, DepartmentId = 4 }
    };

    public static int EmployeeCounter = 6;
    public static int DepartmentCounter = 5;
}