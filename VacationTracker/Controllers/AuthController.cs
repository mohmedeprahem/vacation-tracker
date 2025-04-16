using System.Diagnostics;
using System.Net;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VacationTracker.Interfaces.Services;
using VacationTracker.Models;
using VacationTracker.ViewModels;

namespace VacationTracker.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            try
            {
                var response = await _authService.Login(
                    loginViewModel.Email,
                    loginViewModel.Password
                );

                if (response == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                    return View(loginViewModel);
                }

                Response
                    .Cookies
                    .Append(
                        "AccessToken",
                        response.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime
                                .UtcNow
                                .AddMinutes(_config.GetValue<int>("Jwt:ExpiryIn"))
                        }
                    );

                if (response.User.Role != null && response.User.Role.Name == "Admin")
                {
                    return RedirectToAction("Create", "Employee");
                }
                else
                {
                    return RedirectToAction("Create", "Vacation");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An unexpected error occurred. Please try again later."
                );
                return View(loginViewModel);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("AccessToken");

            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
