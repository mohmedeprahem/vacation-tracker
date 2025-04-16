using Microsoft.AspNetCore.Mvc;
using VacationTracker.DTOs;

namespace VacationTracker.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> Login(string email, string password);
    }
}
