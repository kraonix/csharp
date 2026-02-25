using System.ComponentModel.DataAnnotations;
public class Employee
{
    
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Name must contain only alphabets.")]
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}