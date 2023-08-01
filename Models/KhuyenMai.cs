using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class KhuyenMai
    {
        public int Id { get; set; }
        public string? TenKhuyenMai { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public float? ChietKhau { get; set; } = 0;
        [ForeignKey("CuaHang")]
        public int MaCuaHang { get; set; }
        public CuaHang CuaHang { get; set; }
		[ForeignKey("User")]
		public string? UserId { get; set; }
		public User? User { get; set; }
	}
}
