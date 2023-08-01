using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TuyenDungs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NhaTuyenDungs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TuyenDungs_UserId",
                table: "TuyenDungs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NhaTuyenDungs_UserId",
                table: "NhaTuyenDungs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhaTuyenDungs_AspNetUsers_UserId",
                table: "NhaTuyenDungs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TuyenDungs_AspNetUsers_UserId",
                table: "TuyenDungs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhaTuyenDungs_AspNetUsers_UserId",
                table: "NhaTuyenDungs");

            migrationBuilder.DropForeignKey(
                name: "FK_TuyenDungs_AspNetUsers_UserId",
                table: "TuyenDungs");

            migrationBuilder.DropIndex(
                name: "IX_TuyenDungs_UserId",
                table: "TuyenDungs");

            migrationBuilder.DropIndex(
                name: "IX_NhaTuyenDungs_UserId",
                table: "NhaTuyenDungs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TuyenDungs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NhaTuyenDungs");
        }
    }
}
