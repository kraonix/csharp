namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }

        // Relationships
        public string FacultyId { get; set; }
        public ApplicationUser Faculty { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
}