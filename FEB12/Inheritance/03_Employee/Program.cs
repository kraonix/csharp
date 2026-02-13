using System;
public class Employee
{
    public int salary=1000;
    public void CalculateSalary()
    {
        Console.WriteLine($"Salary is {salary}");
    }
}
class Manager: Employee
{
    int bonus=5;
    public void CalculateSalary()
    {
        Console.WriteLine($"Salary is {salary*bonus}");
    }
}
class Program
{
    static void Main()
    {
        Employee employee=new Employee();
        employee.CalculateSalary();
        Manager manager=new Manager();
        manager.CalculateSalary();
    }
}