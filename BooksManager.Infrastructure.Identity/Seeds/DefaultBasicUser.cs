using BooksManager.Core.Application.Enums;
using BooksManager.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BooksManager.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "UserBasic",
                Email = "UserBasic@gmail.com",
                FirstName = "Carlitos",
                LastName = "Ramirez",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };


            if(userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if(user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$Word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
        }
    }
}
