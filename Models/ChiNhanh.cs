using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class ChiNhanh
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên chi nhánh")]
        public string TenChiNhanh { get; set; }
        public string NoiDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string NgayHoatDong { get; set; }
        public string ThoiGianHoatDong { get; set; }
        [ForeignKey("DiaChi")]
        public int MaDiaChi { get; set; }
        public DiaChi? DiaChi { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        // Liên kết nhiều nhiều
        public ICollection<ChiNhanhCuaHang>? ChiNhanhCuaHang { get; set; }
    }
}
