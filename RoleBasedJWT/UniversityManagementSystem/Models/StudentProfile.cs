namespace UniversityManagementSystem.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string RollNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}