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

                context?.Database.EnsureCreated();

                if (!context.ChiNhanh.Any())
                {
                    context.ChiNhanh.AddRange(new List<ChiNhanh>()
                    {
                        new ChiNhanh()
                        {
                            TenChiNhanh = "Chi nhánh Sư Vạn Hạnh",
                            NoiDung = "Tọa lạc tại quận 10, chuyên cho thuê các cửa hàng lớn nhỏ theo mô hình doanh nghiệp...",
                            AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688255253/p6o014rxqprsdnqxjvli.jpg",
                            Email = "gabayan170@gmail.com",
                            SoDienThoai = "0763615414",
                            NgayHoatDong = "Thứ Hai - Chủ Nhật",
                            ThoiGianHoatDong = "08:00 - 21:00",
                            DiaChi = new DiaChi()
                            {
                                Duong = "828 Sư Vạn Hạnh",
                                Phuong = "Phường 13",
                                Quan = "Quận 10",
                                ThanhPho = "Thành phố Hồ Chí Minh",
                            },
                            ChiNhanhCuaHang = new List<ChiNhanhCuaHang>()
                            {
                                new ChiNhanhCuaHang
                                {
                                    CuaHang = new CuaHang()
                                    {
                                        TenCuaHang = "Lotteria Việt Nam",
                                        NoiDung = "Cửa hàng gà rán thơm ngon",
                                        AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688909823/Chi%E1%BA%BFc_%C3%B4__11_aqmzoj.jpg",
                                        Email = "gabayan170@gmail.com",
                                        SoDienThoai = "0763615414",
                                        NgayHoatDong = "Thứ Hai - Chủ Nhật",
                                        ThoiGianHoatDong = "08:00 - 21:00",
                                        LoaiCuaHang = LoaiCuaHang.AmThuc,
                                        LoaiAmThuc = LoaiAmThuc.DoAnNhanh
                                    }
                                },
                                new ChiNhanhCuaHang
                                {
                                    CuaHang = new CuaHang()
                                    {
                                        TenCuaHang = "CGV Vietnam",
                                        NoiDung = "Đi xem phim khum",
                                        AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688909823/Chi%E1%BA%BFc_%C3%B4__11_aqmzoj.jpg",
                                        Email = "gabayan170@gmail.com",
                                        SoDienThoai = "0763615414",
                                        NgayHoatDong = "Thứ Hai - Chủ Nhật",
                                        ThoiGianHoatDong = "08:00 - 21:00",
                                        LoaiCuaHang = LoaiCuaHang.RapChieuPhim,
                                        LoaiRapChieuPhim = LoaiRapChieuPhim.FullHD
                                    }
                                }
                            }
                        },
                        new ChiNhanh()
                        {
                            TenChiNhanh = "Chi nhánh Hóc Môn",
                            NoiDung = "Tọa lạc tại thị trấn Hóc Môn, chuyên cho thuê các cửa hàng lớn nhỏ theo mô hình doanh nghiệp...",
                            AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688255253/p6o014rxqprsdnqxjvli.jpg",
                            Email = "gabayan170@gmail.com",
                            SoDienThoai = "0763615414",
                            NgayHoatDong = "Thứ Hai - Chủ Nhật",
                            ThoiGianHoatDong = "08:00 - 21:00",
                            DiaChi = new DiaChi()
                            {
                                Duong = "10 Quốc lộ 22",
                                Phuong = "Phường Tân Xuân",
                                Quan = "Thị trấn Hóc Môn",
                                ThanhPho = "Thành phố Hồ Chí Minh",
                            }
                        }
                    });

                    context.SaveChanges();
                }
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
                        MaDiaChi = 1
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
                        MaDiaChi = 2
                    };
                    await userManager.CreateAsync(newUser, "Test!1234@");
                    await userManager.AddToRoleAsync(newUser, UserRoles.User);
                }
            }
        }
    }
}