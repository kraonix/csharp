namespace UserDetails
{
    public class HODDetails : CommonUser
    {
        public int DepartmentID;

        public HODDetails(int id, int roleid, string name, int departmentid) : base(id, roleid, name)
        {
            this.DepartmentID = departmentid;
        }

        public void HodFunction(HODDetails hod, StudentDetails[] students, ExaminerDetails[] examiners)
        {
            int choice;

            Console.WriteLine($"\nWelcome Mr. {hod.Name}({hod.Role})");

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
                else if( choice == 3)
                {
                    Console.WriteLine("\nOption 2 Selected\n");
                    ViewExaminer(examiners, students);
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


        public void AssignExaminerToCourse(StudentDetails[] students, ExaminerDetails[] examiners)
        {

            Console.WriteLine("Available Courses: ");
            string temp = string.Empty;
            foreach (var s in students)
            {
                if (s.ExaminerID == 0)
                {
                    if (s.CourseID == 1)
                    {
                        temp = "MCA";
                    }
                    else if (s.CourseID == 2)
                    {
                        temp = "B.Tech";
                    }
                    else if (s.CourseID == 3)
                    {
                        temp = "MBA";
                    }
                    else
                    {
                        temp = "Invalid Course!";
                    }
                    Console.WriteLine($"ID: {s.CourseID} => {temp}");
                }
            }

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

        public void RemoveExaminerFromCourse(StudentDetails[] students)
        {
            Console.WriteLine("Available Courses: ");
            string temp = string.Empty;
            foreach (var s in students)
            {
                if(s.ExaminerID != 0)
                {
                    if (s.CourseID == 1)
                    {
                        temp = "MCA";
                    }
                    else if (s.CourseID == 2)
                    {
                        temp = "B.Tech";
                    }
                    else if (s.CourseID == 3)
                    {
                        temp = "MBA";
                    }
                    else
                    {
                        temp = "Invalid Course!";
                    }
                    Console.WriteLine($"ID: {s.CourseID} => {temp}");
                }
            }

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

        public void ViewExaminer(ExaminerDetails[] e, StudentDetails[] s)
        {
            if(s.ExaminerID != 0)
            {
                foreach(var temp in s)
                {
                    Console.WriteLine($"");
                }
            }
        }
    }
}