using VacationTracker.Models;

namespace VacationTracker.Interfaces.Repositories
{
    public interface IVacationRequestRepository
    {
        Task CreateOneAsync(VacationRequest vacationRequest);
    }
}
