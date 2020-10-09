using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Role = Application.Contract.Model.Common.Roles;

namespace Application.Settings
{
    public static class SeedData
    {
        private static readonly string[] Roles = new string[]
        {
            Role.Administrator,
            Role.Student,
            Role.Teacher
        };
        static UserManager<Entities.User> userManager;
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using (var seviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = seviceScope.ServiceProvider.GetRequiredService<RoleManager<Entities.Role>>();
                userManager = seviceScope.ServiceProvider.GetRequiredService<UserManager<Entities.User>>();

                //Add roles in system
                foreach(var role in Roles)
                {
                    await roleManager.CreateAsync(new Entities.Role() { Name = role });
                }
                await CreateUser("admin@system.com", "admin", "super", "admin", Role.Administrator);
                await CreateUser("student@system.com", "student", "student", "1", Role.Student);
                await CreateUser("teacher@system.com", "teacher", "teacher", "1", Role.Teacher);
            }
        }
        private static async Task CreateUser(string email, string userName, string firstName, string lastName, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new Entities.User()
                {
                    UserName = userName,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, "abcde12345-");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                  
                }
            }
        }
    }
}
