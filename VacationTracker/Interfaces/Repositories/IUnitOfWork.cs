namespace VacationTracker.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IRoleRepository RoleRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IVacationRequestRepository VacationRequestRepository { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
