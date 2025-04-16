using VacationTracker.Models;

namespace VacationTracker.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email, string[] includes = null);
    }
}
