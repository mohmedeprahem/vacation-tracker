using System.ComponentModel.DataAnnotations;

namespace VacationTracker.ViewModels
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(
            100,
            MinimumLength = 1,
            ErrorMessage = "FullName must be between 1 and 100 characters."
        )]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(
            100,
            MinimumLength = 6,
            ErrorMessage = "Password must be between 6 and 100 characters."
        )]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [StringLength(
            100,
            MinimumLength = 6,
            ErrorMessage = "ConfirmPassword must be between 6 and 100 characters."
        )]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
