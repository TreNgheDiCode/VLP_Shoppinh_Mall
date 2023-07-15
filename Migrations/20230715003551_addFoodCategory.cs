using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class addFoodCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoaiAmThuc",
                table: "CuaHang",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiAmThuc",
                table: "CuaHang");
        }
    }
}
