using System.ComponentModel.DataAnnotations;

namespace VacationTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public int? RoleId { get; set; }
        public Role? Role { get; set; }

        public Employee Employee { get; set; }
    }
}
