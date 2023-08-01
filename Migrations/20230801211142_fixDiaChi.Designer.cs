﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VLPMall.Data;

#nullable disable

namespace VLPMall.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230801211142_fixDiaChi")]
    partial class fixDiaChi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VLPMall.Models.ChiNhanh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaDiaChi")
                        .HasColumnType("int");

                    b.Property<string>("NgayHoatDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChiNhanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThoiGianHoatDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MaDiaChi");

                    b.HasIndex("UserId");

                    b.ToTable("ChiNhanhs");
                });

            modelBuilder.Entity("VLPMall.Models.ChiNhanhCuaHang", b =>
                {
                    b.Property<int>("MaChiNhanh")
                        .HasColumnType("int");

                    b.Property<int>("MaCuaHang")
                        .HasColumnType("int");

                    b.Property<string>("DiaDiem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaChiNhanh", "MaCuaHang");

                    b.HasIndex("MaCuaHang");

                    b.ToTable("ChiNhanhCuaHang");
                });

            modelBuilder.Entity("VLPMall.Models.CuaHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoaiAmThuc")
                        .HasColumnType("int");

                    b.Property<int>("LoaiCuaHang")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiDichVu")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiGiaiTri")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiMuaSam")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiTienIch")
                        .HasColumnType("int");

                    b.Property<string>("NgayHoatDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCuaHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThoiGianHoatDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CuaHangs");
                });

            modelBuilder.Entity("VLPMall.Models.DiaChi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Duong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThanhPho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiaChis");
                });

            modelBuilder.Entity("VLPMall.Models.KhuyenMai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("ChietKhau")
                        .HasColumnType("real");

                    b.Property<int>("MaCuaHang")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhuyenMai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaCuaHang");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("VLPMall.Models.NhaTuyenDung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiThieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaDiaChi")
                        .HasColumnType("int");

                    b.Property<string>("MangXaHoi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NganhNghe")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhaTuyenDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangChu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaDiaChi");

                    b.ToTable("NhaTuyenDungs");
                });

            modelBuilder.Entity("VLPMall.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("GiaThanh")
                        .HasColumnType("real");

                    b.Property<int?>("LuotMua")
                        .HasColumnType("int");

                    b.Property<int?>("LuotYeuThich")
                        .HasColumnType("int");

                    b.Property<int>("MaCuaHang")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MaCuaHang");

                    b.HasIndex("UserId");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("VLPMall.Models.TinTuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoaiTinTuc")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TinTucs");
                });

            modelBuilder.Entity("VLPMall.Models.TuyenDung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LoaiHinhTuyenDung")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiKinhNghiem")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiNgheNghiep")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiTrinhDo")
                        .HasColumnType("int");

                    b.Property<int>("MaDiaChi")
                        .HasColumnType("int");

                    b.Property<int>("MaNhaTuyenDung")
                        .HasColumnType("int");

                    b.Property<int?>("MucLuong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuyenLoi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenTuyenDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YeuCau")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaDiaChi");

                    b.HasIndex("MaNhaTuyenDung");

                    b.ToTable("TuyenDungs");
                });

            modelBuilder.Entity("VLPMall.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MaDiaChi")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("MaDiaChi");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VLPMall.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VLPMall.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLPMall.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("VLPMall.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VLPMall.Models.ChiNhanh", b =>
                {
                    b.HasOne("VLPMall.Models.DiaChi", "DiaChi")
                        .WithMany("ChiNhanhs")
                        .HasForeignKey("MaDiaChi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLPMall.Models.User", "User")
                        .WithMany("ChiNhanh")
                        .HasForeignKey("UserId");

                    b.Navigation("DiaChi");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VLPMall.Models.ChiNhanhCuaHang", b =>
                {
                    b.HasOne("VLPMall.Models.ChiNhanh", "ChiNhanh")
                        .WithMany("ChiNhanhCuaHang")
                        .HasForeignKey("MaChiNhanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLPMall.Models.CuaHang", "CuaHang")
                        .WithMany("ChiNhanhCuaHangs")
                        .HasForeignKey("MaCuaHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiNhanh");

                    b.Navigation("CuaHang");
                });

            modelBuilder.Entity("VLPMall.Models.CuaHang", b =>
                {
                    b.HasOne("VLPMall.Models.User", "User")
                        .WithMany("CuaHang")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VLPMall.Models.KhuyenMai", b =>
                {
                    b.HasOne("VLPMall.Models.CuaHang", "CuaHang")
                        .WithMany("KhuyenMais")
                        .HasForeignKey("MaCuaHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuaHang");
                });

            modelBuilder.Entity("VLPMall.Models.NhaTuyenDung", b =>
                {
                    b.HasOne("VLPMall.Models.DiaChi", "DiaChi")
                        .WithMany("NhaTuyenDungs")
                        .HasForeignKey("MaDiaChi");

                    b.Navigation("DiaChi");
                });

            modelBuilder.Entity("VLPMall.Models.SanPham", b =>
                {
                    b.HasOne("VLPMall.Models.CuaHang", "CuaHang")
                        .WithMany("SanPhams")
                        .HasForeignKey("MaCuaHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLPMall.Models.User", "User")
                        .WithMany("SanPhams")
                        .HasForeignKey("UserId");

                    b.Navigation("CuaHang");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VLPMall.Models.TinTuc", b =>
                {
                    b.HasOne("VLPMall.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VLPMall.Models.TuyenDung", b =>
                {
                    b.HasOne("VLPMall.Models.DiaChi", "DiaChi")
                        .WithMany()
                        .HasForeignKey("MaDiaChi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLPMall.Models.NhaTuyenDung", "NhaTuyenDung")
                        .WithMany("TuyenDungs")
                        .HasForeignKey("MaNhaTuyenDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiaChi");

                    b.Navigation("NhaTuyenDung");
                });

            modelBuilder.Entity("VLPMall.Models.User", b =>
                {
                    b.HasOne("VLPMall.Models.DiaChi", "DiaChi")
                        .WithMany("Users")
                        .HasForeignKey("MaDiaChi");

                    b.Navigation("DiaChi");
                });

            modelBuilder.Entity("VLPMall.Models.ChiNhanh", b =>
                {
                    b.Navigation("ChiNhanhCuaHang");
                });

            modelBuilder.Entity("VLPMall.Models.CuaHang", b =>
                {
                    b.Navigation("ChiNhanhCuaHangs");

                    b.Navigation("KhuyenMais");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("VLPMall.Models.DiaChi", b =>
                {
                    b.Navigation("ChiNhanhs");

                    b.Navigation("NhaTuyenDungs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VLPMall.Models.NhaTuyenDung", b =>
                {
                    b.Navigation("TuyenDungs");
                });

            modelBuilder.Entity("VLPMall.Models.User", b =>
                {
                    b.Navigation("ChiNhanh");

                    b.Navigation("CuaHang");

                    b.Navigation("SanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
