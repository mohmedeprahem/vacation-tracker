using VacationTracker.Models;
using VacationTracker.ViewModels;

namespace VacationTracker.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(EmployeeViewModel body);
    }
}
