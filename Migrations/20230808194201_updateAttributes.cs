using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhuyenMais_CuaHangs_MaCuaHang",
                table: "KhuyenMais");

            migrationBuilder.AlterColumn<bool>(
                name: "TrangThai",
                table: "TinTucs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaCuaHang",
                table: "KhuyenMais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_KhuyenMais_CuaHangs_MaCuaHang",
                table: "KhuyenMais",
                column: "MaCuaHang",
                principalTable: "CuaHangs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhuyenMais_CuaHangs_MaCuaHang",
                table: "KhuyenMais");

            migrationBuilder.AlterColumn<bool>(
                name: "TrangThai",
                table: "TinTucs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "MaCuaHang",
                table: "KhuyenMais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KhuyenMais_CuaHangs_MaCuaHang",
                table: "KhuyenMais",
                column: "MaCuaHang",
                principalTable: "CuaHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
