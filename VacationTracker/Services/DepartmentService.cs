using VacationTracker.Interfaces.Repositories;
using VacationTracker.Interfaces.Services;
using VacationTracker.Models;

namespace VacationTracker.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _unitOfWork.DepartmentRepository.GetDepartmentsAsync();
        }
    }
}
