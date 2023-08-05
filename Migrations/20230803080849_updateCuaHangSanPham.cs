using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateCuaHangSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_CuaHangs_MaCuaHang",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_MaCuaHang",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "MaCuaHang",
                table: "SanPhams");

            migrationBuilder.CreateTable(
                name: "CuaHangSanPham",
                columns: table => new
                {
                    MaCuaHang = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHangSanPham", x => new { x.MaCuaHang, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_CuaHangSanPham_CuaHangs_MaCuaHang",
                        column: x => x.MaCuaHang,
                        principalTable: "CuaHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuaHangSanPham_SanPhams_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuaHangSanPham_MaSanPham",
                table: "CuaHangSanPham",
                column: "MaSanPham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuaHangSanPham");

            migrationBuilder.AddColumn<int>(
                name: "MaCuaHang",
                table: "SanPhams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaCuaHang",
                table: "SanPhams",
                column: "MaCuaHang");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_CuaHangs_MaCuaHang",
                table: "SanPhams",
                column: "MaCuaHang",
                principalTable: "CuaHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
