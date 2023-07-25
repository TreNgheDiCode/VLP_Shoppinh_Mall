using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class EditCuaHangViewModel
	{
		public int Id { get; set; }
		public string TenCuaHang { get; set; }
		public string? NoiDung { get; set; }
        public IFormFile? HinhDaiDien { get; set; }
        public string? AnhDaiDien { get; set; }
		public string? Email { get; set; }
		public string? SoDienThoai { get; set; }
		public string? NgayHoatDong { get; set; }
		public string? NgayHoatDong1 { get; set; }
		public string? NgayHoatDong2 { get; set; }
		public string? ThoiGianHoatDong { get; set; }
		public string? ThoiGianHoatDong1 { get; set; }
		public string? ThoiGianHoatDong2 { get; set; }
        public string? DiaDiem { get; set; }
        public LoaiCuaHang LoaiCuaHang { get; set; }
		public LoaiAmThuc? LoaiAmThuc { get; set; }
		public Task<IEnumerable<ChiNhanh>>? ChiNhanhs { get; set; }
		public List<int>? SelectedChiNhanh { get; set; }
        public Task<ICollection<SanPham>>? SanPhams { get; set; }
        public List<int>? SelectedSanPham { get; set; }
    }
}
