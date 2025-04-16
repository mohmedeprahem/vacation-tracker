using VacationTracker.Models;

namespace VacationTracker.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, string role);
    }
}
