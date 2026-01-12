/// <summary>
/// Represents a collection of employees in the payroll system.
/// </summary>
namespace PayRoll
{
    /// <summary>
    /// Gets the list of employees in the payroll system.
    /// This property is initialized as an empty list and cannot be reassigned.
    /// </summary>
    /// <remarks>
    /// The list can be modified by adding or removing employee objects,
    /// but the property reference itself is read-only.
    /// </remarks>
    public class Employees
    {
        public List<Employee> EmpList { get; } = new List<Employee>();
    }
}