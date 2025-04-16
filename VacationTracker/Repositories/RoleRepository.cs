using Microsoft.EntityFrameworkCore;
using VacationTracker.Database.Context;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Models;

namespace VacationTracker.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) => _context = context;

        public async Task<Role?> GetRoleByName(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
