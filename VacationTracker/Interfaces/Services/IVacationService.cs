﻿using VacationTracker.Models;
using VacationTracker.ViewModels;

namespace VacationTracker.Interfaces.Services
{
    public interface IVacationService
    {
        Task<VacationRequest> CreateVacationRequestAsync(
            VacationRequestViewModel model,
            string userId
        );
    }
}
