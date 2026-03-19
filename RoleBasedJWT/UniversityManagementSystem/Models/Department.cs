namespace UniversityManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public List<Course> Courses { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}