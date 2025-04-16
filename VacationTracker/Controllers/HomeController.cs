using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace VacationTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal user = HttpContext.User;

            string? userRole = user.FindFirst(ClaimTypes.Role)?.Value;

            switch (userRole)
            {
                case "Employee":
                    return RedirectToAction("Create", "Vacation");
                case "Admin":
                    return RedirectToAction("Create", "Employee");
                default:
                    return RedirectToAction("Login", "Auth");
            }
        }
    }
}
