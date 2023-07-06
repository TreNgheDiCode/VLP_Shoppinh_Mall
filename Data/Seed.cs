using Microsoft.AspNetCore.Identity;
using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                context.Database.EnsureCreated();

                if (!context.Agencies.Any())
                {
                    context.Agencies.AddRange(new List<Agency>()
                    {
                        new Agency()
                        {
                            Title = "Chi nhánh Sư Vạn Hạnh",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "Trung tâm thương mại VLP Mall",
                            AddressId = 1,
                            AgencyCategory = AgencyCategory.SVH
                         },
                    });
                    context.SaveChanges();
                }
                //Races
                //if (!context.Races.Any())
                //{
                //    context.Races.AddRange(new List<Race>()
                //    {
                //        new Race()
                //        {
                //            Title = "Running Race 1",
                //            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //            Description = "This is the description of the first race",
                //            RaceCategory = RaceCategory.Marathon,
                //            Address = new Address()
                //            {
                //                Street = "123 Main St",
                //                City = "Charlotte",
                //                State = "NC"
                //            }
                //        },
                //        new Race()
                //        {
                //            Title = "Running Race 2",
                //            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //            Description = "This is the description of the first race",
                //            RaceCategory = RaceCategory.Ultra,
                //            AddressId = 5,
                //            Address = new Address()
                //            {
                //                Street = "123 Main St",
                //                City = "Charlotte",
                //                State = "NC"
                //            }
                //        }
                //    });
                //    context.SaveChanges();
                //}
            }
        }
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
