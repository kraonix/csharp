using System;
using System.Collections.Generic;

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectManager { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<TaskItem> Tasks { get; set; } = new();
}
