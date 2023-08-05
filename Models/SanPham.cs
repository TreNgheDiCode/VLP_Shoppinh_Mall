using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        public string? TenSanPham { get; set; }
        public string? NoiDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public int? LuotMua { get; set; } = 0;
        public float? GiaThanh { get; set; } = 0;
        public int? LuotYeuThich { get; set; } = 0;
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<CuaHangSanPham>? CuaHangSanPhams { get; set; }
    }
}
