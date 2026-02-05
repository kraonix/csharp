using System;
using System.Collections.Generic;
using System.Linq;

public class TaskManager
{
    private readonly List<Project> _projects = new();
    private int _projectIdCounter = 1;
    private int _taskIdCounter = 1;

    // Create Project
    public void CreateProject(string name, string manager,
                              DateTime start, DateTime end)
    {
        _projects.Add(new Project
        {
            ProjectId = _projectIdCounter++,
            ProjectName = name,
            ProjectManager = manager,
            StartDate = start,
            EndDate = end
        });
    }

    // Add Task
    public void AddTask(int projectId, string title, string description,
                        string priority, DateTime dueDate, string assignee)
    {
        var project = _projects.FirstOrDefault(p => p.ProjectId == projectId);
        if (project == null)
            return;

        project.Tasks.Add(new TaskItem
        {
            TaskId = _taskIdCounter++,
            Title = title,
            Description = description,
            Priority = priority,
            Status = "ToDo",
            DueDate = dueDate,
            AssignedTo = assignee
        });
    }

    // Group Tasks by Priority
    public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
    {
        return _projects
            .SelectMany(p => p.Tasks)
            .GroupBy(t => t.Priority)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Get Overdue Tasks
    public List<TaskItem> GetOverdueTasks()
    {
        return _projects
            .SelectMany(p => p.Tasks)
            .Where(t => t.DueDate < DateTime.Now && t.Status != "Completed")
            .ToList();
    }

    // Get Tasks by Assignee
    public List<TaskItem> GetTasksByAssignee(string assigneeName)
    {
        return _projects
            .SelectMany(p => p.Tasks)
            .Where(t => t.AssignedTo.Equals(assigneeName,
                   StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Helpers for menu
    public List<Project> GetAllProjects() => _projects;
}
