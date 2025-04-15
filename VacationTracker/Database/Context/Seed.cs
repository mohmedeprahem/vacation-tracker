using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VacationTracker.Models;
using static System.Formats.Asn1.AsnWriter;

namespace VacationTracker.Database.Context
{
    public static class AppDbInitializer
    {
        public static void Seeds(AppDbContext context, IConfiguration config)
        {
            // Seed Departments
            if (!context.Departments.Any())
            {
                context
                    .Departments
                    .AddRange(
                        new Department { Name = "Hr" },
                        new Department { Name = "Development" }
                    );
                context.SaveChanges();
            }

            // Seed Roles
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new Role { Name = "Admin" }, new Role { Name = "Employee" });
                context.SaveChanges();
            }

            // Seed Admin User
            if (!context.Users.Any())
            {
                var adminEmail = config["Admin:Email"];
                var adminPassword = config["Admin:Password"];

                var hasher = new PasswordHasher<User>();
                var adminUser = new User { Email = adminEmail, RoleId = 1 };
                adminUser.PasswordHash = hasher.HashPassword(adminUser, adminPassword);

                context.Users.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}
