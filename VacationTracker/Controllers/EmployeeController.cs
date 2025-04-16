using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VacationTracker.Exceptions;
using VacationTracker.Interfaces.Repositories;
using VacationTracker.Interfaces.Services;
using VacationTracker.ViewModels;

namespace VacationTracker.Controllers
{
    [Authorize(policy: "AdminOnly")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(
            IEmployeeService employeeService,
            IDepartmentService departmentService
        )
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.GetAllDepartments();

            var viewModel = new EmployeeViewModel
            {
                Departments = departments
                    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.GetAllDepartments();

                model.Departments = departments
                    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                    .ToList();

                return View(model);
            }

            try
            {
                var newEmployee = await _employeeService.CreateEmployee(model);

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
