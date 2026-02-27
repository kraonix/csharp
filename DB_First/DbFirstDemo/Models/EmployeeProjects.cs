using System;
using System.Collections.Generic;

namespace DbFirstDemo.Models;

public partial class EmployeeProjects
{
    public int EmployeeID { get; set; }
    public int ProjectID { get; set; }
    public string? Role { get; set; }
    public int? HoursWorked { get; set; }
    public virtual Employees Employee { get; set; } = null!;
    public virtual Projects Project { get; set; } = null!;
}
