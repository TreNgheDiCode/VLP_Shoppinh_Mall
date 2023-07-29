using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class addGioiThieuNhaTuyenDung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GioiThieu",
                table: "NhaTuyenDungs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GioiThieu",
                table: "NhaTuyenDungs");
        }
    }
}
