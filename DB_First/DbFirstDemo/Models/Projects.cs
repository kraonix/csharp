using System;
using System.Collections.Generic;

namespace DbFirstDemo.Models;

public partial class Projects
{
    public int ProjectID { get; set; }
    public string? ProjectName { get; set; }
    public decimal? Budget { get; set; }
    public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();
}
