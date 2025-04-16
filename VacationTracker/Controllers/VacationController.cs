using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using VacationTracker.Interfaces.Services;
using VacationTracker.ViewModels;

namespace VacationTracker.Controllers
{
    public class VacationController : Controller
    {
        private readonly IVacationService _vacationService;

        public VacationController(IVacationService vacationService)
        {
            _vacationService = vacationService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VacationRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                ClaimsPrincipal user = HttpContext.User;

                string? userId = user.FindFirst("Id")?.Value;

                if (userId == null)
                {
                    ModelState.AddModelError("", "User is not authenticated.");
                    return View(model);
                }

                var vacation = await _vacationService.CreateVacationRequestAsync(model, userId);

                var newModel = new VacationRequestViewModel
                {
                    Title = vacation.Title,
                    VacationDateFrom = vacation.VacationDateFrom,
                    VacationDateTo = vacation.VacationDateTo,
                    ReturningDate = vacation.ReturningDate,
                    TotalDaysRequested = vacation.TotalDaysRequested,
                    SubmissionDate = vacation.SubmissionDate
                };

                return View(newModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An unexpected error occurred. Please try again later."
                );
                return View(model);
            }
        }
    }
}
