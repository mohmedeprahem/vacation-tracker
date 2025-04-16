using VacationTracker.enums;
using VacationTracker.Exceptions;
using VacationTracker.Interfaces;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Interfaces.Services;
using VacationTracker.Models;
using VacationTracker.Utilities;
using VacationTracker.ViewModels;

namespace VacationTracker.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Employee> CreateEmployee(EmployeeViewModel body)
        {
            var existingUser = await _unitOfWork.UserRepository.GetUserByEmailAsync(body.Email);

            if (existingUser != null)
            {
                throw new EmailAlreadyExistsException(body.Email);
            }

            var existingRole = await _unitOfWork
                .RoleRepository
                .GetRoleByName(RoleEnum.Employee.ToString());

            if (existingRole == null)
                throw new Exception();
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var newUser = new User
                {
                    Email = body.Email,
                    PasswordHash = PasswordHasher.HashPassword(body.Password),
                    RoleId = existingRole.Id,
                };
                await _unitOfWork.UserRepository.CreateOneAsync(newUser);

                await _unitOfWork.SaveChangesAsync();

                var employee = new Employee
                {
                    FullName = body.FullName,
                    UserId = newUser.Id,
                    DepartmentId = body.DepartmentId
                };

                await _unitOfWork.EmployeeRepository.CreateOneAsync(employee);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return employee;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
