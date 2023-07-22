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

                var chiNhanh1 = new ChiNhanh()
                {
                    TenChiNhanh = "Chi nhánh Sư Vạn Hạnh",
                    NoiDung = "Đây là chi nhánh Sư Vạn Hạnh",
                    AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688934275/LogoMall_SVH_bvyvqu.jpg",
                    Email = "gabayan170@gmail.com",
                    SoDienThoai = "0763615414",
                    NgayHoatDong = "Thứ Hai - Chủ Nhật",
                    ThoiGianHoatDong = "9:00 - 16:00",
                    DiaChi = new DiaChi()
                    {
                        Duong = "828 Sư Vạn Hạnh",
                        Phuong = "Phường 13",
                        Quan = "Quận 10",
                        ThanhPho = "Thành phố Hồ Chí Minh"
                    }
                };

                var chiNhanh2 = new ChiNhanh()
                {
                    TenChiNhanh = "Chi nhánh Hóc Môn",
                    NoiDung = "Đây là chi nhánh Hóc Môn",
                    AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688934275/LogoMall_SVH_bvyvqu.jpg",
                    Email = "gabayan298@gmail.com",
                    SoDienThoai = "0708611304",
                    NgayHoatDong = "Thứ Hai - Thứ Bảy",
                    ThoiGianHoatDong = "9:00 - 21:00",
                    DiaChi = new DiaChi()
                    {
                        Duong = "10 QL22",
                        Phuong = "Tân Xuân",
                        Quan = "Hóc Môn",
                        ThanhPho = "Thành phố Hồ Chí Minh"
                    }
                };

                var cuaHang1 = new CuaHang()
                {
                    TenCuaHang = "Lotteria Việt Nam",
                    NoiDung = "Đây là cửa hàng ẩm thực - đồ ăn nhanh",
                    AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688895189/lotteria_logo_cmyouc.svg",
                    Email = "lotteria@gmail.com",
                    SoDienThoai = "0708611304",
                    NgayHoatDong = "Thứ Hai - Thứ Sáu",
                    ThoiGianHoatDong = "8:00 - 21:00",
                    LoaiCuaHang = LoaiCuaHang.AmThuc,
                    LoaiAmThuc = LoaiAmThuc.DoAnNhanh
                };

                var cuaHang2 = new CuaHang()
                {
                    TenCuaHang = "KFC Việt Nam",
                    NoiDung = "Đây là cửa hàng ẩm thực - đồ ăn nhanh",
                    AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688895189/lotteria_logo_cmyouc.svg",
                    Email = "lotteria@gmail.com",
                    SoDienThoai = "0763615414",
                    NgayHoatDong = "Thứ Ba - Chủ Nhật",
                    ThoiGianHoatDong = "9:00 - 22:00",
                    LoaiCuaHang = LoaiCuaHang.AmThuc,
                    LoaiAmThuc = LoaiAmThuc.DoAnNhanh
                };

                var cuaHang3 = new CuaHang()
                {
                    TenCuaHang = "CGV Việt Nam",
                    NoiDung = "Đây là cửa hàng giải trí - rạp chiếu phim",
                    AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1688934543/chv_logo_v9dnx2.png",
                    Email = "cgv@gmail.com",
                    SoDienThoai = "0708611304",
                    NgayHoatDong = "Thứ Hai - Thứ Sáu",
                    ThoiGianHoatDong = "8:00 - 23:00",
                    LoaiCuaHang = LoaiCuaHang.GiaiTri,
                    LoaiGiaiTri = LoaiGiaiTri.RapChieuPhim
                };

                var cuaHang4 = new CuaHang()
                {
                    TenCuaHang = "Adidas",
                    NoiDung = "Đây là cửa hàng mua sắm - giày dép",
                    AnhDaiDien = "https://res.cloudinary.com/drv0jpgyx/image/upload/v1689888964/805cd5b94b10db6156ef33c341b30631_pbtkot.webp",
                    Email = "adidas@gmail.com",
                    SoDienThoai = "0763615414",
                    NgayHoatDong = "Thứ Hai - Chủ Nhật",
                    ThoiGianHoatDong = "9:00 - 21:30",
                    LoaiCuaHang = LoaiCuaHang.MuaSam,
                    LoaiMuaSam = LoaiMuaSam.GiayDep
                };

                if (!context.ChiNhanhCuaHang.Any())
                {
                    context.ChiNhanhCuaHang.AddRange(new List<ChiNhanhCuaHang>()
                    {
                        new ChiNhanhCuaHang()
                        {
                            ChiNhanh = chiNhanh1,
                            CuaHang = cuaHang1,
                            DiaDiem = chiNhanh1.TenChiNhanh + " - Tầng 3"
                        },
                        new ChiNhanhCuaHang()
                        {
                            ChiNhanh = chiNhanh1,
                            CuaHang = cuaHang2,
                            DiaDiem = chiNhanh1.TenChiNhanh + " - Block B, Tầng 2"
                        },
                        new ChiNhanhCuaHang()
                        {
                            ChiNhanh = chiNhanh1,
                            CuaHang = cuaHang3,
                            DiaDiem = chiNhanh1.TenChiNhanh + "- Chưa có"
                        },
                        new ChiNhanhCuaHang()
                        {
                            ChiNhanh = chiNhanh1,
                            CuaHang = cuaHang4,
                            DiaDiem = chiNhanh1.TenChiNhanh + " - Khu Thời trang, Tầng 1"
                        },
                        new ChiNhanhCuaHang()
                        {
                            ChiNhanh = chiNhanh2,
                            CuaHang = cuaHang1,
                            DiaDiem = chiNhanh2.TenChiNhanh + " - Tầng 6"
                        },
                        new ChiNhanhCuaHang()
                        {
                            ChiNhanh = chiNhanh2,
                            CuaHang = cuaHang4,
                            DiaDiem = chiNhanh2.TenChiNhanh + " - Khu Phức hợp, Tầng 3"
                        },
                    });
                }

                context.SaveChanges();
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