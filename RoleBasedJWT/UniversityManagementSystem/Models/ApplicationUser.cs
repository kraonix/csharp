using Microsoft.AspNetCore.Identity;

namespace UniversityManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsFirstLogin { get; set; } = true;
    }
}