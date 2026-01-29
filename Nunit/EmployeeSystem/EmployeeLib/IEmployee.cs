namespace EmployeeLib;

public interface IEmployee
{
    int Id { get; }
    string Name { get; }
    double BaseSalary { get; }

    double CalculateSalary();
}
