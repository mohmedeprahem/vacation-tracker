namespace VacationTracker.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<VacationRequest>? VacationRequests { get; set; }
    }
}
