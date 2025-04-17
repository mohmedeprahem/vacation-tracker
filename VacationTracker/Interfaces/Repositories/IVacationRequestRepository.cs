using VacationTracker.Models;

namespace VacationTracker.Interfaces.Repositories
{
    public interface IVacationRequestRepository
    {
        Task CreateOneAsync(VacationRequest vacationRequest);

        Task<List<VacationRequest>> GetAllAsync(string[]? includes = null);
        Task<VacationRequest?> GetById(int id, string[]? includes = null);
    }
}
