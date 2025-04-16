using VacationTracker.Models;

namespace VacationTracker.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleByName(string roleName);
    }
}
