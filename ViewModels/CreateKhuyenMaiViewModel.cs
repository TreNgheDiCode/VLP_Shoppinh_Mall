using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class CreateKhuyenMaiViewModel
	{
        public string? TenKhuyenMai { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public float? ChietKhau { get; set; }
        public string? UserId { get; set; }
        public int? MaCuaHang { get; set; }
        public ICollection<CuaHang>? CuaHangs { get; set; }
		public List<int>? SelectedCuaHang { get; set; }
	}
}
