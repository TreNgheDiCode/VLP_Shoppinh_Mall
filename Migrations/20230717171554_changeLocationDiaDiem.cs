using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class changeLocationDiaDiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaDiem",
                table: "CuaHang");

            migrationBuilder.AddColumn<string>(
                name: "DiaDiem",
                table: "ChiNhanhCuaHang",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaDiem",
                table: "ChiNhanhCuaHang");

            migrationBuilder.AddColumn<string>(
                name: "DiaDiem",
                table: "CuaHang",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
