using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateKhuyenMai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "KhuyenMais",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMais_UserId",
                table: "KhuyenMais",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_KhuyenMais_AspNetUsers_UserId",
                table: "KhuyenMais",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhuyenMais_AspNetUsers_UserId",
                table: "KhuyenMais");

            migrationBuilder.DropIndex(
                name: "IX_KhuyenMais_UserId",
                table: "KhuyenMais");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "KhuyenMais");
        }
    }
}
