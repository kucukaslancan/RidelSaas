using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ridel.Domain.Entities;
using Ridel.Domain.Entities.Role;
using Ridel.Domain.Enums;

namespace Ridel.Persistence.Seeds
{
    public static class SeedRolesService
    {
        public static async Task SeedRolesAsync(this IServiceProvider serviceProvider)
        {
            RoleManager<ApplicationRole>? roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            UserManager<User>? userManager = serviceProvider.GetRequiredService<UserManager<User>>();


            IEnumerable<string>? roles = Enum.GetValues(typeof(UserRoles)).Cast<UserRoles>().Select(r => r.ToString());

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole(role));
                }
            }

            User? adminUser = new User
            {
                UserName = "can",
                Email = "admin@can.com",
                EmailConfirmed = true,
                FirstName = "Can Küçükaslan"

            };


            if (await userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                IdentityResult? addUser = await userManager.CreateAsync(adminUser, "61");
                if (addUser.Succeeded)
                {

                    await userManager.AddToRoleAsync(adminUser, UserRoles.Admin.ToString());
                }
            }
        }
    }
}
