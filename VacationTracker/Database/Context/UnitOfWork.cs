using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Repositories;

namespace VacationTracker.Database.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IDbContextTransaction _transaction;
        public IUserRepository UserRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
            EmployeeRepository = new EmployeeRepository(_dbContext);
            RoleRepository = new RoleRepository(_dbContext);
            DepartmentRepository = new DepartmentRepository(_dbContext);
            _transaction = null;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
