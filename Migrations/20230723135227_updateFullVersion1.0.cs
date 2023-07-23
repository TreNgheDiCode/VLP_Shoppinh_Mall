using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateFullVersion10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DiaChi_MaDiaChi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanh_AspNetUsers_UserId",
                table: "ChiNhanh");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanh_DiaChi_MaDiaChi",
                table: "ChiNhanh");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhCuaHang_ChiNhanh_MaChiNhanh",
                table: "ChiNhanhCuaHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhCuaHang_CuaHang_MaCuaHang",
                table: "ChiNhanhCuaHang");

            migrationBuilder.DropForeignKey(
                name: "FK_CuaHang_AspNetUsers_UserId",
                table: "CuaHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaChi",
                table: "DiaChi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuaHang",
                table: "CuaHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiNhanh",
                table: "ChiNhanh");

            migrationBuilder.RenameTable(
                name: "DiaChi",
                newName: "DiaChis");

            migrationBuilder.RenameTable(
                name: "CuaHang",
                newName: "CuaHangs");

            migrationBuilder.RenameTable(
                name: "ChiNhanh",
                newName: "ChiNhanhs");

            migrationBuilder.RenameIndex(
                name: "IX_CuaHang_UserId",
                table: "CuaHangs",
                newName: "IX_CuaHangs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiNhanh_UserId",
                table: "ChiNhanhs",
                newName: "IX_ChiNhanhs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiNhanh_MaDiaChi",
                table: "ChiNhanhs",
                newName: "IX_ChiNhanhs_MaDiaChi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaChis",
                table: "DiaChis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuaHangs",
                table: "CuaHangs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiNhanhs",
                table: "ChiNhanhs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChietKhau = table.Column<float>(type: "real", nullable: true),
                    MaCuaHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuyenMais_CuaHangs_MaCuaHang",
                        column: x => x.MaCuaHang,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaTuyenDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NganhNghe = table.Column<int>(type: "int", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MangXaHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaTuyenDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhaTuyenDungs_DiaChis_DiaChiId",
                        column: x => x.DiaChiId,
                        principalTable: "DiaChis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuotMua = table.Column<int>(type: "int", nullable: true),
                    GiaThanh = table.Column<float>(type: "real", nullable: true),
                    LuotYeuThich = table.Column<int>(type: "int", nullable: true),
                    MaCuaHang = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhams_CuaHangs_MaCuaHang",
                        column: x => x.MaCuaHang,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TinTucs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoaiTinTuc = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTucs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinTucs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TuyenDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTuyenDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucLuong = table.Column<int>(type: "int", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaNhaTuyenDung = table.Column<int>(type: "int", nullable: false),
                    LoaiNgheNghiep = table.Column<int>(type: "int", nullable: true),
                    LoaiHinhTuyenDung = table.Column<int>(type: "int", nullable: true),
                    LoaiKinhNghiem = table.Column<int>(type: "int", nullable: true),
                    LoaiTrinhDo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TuyenDungs_NhaTuyenDungs_MaNhaTuyenDung",
                        column: x => x.MaNhaTuyenDung,
                        principalTable: "NhaTuyenDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMais_MaCuaHang",
                table: "KhuyenMais",
                column: "MaCuaHang");

            migrationBuilder.CreateIndex(
                name: "IX_NhaTuyenDungs_DiaChiId",
                table: "NhaTuyenDungs",
                column: "DiaChiId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaCuaHang",
                table: "SanPhams",
                column: "MaCuaHang");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_UserId",
                table: "SanPhams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TinTucs_UserId",
                table: "TinTucs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TuyenDungs_MaNhaTuyenDung",
                table: "TuyenDungs",
                column: "MaNhaTuyenDung");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DiaChis_MaDiaChi",
                table: "AspNetUsers",
                column: "MaDiaChi",
                principalTable: "DiaChis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhCuaHang_ChiNhanhs_MaChiNhanh",
                table: "ChiNhanhCuaHang",
                column: "MaChiNhanh",
                principalTable: "ChiNhanhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhCuaHang_CuaHangs_MaCuaHang",
                table: "ChiNhanhCuaHang",
                column: "MaCuaHang",
                principalTable: "CuaHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhs_AspNetUsers_UserId",
                table: "ChiNhanhs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhs_DiaChis_MaDiaChi",
                table: "ChiNhanhs",
                column: "MaDiaChi",
                principalTable: "DiaChis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuaHangs_AspNetUsers_UserId",
                table: "CuaHangs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DiaChis_MaDiaChi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhCuaHang_ChiNhanhs_MaChiNhanh",
                table: "ChiNhanhCuaHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhCuaHang_CuaHangs_MaCuaHang",
                table: "ChiNhanhCuaHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhs_AspNetUsers_UserId",
                table: "ChiNhanhs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhs_DiaChis_MaDiaChi",
                table: "ChiNhanhs");

            migrationBuilder.DropForeignKey(
                name: "FK_CuaHangs_AspNetUsers_UserId",
                table: "CuaHangs");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "TinTucs");

            migrationBuilder.DropTable(
                name: "TuyenDungs");

            migrationBuilder.DropTable(
                name: "NhaTuyenDungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaChis",
                table: "DiaChis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuaHangs",
                table: "CuaHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiNhanhs",
                table: "ChiNhanhs");

            migrationBuilder.RenameTable(
                name: "DiaChis",
                newName: "DiaChi");

            migrationBuilder.RenameTable(
                name: "CuaHangs",
                newName: "CuaHang");

            migrationBuilder.RenameTable(
                name: "ChiNhanhs",
                newName: "ChiNhanh");

            migrationBuilder.RenameIndex(
                name: "IX_CuaHangs_UserId",
                table: "CuaHang",
                newName: "IX_CuaHang_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiNhanhs_UserId",
                table: "ChiNhanh",
                newName: "IX_ChiNhanh_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiNhanhs_MaDiaChi",
                table: "ChiNhanh",
                newName: "IX_ChiNhanh_MaDiaChi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaChi",
                table: "DiaChi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuaHang",
                table: "CuaHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiNhanh",
                table: "ChiNhanh",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DiaChi_MaDiaChi",
                table: "AspNetUsers",
                column: "MaDiaChi",
                principalTable: "DiaChi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanh_AspNetUsers_UserId",
                table: "ChiNhanh",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanh_DiaChi_MaDiaChi",
                table: "ChiNhanh",
                column: "MaDiaChi",
                principalTable: "DiaChi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhCuaHang_ChiNhanh_MaChiNhanh",
                table: "ChiNhanhCuaHang",
                column: "MaChiNhanh",
                principalTable: "ChiNhanh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhCuaHang_CuaHang_MaCuaHang",
                table: "ChiNhanhCuaHang",
                column: "MaCuaHang",
                principalTable: "CuaHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuaHang_AspNetUsers_UserId",
                table: "CuaHang",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
