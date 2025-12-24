using UserDetails;
class MainSystem
{
    public static void Main()
    {
        StudentDetails[] students =
        [
            new StudentDetails(12413747, 3, "Sachin", 1),
            new StudentDetails(12409000, 3, "Sahil", 3),
            new StudentDetails(12325350, 3, "Ayushi", 2),
            new StudentDetails(12342554, 3, "Anushka", 3),
            new StudentDetails(12234344, 3, "Viakas", 1),
            new StudentDetails(13254545, 3, "Rammu", 1),
            new StudentDetails(12324554, 3, "Shammu", 2)
        ];

        ExaminerDetails[] examiners =
        [
            new ExaminerDetails(1222, 2, "Examiner 1", 11),
            new ExaminerDetails(1223, 2, "Examiner 2", 12),
            new ExaminerDetails(1224, 2, "Examiner 3", 13)
        ];

        HODDetails hod = new(1001, 1, "Adarsh", 2);
        HodFunction(hod, students, examiners);
    }

    public static void HodFunction(HODDetails hod, StudentDetails[] students, ExaminerDetails[] examiners)
    {
        int choice;

        Console.WriteLine($"\nWelcome Mr. {hod.Name}");

        do
        {
            Console.WriteLine("\nManagement System");
            Console.WriteLine("1. Assign Examiner");
            Console.WriteLine("2. Remove Examiner");
            Console.WriteLine("0. EXIT");
            Console.Write("\nEnter your Choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("\nOption 1 Selected\n");
                AssignExaminerToCourse(students, examiners);
            }
            else if (choice == 2)
            {
                Console.WriteLine("\nOption 2 Selected\n");
                RemoveExaminerFromCourse(students);
            }
            else if (choice == 0)
            {
                Console.WriteLine("\nThank You!!\n");
            }
            else
            {
                Console.WriteLine("\nInvalid Option!\n");
            }

        } while (choice != 0);
    }


    public static void AssignExaminerToCourse(StudentDetails[] students, ExaminerDetails[] examiners)
    {
        Console.Write("Enter Course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        Console.Write("Enter Examiner ID: ");
        int examinerId = int.Parse(Console.ReadLine());

        ExaminerDetails selectedExaminer = null;

        foreach (var examiner in examiners)
        {
            if (examiner.ExaminerID == examinerId)
            {
                selectedExaminer = examiner;
                break;
            }
        }

        if (selectedExaminer == null)
        {
            Console.WriteLine("Examiner not found!");
            return;
        }

        int assignedCount = 0;
        foreach (var student in students)
        {
            if (student.CourseID == courseId)
            {
                student.ExaminerID = examinerId;
                assignedCount++;
            }
        }

        Console.WriteLine($"Examiner assigned to {assignedCount} student(s)");
    }

    public static void RemoveExaminerFromCourse(StudentDetails[] students)
    {
        Console.Write("Enter Course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        int removedCount = 0;
        foreach (var student in students)
        {
            if (student.CourseID == courseId && student.ExaminerID != 0)
            {
                student.ExaminerID = 0;
                removedCount++;
            }
        }

        Console.WriteLine($"Examiner removed from {removedCount} student(s)");
    }
}