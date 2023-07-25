using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLPMall.Migrations
{
    /// <inheritdoc />
    public partial class updateAdminDashboarView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhaTuyenDungs_DiaChis_DiaChiId",
                table: "NhaTuyenDungs");

            migrationBuilder.RenameColumn(
                name: "DiaChiId",
                table: "NhaTuyenDungs",
                newName: "MaDiaChi");

            migrationBuilder.RenameIndex(
                name: "IX_NhaTuyenDungs_DiaChiId",
                table: "NhaTuyenDungs",
                newName: "IX_NhaTuyenDungs_MaDiaChi");

            migrationBuilder.AddColumn<string>(
                name: "TenNhaTuyenDung",
                table: "NhaTuyenDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NhaTuyenDungs_DiaChis_MaDiaChi",
                table: "NhaTuyenDungs",
                column: "MaDiaChi",
                principalTable: "DiaChis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhaTuyenDungs_DiaChis_MaDiaChi",
                table: "NhaTuyenDungs");

            migrationBuilder.DropColumn(
                name: "TenNhaTuyenDung",
                table: "NhaTuyenDungs");

            migrationBuilder.RenameColumn(
                name: "MaDiaChi",
                table: "NhaTuyenDungs",
                newName: "DiaChiId");

            migrationBuilder.RenameIndex(
                name: "IX_NhaTuyenDungs_MaDiaChi",
                table: "NhaTuyenDungs",
                newName: "IX_NhaTuyenDungs_DiaChiId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhaTuyenDungs_DiaChis_DiaChiId",
                table: "NhaTuyenDungs",
                column: "DiaChiId",
                principalTable: "DiaChis",
                principalColumn: "Id");
        }
    }
}
