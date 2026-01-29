namespace EmployeeLib;

public class ContractEmployee : IEmployee
{
    public int Id { get; }
    public string Name { get; }
    public double BaseSalary { get; }

    public int HoursWorked { get; }
    public double HourlyRate { get; }

    public ContractEmployee(int id, string name, int hours, double rate)
    {
        Id = id;
        Name = name;
        HoursWorked = hours;
        HourlyRate = rate;
        BaseSalary = 0;
    }

    public double CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }
}
