namespace StudentPortal_MVC.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public int DurationDays { get; set; }

        public decimal Fee { get; set; }

        public string Level { get; set; }
    }
}