using System;
using EMS;

class Program
{
    static void Main()
    {
        EmployeeUtility util = new EmployeeUtility();

        // Seed some default data
        util.AddEmployee("Sachin", "IT", 60000);
        util.AddEmployee("Anuska", "HR", 45000);
        util.AddEmployee("Arzoo", "IT", 70000);
        util.AddEmployee("Sahil", "Finance", 50000);

        while (true)
        {
            Console.WriteLine("\n===== Employee Management System =====");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Group Employees By Department");
            Console.WriteLine("3. Calculate Department Salary");
            Console.WriteLine("4. Show Employees Joined After Date");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    string dept = Console.ReadLine();

                    Console.Write("Enter Salary: ");
                    double salary = double.Parse(Console.ReadLine());

                    util.AddEmployee(name, dept, salary);
                    Console.WriteLine("Employee added successfully!");
                    break;

                case 2:
                    var grouped = util.GroupEmployeesByDepartment();
                    foreach (var deptGroup in grouped)
                    {
                        Console.WriteLine($"\nDepartment: {deptGroup.Key}");
                        foreach (var emp in deptGroup.Value)
                        {
                            Console.WriteLine($"  {emp.EmployeeID} - {emp.Name} - {emp.Salary}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Department: ");
                    string dep = Console.ReadLine();
                    double total = util.CalculateDepartmentSalary(dep);
                    Console.WriteLine($"Total Salary for {dep}: Rs. {total}");
                    break;

                case 4:
                    Console.Write("Enter date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    var list = util.GetEmployeesJoinedAfter(date);
                    Console.WriteLine("\nEmployees Joined After Given Date:");
                    foreach (var emp in list)
                    {
                        Console.WriteLine($"{emp.EmployeeID} - {emp.Name} - {emp.JoiningDate:yyyy-MM-dd}");
                    }
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
