using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}