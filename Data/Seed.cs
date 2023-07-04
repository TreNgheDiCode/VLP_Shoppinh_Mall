using Microsoft.AspNetCore.Identity;
using VLPMall.Models;

namespace VLPMall.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "gabayan170@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "QuangLong",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "828 Sư Vạn Hạnh",
                            City = "Tp. Hồ Chí Minh",
                            Ward = "Phường 13",
                            District = "Quận 10"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Test!1234@");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string UserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(UserEmail);
                if (appUser == null)
                {
                    var newUser = new User()
                    {
                        UserName = "user-testing",
                        Email = UserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "153 Nam Kỳ Khởi Nghĩa",
                            City = "Tp. Hồ Chí Minh",
                            Ward = "Phường Võ Thị Sáu",
                            District = "Quận 3"
                        }
                    };
                    await userManager.CreateAsync(newUser, "Test!1234@");
                    await userManager.AddToRoleAsync(newUser, UserRoles.User);
                }
            }
        }
    }
}
