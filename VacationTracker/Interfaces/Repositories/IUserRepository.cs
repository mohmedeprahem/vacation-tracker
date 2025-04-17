using VacationTracker.Models;

namespace VacationTracker.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email, string[] includes = null);
        Task CreateOneAsync(User user);
        Task<User?> GetUserByIdAsync(int id, string[]? includes = null);
    }
}
