using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class CuaHang
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên cửa hàng")]
        public string TenCuaHang { get; set; }
        public string? NoiDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string? NgayHoatDong { get; set; }
        public string? ThoiGianHoatDong { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public LoaiCuaHang LoaiCuaHang { get; set; }

        // Liên kết nhiều nhiều
        public ICollection<ChiNhanhCuaHang>? ChiNhanhCuaHang { get; set; }
    }
}
