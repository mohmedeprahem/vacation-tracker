using VacationTracker.Models;

namespace VacationTracker.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateOneAsync(Employee employee);
    }
}
