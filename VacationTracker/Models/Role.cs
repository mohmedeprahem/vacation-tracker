﻿using System.ComponentModel.DataAnnotations;

namespace VacationTracker.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
