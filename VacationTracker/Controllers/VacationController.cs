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

        public async Task<IActionResult> Index()
        {
            try
            {
                var vacations = await _vacationService.GetAllVacationRequestAsync();

                var model = vacations.Select(
                    v =>
                        new VacationRequestViewModel
                        {
                            Id = v.Id,
                            Title = v.Title,
                            Note = v.Note,
                            VacationDateFrom = v.VacationDateFrom,
                            VacationDateTo = v.VacationDateTo,
                            ReturningDate = v.ReturningDate,
                            TotalDaysRequested = v.TotalDaysRequested,
                            SubmissionDate = v.SubmissionDate,
                            Employee = v.Employee,
                        }
                );

                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An unexpected error occurred. Please try again later."
                );
                return View();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var vacation = await _vacationService.GetVacationRequestByIdAsync(id);

                if (vacation == null)
                {
                    return NotFound();
                }

                var model = new VacationRequestViewModel
                {
                    Id = vacation.Id,
                    Title = vacation.Title,
                    Note = vacation.Note,
                    VacationDateFrom = vacation.VacationDateFrom,
                    VacationDateTo = vacation.VacationDateTo,
                    ReturningDate = vacation.ReturningDate,
                    TotalDaysRequested = vacation.TotalDaysRequested,
                    SubmissionDate = vacation.SubmissionDate,
                    Employee = vacation.Employee,
                };

                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An unexpected error occurred. Please try again later."
                );
                return View();
            }
        }
    }
}
