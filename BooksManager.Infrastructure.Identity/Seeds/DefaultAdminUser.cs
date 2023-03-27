using BooksManager.Core.Application.Enums;
using BooksManager.Infrastructure.Identity.Entities;
using DnsClient.Protocol;
using Microsoft.AspNetCore.Identity;

namespace BooksManager.Infrastructure.Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "UserAdmin",
                Email = "UserAdmin@gmail.com",
                FirstName = "Carlos",
                LastName = "Ramirez",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if(user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }

        }
    }
}
