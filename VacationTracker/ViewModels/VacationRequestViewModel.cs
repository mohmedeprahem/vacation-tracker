using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VacationTracker.Models;

namespace VacationTracker.ViewModels
{
    public class VacationRequestViewModel : IValidatableObject
    {
        public int? Id { get; set; }

        public DateTime? SubmissionDate { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Vacation start from")]
        public DateTime VacationDateFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Vacation end to")]
        public DateTime VacationDateTo { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Returning Date")]
        public DateTime? ReturningDate { get; set; }

        [Display(Name = "Total Days Requested")]
        public int? TotalDaysRequested { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (VacationDateFrom.Date < DateTime.Today)
            {
                yield return new ValidationResult(
                    "Vacation start date cannot be in the past.",
                    new[] { nameof(VacationDateFrom) }
                );
            }

            if (VacationDateTo.Date < VacationDateFrom.Date)
            {
                yield return new ValidationResult(
                    "Vacation end date cannot be earlier than start date.",
                    new[] { nameof(VacationDateTo) }
                );
            }
        }
    }
}
