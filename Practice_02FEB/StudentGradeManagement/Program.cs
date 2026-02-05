using System;
namespace StudentGrade
{
    class Program
    {
        static void Main()
        {
            SchoolManager manager = new SchoolManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== STUDENT GRADE MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade");
                Console.WriteLine("3. View Students Grouped by Grade Level");
                Console.WriteLine("4. Calculate Student Average");
                Console.WriteLine("5. Calculate Subject Averages");
                Console.WriteLine("6. Get Top Performers");
                Console.WriteLine("7. View All Students");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Grade Level (9th/10th/11th/12th): ");
                            string grade = Console.ReadLine();
                            manager.AddStudent(name, grade);
                            Console.WriteLine("Student added successfully");
                            break;

                        case 2:
                            Console.Write("Student ID: ");
                            int sid = int.Parse(Console.ReadLine());
                            Console.Write("Subject: ");
                            string subject = Console.ReadLine();
                            Console.Write("Grade: ");
                            double marks = double.Parse(Console.ReadLine());
                            manager.AddGrade(sid, subject, marks);
                            Console.WriteLine("Grade added");
                            break;

                        case 3:
                            var grouped = manager.GroupStudentsByGradeLevel();
                            foreach (var g in grouped)
                            {
                                Console.WriteLine($"\nGrade Level: {g.Key}");
                                foreach (var s in g.Value)
                                    Console.WriteLine($"{s.StudentId} - {s.Name}");
                            }
                            break;

                        case 4:
                            Console.Write("Student ID: ");
                            int avgId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Average: " + manager.CalculateStudentAverage(avgId));
                            break;

                        case 5:
                            var subjectAvg = manager.CalculateSubjectAverages();
                            foreach (var sa in subjectAvg)
                                Console.WriteLine($"{sa.Key}: {sa.Value}");
                            break;

                        case 6:
                            Console.Write("Top N students: ");
                            int n = int.Parse(Console.ReadLine());
                            var top = manager.GetTopPerformers(n);
                            foreach (var s in top)
                                Console.WriteLine($"{s.Name} - Avg: {s.Subjects.Values.Average()}");
                            break;

                        case 7:
                            foreach (var s in manager.GetAllStudents())
                                Console.WriteLine($"{s.StudentId} | {s.Name} | {s.GradeLevel}");
                            break;

                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}