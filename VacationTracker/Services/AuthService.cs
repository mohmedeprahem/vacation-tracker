using Microsoft.AspNetCore.Mvc;
using VacationTracker.DTOs;
using VacationTracker.Interfaces;
using VacationTracker.Utilities;

namespace VacationTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService)
        {
            this._unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthResponseDto?> Login(string email, string password)
        {
            var user = await _unitOfWork
                .UserRepository
                .GetUserByEmailAsync(email, ["Role", "Employee"]);

            if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
                return null;

            var token = _jwtTokenService.GenerateToken(user, user.Role.Name);

            var userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user?.Employee?.FullName ?? string.Empty
            };

            return new AuthResponseDto { Token = token, User = userDto };
        }
    }
}
