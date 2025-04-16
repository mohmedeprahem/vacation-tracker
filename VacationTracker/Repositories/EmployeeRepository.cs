using VacationTracker.Database.Context;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Models;

namespace VacationTracker.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) => _context = context;

        public async Task CreateOneAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }
    }
}
