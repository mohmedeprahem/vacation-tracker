using System.Security.Claims;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Interfaces.Services;
using VacationTracker.Models;
using VacationTracker.ViewModels;

namespace VacationTracker.Services
{
    public class VacationService : IVacationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VacationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<VacationRequest> CreateVacationRequestAsync(
            VacationRequestViewModel model,
            string userId
        )
        {
            var user = await _unitOfWork
                .UserRepository
                .GetUserByIdAsync(int.Parse(userId), ["Employee"]);

            if (user == null || user.Employee == null)
            {
                throw new Exception("Server Error");
            }

            VacationRequest newVacation = new VacationRequest
            {
                Title = model.Title,
                VacationDateFrom = model.VacationDateFrom,
                VacationDateTo = model.VacationDateTo,
                EmployeeId = user.Employee.Id,
                Note = model.Note,
            };

            await _unitOfWork.VacationRequestRepository.CreateOneAsync(newVacation);

            await _unitOfWork.SaveChangesAsync();

            return newVacation;
        }

        public async Task<List<VacationRequest>> GetAllVacationRequestAsync()
        {
            var vacations = await _unitOfWork
                .VacationRequestRepository
                .GetAllAsync(["Employee", "Employee.Department"]);

            return vacations;
        }

        public async Task<VacationRequest?> GetVacationRequestByIdAsync(int id)
        {
            var vacation = await _unitOfWork
                .VacationRequestRepository
                .GetById(id, ["Employee", "Employee.Department"]);

            return vacation;
        }
    }
}
