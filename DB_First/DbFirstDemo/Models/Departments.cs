using System;
using System.Collections.Generic;

namespace DbFirstDemo.Models;

public partial class Departments
{
    public int DepartmentID { get; set; }
    public string? DepartmentName { get; set; }
    public int? ManagerID { get; set; }
}
