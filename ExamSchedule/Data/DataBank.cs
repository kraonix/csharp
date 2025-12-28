using ExamSchedule.Model;

namespace ExamSchedule.Data
{
    public static class DataBank
    {
        public static List<Student> students;

        public static List<StudentSessions> sessions;

        static DataBank()
        {
            students = new List<Student>
            {
                new Student { Id = 1, Name = "Sachin" },
                new Student { Id = 2, Name = "Ayushi" },
                new Student { Id = 3, Name = "Anuska" },
                new Student { Id = 4, Name = "Sahil" },
                new Student { Id = 5, Name = "Shubham" }
            };

            sessions = new List<StudentSessions>
            {
                new StudentSessions{Id = "CAP", Name = "MCA", Description = "Computer Application"},
                new StudentSessions{Id = "CSE", Name = "B.Tech", Description = "Computer Science"},
                new StudentSessions{Id = "BUS", Name = "MBA", Description = "Business"}
            };
        }

        public static List<Student> GetStudents()
        {
            return students;
        }

        public static List<StudentSessions> GetSessions()
        {
            return sessions;
        }
    }
}
