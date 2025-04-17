using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationTracker.Models
{
    public class VacationRequest
    {
        public int Id { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string Title { get; set; }

        public string? Note { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime VacationDateFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime VacationDateTo { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [NotMapped]
        public DateTime ReturningDate => GetNextWorkingDay(VacationDateTo);

        [NotMapped]
        public int TotalDaysRequested => GetWorkingDays(VacationDateFrom, VacationDateTo);

        public DateTime GetNextWorkingDay(DateTime fromDate)
        {
            var date = fromDate.AddDays(1);

            while (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(1);
            }
            return date;
        }

        public int GetWorkingDays(DateTime fromDate, DateTime toDate)
        {
            int days = 0;

            for (var day = fromDate.Date; day.Date <= toDate.Date; day = day.AddDays(1))
            {
                if (day.DayOfWeek != DayOfWeek.Friday && day.DayOfWeek != DayOfWeek.Saturday)
                    days++;
            }

            return days;
        }
    }
}
