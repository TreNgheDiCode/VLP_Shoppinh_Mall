using System.ComponentModel.DataAnnotations.Schema;
using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class NhaTuyenDung
    {
        public int Id { get; set; }
        public string? TenNhaTuyenDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? GioiThieu { get; set; }
        public LoaiNgheNghiep? NganhNghe { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? MangXaHoi { get; set; }
        public string? TrangChu { get; set; }
		[ForeignKey("DiaChi")]
		public int? MaDiaChi { get; set; }
		public DiaChi? DiaChi { get; set; }
		[ForeignKey("User")]
		public string? UserId { get; set; }
		public User? User { get; set; }

		public ICollection<TuyenDung>? TuyenDungs { get; set; }
    }
}
