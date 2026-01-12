/// <summary>
/// Processes payroll for a list of employees by calculating and displaying their salaries.
/// </summary>
/// <param name="employees">A list of Employee objects whose payroll needs to be processed.</param>
/// <remarks>
/// This method iterates through each employee in the provided list, calculates their salary,
/// and outputs the employee's name and calculated salary to the console.
/// </remarks>

namespace PayRoll
{
    public delegate void SalaryProcessedHandler(Employee emp, PaySlip slip);

    class PayrollProcessor
    {
        // Delegate instance
        public SalaryProcessedHandler? SalaryProcessed;

        public void ProcessPayroll(List<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                double salary = emp.CalculateSalary();

                PaySlip slip = new PaySlip
                {
                    EmployeeId = emp.Id,
                    EmployeeName = emp.Name,
                    EmployeeType = emp.GetType().Name,
                    GrossSalary = salary,
                    NetSalary = salary * 1
                };

                Console.WriteLine(
                    $"{slip.EmployeeName} | {slip.EmployeeType} | Net: {slip.NetSalary}"
                );

                // Delegate invocation (key line)
                SalaryProcessed?.Invoke(emp, slip);
            }
        }
    }    
}