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
            VacationRequest newVacation = new VacationRequest
            {
                Title = model.Title,
                VacationDateFrom = model.VacationDateFrom,
                VacationDateTo = model.VacationDateTo,
                EmployeeId = int.Parse(userId)
            };

            await _unitOfWork.VacationRequestRepository.CreateOneAsync(newVacation);

            await _unitOfWork.SaveChangesAsync();

            return newVacation;
        }
    }
}
