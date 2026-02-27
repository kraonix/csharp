using System;
using System.Collections.Generic;

namespace DbFirstDemo.Models;

public partial class Employees
{
    public int EmployeeID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? DepartmentID { get; set; }
    public decimal? Salary { get; set; }
    public DateOnly? HireDate { get; set; }
    public virtual Departments? Department { get; set; }
    public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();
}