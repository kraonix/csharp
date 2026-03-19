namespace UniversityManagementSystem.Models
{
    public class FacultyProfile
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Designation { get; set; }
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}