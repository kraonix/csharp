using System;

class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();

        // -------- Hardcoded Initial Data --------
        manager.CreateProject("Website Revamp", "Amit",
            DateTime.Now.AddDays(-10), DateTime.Now.AddMonths(1));

        manager.CreateProject("Mobile App", "Neha",
            DateTime.Now.AddDays(-5), DateTime.Now.AddMonths(2));

        manager.AddTask(1, "Design Home Page", "Create UI mockups",
            "High", DateTime.Now.AddDays(3), "Rahul");

        manager.AddTask(1, "Setup Backend", "API and database setup",
            "Medium", DateTime.Now.AddDays(-1), "Sneha");

        manager.AddTask(2, "Login Module", "Authentication logic",
            "High", DateTime.Now.AddDays(5), "Rahul");
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nTASK MANAGEMENT SYSTEM");
            Console.WriteLine("1. Create Project");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Group Tasks by Priority");
            Console.WriteLine("4. View Overdue Tasks");
            Console.WriteLine("5. View Tasks by Assignee");
            Console.WriteLine("6. View All Projects and Tasks");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Project Name: ");
                    string pname = Console.ReadLine();

                    Console.Write("Project Manager: ");
                    string pmanager = Console.ReadLine();

                    Console.Write("Start Date (yyyy-mm-dd): ");
                    DateTime start = DateTime.Parse(Console.ReadLine());

                    Console.Write("End Date (yyyy-mm-dd): ");
                    DateTime end = DateTime.Parse(Console.ReadLine());

                    manager.CreateProject(pname, pmanager, start, end);
                    Console.WriteLine("Project created successfully.");
                    break;

                case 2:
                    Console.WriteLine("Available Projects:");
                    foreach (var p in manager.GetAllProjects())
                        Console.WriteLine($"{p.ProjectId} - {p.ProjectName}");

                    Console.Write("Project ID: ");
                    int pid = int.Parse(Console.ReadLine());

                    Console.Write("Task Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Description: ");
                    string desc = Console.ReadLine();

                    Console.Write("Priority (High/Medium/Low): ");
                    string priority = Console.ReadLine();

                    Console.Write("Due Date (yyyy-mm-dd): ");
                    DateTime due = DateTime.Parse(Console.ReadLine());

                    Console.Write("Assigned To: ");
                    string assignee = Console.ReadLine();

                    manager.AddTask(pid, title, desc, priority, due, assignee);
                    Console.WriteLine("Task added successfully.");
                    break;

                case 3:
                    var grouped = manager.GroupTasksByPriority();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nPriority: {g.Key}");
                        foreach (var t in g.Value)
                            Console.WriteLine($"{t.TaskId} - {t.Title}");
                    }
                    break;

                case 4:
                    var overdue = manager.GetOverdueTasks();
                    if (overdue.Count == 0)
                    {
                        Console.WriteLine("No overdue tasks.");
                    }
                    else
                    {
                        foreach (var t in overdue)
                        {
                            Console.WriteLine(
                                $"{t.TaskId} - {t.Title} | Due: {t.DueDate:d}");
                        }
                    }
                    break;

                case 5:
                    Console.Write("Assignee Name: ");
                    string name = Console.ReadLine();

                    var tasks = manager.GetTasksByAssignee(name);
                    foreach (var t in tasks)
                    {
                        Console.WriteLine(
                            $"{t.TaskId} - {t.Title} | Priority: {t.Priority}");
                    }
                    break;

                case 6:
                    foreach (var p in manager.GetAllProjects())
                    {
                        Console.WriteLine(
                            $"\nProject: {p.ProjectName} (Manager: {p.ProjectManager})");
                        foreach (var t in p.Tasks)
                        {
                            Console.WriteLine(
                                $"{t.TaskId} - {t.Title} | {t.Status} | Due: {t.DueDate:d}");
                        }
                    }
                    break;

                case 0:
                    exit = true;
                    Console.WriteLine("Exiting application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
