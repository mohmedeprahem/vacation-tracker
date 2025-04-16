using VacationTracker.Database.Context;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Models;

namespace VacationTracker.Repositories
{
    public class VacationRequestRepository : IVacationRequestRepository
    {
        private readonly AppDbContext _context;

        public VacationRequestRepository(AppDbContext context) => _context = context;

        public async Task CreateOneAsync(VacationRequest vacationRequest)
        {
            await _context.VacationRequests.AddAsync(vacationRequest);
        }
    }
}
