using Microsoft.EntityFrameworkCore;
using VacationTracker.Database.Context;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Models;

namespace VacationTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) => _context = context;

        public async Task CreateOneAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByEmailAsync(string email, string[] includes = null)
        {
            IQueryable<User> query = _context.Set<User>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
