namespace UniversityManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}