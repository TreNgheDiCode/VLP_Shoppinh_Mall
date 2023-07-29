using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateTuyenDung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaDiaChi",
                table: "TuyenDungs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QuyenLoi",
                table: "TuyenDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "TuyenDungs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "YeuCau",
                table: "TuyenDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TuyenDungs_MaDiaChi",
                table: "TuyenDungs",
                column: "MaDiaChi");

            migrationBuilder.AddForeignKey(
                name: "FK_TuyenDungs_DiaChis_MaDiaChi",
                table: "TuyenDungs",
                column: "MaDiaChi",
                principalTable: "DiaChis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuyenDungs_DiaChis_MaDiaChi",
                table: "TuyenDungs");

            migrationBuilder.DropIndex(
                name: "IX_TuyenDungs_MaDiaChi",
                table: "TuyenDungs");

            migrationBuilder.DropColumn(
                name: "MaDiaChi",
                table: "TuyenDungs");

            migrationBuilder.DropColumn(
                name: "QuyenLoi",
                table: "TuyenDungs");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "TuyenDungs");

            migrationBuilder.DropColumn(
                name: "YeuCau",
                table: "TuyenDungs");
        }
    }
}
