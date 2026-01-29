using NUnit.Framework;
using EmployeeLib;

namespace EmployeeLib.Tests;

[TestFixture]
public class EmployeeTests
{
    [Test]
    public void FullTimeEmployee_Salary_IsBasePlusBonus()
    {
        IEmployee emp = new FullTimeEmployee(1, "Sachin", 50000, 10000);
        double salary = emp.CalculateSalary();
        Assert.That(salary, Is.EqualTo(60000));
    }

    [Test]
    public void ContractEmployee_Salary_IsHoursTimesRate()
    {
        IEmployee emp = new ContractEmployee(2, "Rahul", 100, 500);
        double salary = emp.CalculateSalary();
        Assert.That(salary, Is.EqualTo(50000));
    }
}
