﻿using VacationTracker.Models;

namespace VacationTracker.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? FullName { get; set; }
        public Role? Role { get; set; }
        public Employee? Employee { get; set; }
    }
}
