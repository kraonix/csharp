using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LearningManager manager = new LearningManager();

        // -------- Hardcoded Initial Data --------
        manager.AddCourse(
            "C101",
            "C# Fundamentals",
            "Amit",
            6,
            2999,
            new List<string> { "Basics", "OOP", "Collections", "LINQ" });

        manager.AddCourse(
            "J101",
            "Java Basics",
            "Neha",
            8,
            3499,
            new List<string> { "Syntax", "OOP", "Streams" });

        manager.EnrollStudent("S001", "C101");
        manager.EnrollStudent("S002", "C101");
        manager.EnrollStudent("S001", "J101");
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nE-LEARNING PLATFORM");
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. Enroll Student");
            Console.WriteLine("3. Update Progress");
            Console.WriteLine("4. Group Courses by Instructor");
            Console.WriteLine("5. View Top Performing Students");
            Console.WriteLine("6. View All Courses");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Course Code: ");
                    string code = Console.ReadLine();

                    Console.Write("Course Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Instructor: ");
                    string instructor = Console.ReadLine();

                    Console.Write("Duration (weeks): ");
                    int weeks = int.Parse(Console.ReadLine());

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Modules (comma separated): ");
                    var modules = new List<string>(
                        Console.ReadLine().Split(',',
                        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

                    manager.AddCourse(code, name, instructor, weeks, price, modules);
                    Console.WriteLine("Course added successfully.");
                    break;

                case 2:
                    Console.Write("Student ID: ");
                    string studentId = Console.ReadLine();

                    Console.Write("Course Code: ");
                    string courseCode = Console.ReadLine();

                    Console.WriteLine(manager.EnrollStudent(studentId, courseCode)
                        ? "Enrollment successful."
                        : "Enrollment failed.");
                    break;

                case 3:
                    Console.Write("Student ID: ");
                    string sid = Console.ReadLine();

                    Console.Write("Course Code: ");
                    string ccode = Console.ReadLine();

                    Console.Write("Module Name: ");
                    string module = Console.ReadLine();

                    Console.Write("Score: ");
                    double score = double.Parse(Console.ReadLine());

                    Console.WriteLine(manager.UpdateProgress(sid, ccode, module, score)
                        ? "Progress updated."
                        : "Update failed.");
                    break;

                case 4:
                    var grouped = manager.GroupCoursesByInstructor();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nInstructor: {g.Key}");
                        foreach (var c in g.Value)
                            Console.WriteLine($"{c.CourseCode} - {c.CourseName}");
                    }
                    break;

                case 5:
                    Console.Write("Course Code: ");
                    string topCourse = Console.ReadLine();

                    Console.Write("Number of students: ");
                    int count = int.Parse(Console.ReadLine());

                    var topStudents = manager.GetTopPerformingStudents(topCourse, count);
                    foreach (var e in topStudents)
                    {
                        Console.WriteLine(
                            $"Student: {e.StudentId}, Progress: {e.ProgressPercentage}%");
                    }
                    break;

                case 6:
                    foreach (var c in manager.GetAllCourses())
                    {
                        Console.WriteLine(
                            $"{c.CourseCode} - {c.CourseName} | Instructor: {c.Instructor}");
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
