using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateCuaHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoaiRapChieuPhim",
                table: "CuaHang",
                newName: "LoaiTienIch");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianHoatDong",
                table: "CuaHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "CuaHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NgayHoatDong",
                table: "CuaHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiDichVu",
                table: "CuaHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiGiaiTri",
                table: "CuaHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiMuaSam",
                table: "CuaHang",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianHoatDong",
                table: "ChiNhanh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "ChiNhanh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NgayHoatDong",
                table: "ChiNhanh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiDichVu",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "LoaiGiaiTri",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "LoaiMuaSam",
                table: "CuaHang");

            migrationBuilder.RenameColumn(
                name: "LoaiTienIch",
                table: "CuaHang",
                newName: "LoaiRapChieuPhim");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianHoatDong",
                table: "CuaHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "CuaHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NgayHoatDong",
                table: "CuaHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianHoatDong",
                table: "ChiNhanh",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "ChiNhanh",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NgayHoatDong",
                table: "ChiNhanh",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
