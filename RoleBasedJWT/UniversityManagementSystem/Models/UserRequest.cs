namespace UniversityManagementSystem.Models
{
    public class UserRequest
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Student / Faculty

        public bool IsApproved { get; set; } = false;
    }
}