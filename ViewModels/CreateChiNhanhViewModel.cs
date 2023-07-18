using Microsoft.AspNetCore.Mvc.Rendering;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class CreateChiNhanhViewModel
	{
		public int Id { get; set; }
		public string TenChiNhanh { get; set; }
		public string? NoiDung { get; set; }
		public IFormFile? AnhDaiDien { get; set; }
		public string? Email { get; set; }
		public string? SoDienThoai { get; set; }
		public string? NgayHoatDong1 { get; set; }
		public string? NgayHoatDong2 { get; set; }
		public string? ThoiGianHoatDong1 { get; set; }
		public string? ThoiGianHoatDong2 { get; set; }
		public DiaChi? DiaChi { get; set; }
		public string? UserId { get; set; }

		public ICollection<CuaHang>? CuaHangs { get; set; }
		public List<int>? SelectedCuaHang { get; set; }
	}
}
