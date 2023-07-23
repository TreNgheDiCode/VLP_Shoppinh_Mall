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
                    LoaiAmThuc = LoaiAmThuc.DoAnNhanh,
                    SanPhams = new List<SanPham>()
                    {
                        new SanPham()
                        {
                            TenSanPham = "Gà rán cay",
                            NoiDung = "Gà rán này cay",
                            AnhDaiDien = "https://images.foody.vn/res/g1/1559/s400x400/a4f75…deb-4025-8f54-d0f2c5d4-d85c77e4-230706100809.jpeg",
                            GiaThanh = 80000,
                        },
                        new SanPham()
                        {
                            TenSanPham = "Gà rán không cay",
                            NoiDung = "Gà rán này không cay",
                            AnhDaiDien = "https://images.foody.vn/res/g1/1559/s400x400/85987…e10-4ed5-9c1e-8b09bfd5-dcc552d8-210615111854.jpeg",
                            GiaThanh = 100000
                        }
                    },
                    KhuyenMais = new List<KhuyenMai>()
                            {
                                new KhuyenMai()
                                {
                                    TenKhuyenMai = "Giảm giá 10%",
                                    NgayBatDau = DateTime.Now,
                                    NgayKetThuc = new DateTime(2023, 8, 1, 16, 0, 0, DateTimeKind.Local),
                                    ChietKhau = 0.1f,
                                },
                                new KhuyenMai()
                                {
                                    TenKhuyenMai = "Giảm giá 20%",
                                    NgayBatDau = DateTime.Now,
                                    NgayKetThuc = new DateTime(2023, 8, 1, 20, 30, 0, DateTimeKind.Local),
                                    ChietKhau = 0.2f,
                                },
                                new KhuyenMai()
                                {
                                    TenKhuyenMai = "Giảm giá 15%",
                                    NgayBatDau = DateTime.Now,
                                    NgayKetThuc = new DateTime(2023, 8, 1, 20, 0, 0, DateTimeKind.Local),
                                    ChietKhau = 0.15f,
                                },
                                new KhuyenMai()
                                {
                                    TenKhuyenMai = "Giảm giá 8%",
                                    NgayBatDau = DateTime.Now,
                                    NgayKetThuc = new DateTime(2023, 8, 1, 16, 0, 0, DateTimeKind.Local),
                                    ChietKhau = 0.08f,
                                }
                            }
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

                var tinTuc = new List<TinTuc>()
                {
                    new TinTuc()
                    {
                        TieuDe = "Đại hạ giá các món đồ cần hạ giá",
                        NoiDung = "Đây là 1 đoạn văn bản cần được làm thành văn bản",
                        AnhDaiDien = "https://contents.smsupermalls.com/data/uploads/2023/07/super_fur_moms_article_july_2023.png",
                        LoaiTinTuc = LoaiTinTuc.BaiViet,
                        TrangThai = false
                    },
                    new TinTuc()
                    {
                        TieuDe = "Khuyến mãi cho bạn thích ăn gà",
                        NoiDung = "Đây là khuyến mãi dành cho gà",
                        AnhDaiDien = "https://contents.smsupermalls.com/data/uploads/2023/07/super_fur_moms_article_july_2023.png",
                        LoaiTinTuc = LoaiTinTuc.KhuyenMai,
                        TrangThai = false
                    }
                };

                var nhaTuyenDung = new List<NhaTuyenDung>()
                {
                    new NhaTuyenDung()
                    {
                        NganhNghe = LoaiNgheNghiep.CongNgheThongTin,
                        SoDienThoai = "0763615414",
                        Email = "gabayan170@gmail.com",
                        MangXaHoi = "https://www.facebook.com/gabayan.long",
                        TrangChu = "https://www.facebook.com/gabayan.long",
                        DiaChi = new DiaChi()
                        {
                            Duong = "153 Nam Kỳ Khởi Nghĩa",
                            Phuong = "Võ Thị Sáu",
                            Quan = "3",
                            ThanhPho = "Tp. Hồ Chí Minh"
                        },
                        TuyenDungs = new List<TuyenDung>()
                        {
                            new TuyenDung()
                            {
                                TenTuyenDung = "Bạn có muốn đi làm không?",
                                NoiDung = "Đây là việc làm dành cho những người mê code",
                                MucLuong = 2500000,
                                NgayDang = DateTime.Now,
                                NgayHetHan = new DateTime(2023, 8, 1, 16, 0, 0, DateTimeKind.Local),
                                LoaiNgheNghiep = LoaiNgheNghiep.CongNgheThongTin,
                                LoaiHinhTuyenDung = LoaiHinhTuyenDung.Internship,
                                LoaiKinhNghiem = LoaiKinhNghiem.KhongYeuCau,
                                LoaiTrinhDo = LoaiTrinhDo.PhoThong
                            },
                            new TuyenDung()
                            {
                                TenTuyenDung = "Tuyển dụng dành cho những người thích lập trình",
                                NoiDung = "Bạn biết code? Bạn có niềm đam mê học hỏi với code? Bạn thích làm ra các dự án khác nhau? Hãy apply ngay!",
                                NgayDang = DateTime.Now,
                                NgayHetHan = new DateTime(2023, 8, 1, 16, 0, 0, DateTimeKind.Local),
                                LoaiNgheNghiep = LoaiNgheNghiep.CongNgheThongTin,
                                LoaiHinhTuyenDung = LoaiHinhTuyenDung.FullTime,
                                LoaiKinhNghiem = LoaiKinhNghiem.Tu1Den2Nam,
                                LoaiTrinhDo = LoaiTrinhDo.CuNhan
                            }
                        }
                    }
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

                if (!context.TinTucs.Any())
                {
                    context.TinTucs.AddRange(tinTuc);
                }

                if (!context.TuyenDungs.Any())
                {
                    context.NhaTuyenDungs.AddRange(nhaTuyenDung);
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