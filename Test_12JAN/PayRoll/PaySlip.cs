/// <summary>
/// Represents a pay slip document containing employee salary and compensation information.
/// </summary>
/// <remarks>
/// This class stores essential details about an employee's earnings, including gross and net salary calculations.
/// It is used to generate payroll records and salary statements for employees.
/// </remarks>
public class PaySlip
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public string EmployeeType { get; set; }

    public double GrossSalary { get; set; }

    public double NetSalary { get; set; }
}
