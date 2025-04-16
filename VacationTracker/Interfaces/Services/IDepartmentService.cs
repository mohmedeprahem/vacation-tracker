using VacationTracker.Models;

namespace VacationTracker.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartments();
    }
}
