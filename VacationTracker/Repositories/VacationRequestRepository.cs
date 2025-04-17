using Microsoft.EntityFrameworkCore;
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

        public async Task<List<VacationRequest>> GetAllAsync(string[]? includes = null)
        {
            IQueryable<VacationRequest> query = _context.Set<VacationRequest>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<VacationRequest?> GetById(int id, string[]? includes = null)
        {
            IQueryable<VacationRequest> query = _context.VacationRequests;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
