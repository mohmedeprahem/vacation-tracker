using VacationTracker.Models;

namespace VacationTracker.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentsAsync();
    }
}
