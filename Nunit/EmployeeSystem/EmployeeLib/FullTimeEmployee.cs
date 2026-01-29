namespace EmployeeLib;

public class FullTimeEmployee : IEmployee
{
    public int Id { get; }
    public string Name { get; }
    public double BaseSalary { get; }

    public double Bonus { get; }

    public FullTimeEmployee(int id, string name, double baseSalary, double bonus)
    {
        Id = id;
        Name = name;
        BaseSalary = baseSalary;
        Bonus = bonus;
    }

    public double CalculateSalary()
    {
        return BaseSalary + Bonus;
    }
}
