using Microsoft.EntityFrameworkCore;
using VacationTracker.Database.Context;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Models;

namespace VacationTracker.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context) => _context = context;

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
