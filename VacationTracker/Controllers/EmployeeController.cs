using Microsoft.AspNetCore.Mvc;
using VacationTracker.Exceptions;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Interfaces.Services;
using VacationTracker.ViewModels;

namespace VacationTracker.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeSerivce;

        public EmployeeController(IEmployeeService employeeSerivce)
        {
            _employeeSerivce = employeeSerivce;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var newEmployee = await _employeeSerivce.CreateEmployee(model);

                TempData["Success"] = "Employee created successfully!";

                return RedirectToAction("Create");
            }
            catch (EmailAlreadyExistsException ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return View(model);
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
