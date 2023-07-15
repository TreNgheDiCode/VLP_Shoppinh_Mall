using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class EditChiNhanhViewModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên chi nhánh")]
		public string TenChiNhanh { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập nội dung")]
		public string NoiDung { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public IFormFile? HinhDaiDien { get; set; }
        public string? AnhDaiDien { get; set; }
		public string? Email { get; set; }
		public string? SoDienThoai { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn khung ngày hoạt động")]
		public string? NgayHoatDong { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn khung giờ hoạt động")]
		public string? ThoiGianHoatDong { get; set; }
		public int MaDiaChi { get; set; }
        public DiaChi DiaChi { get; set; }

		public ICollection<CuaHang>? CuaHangs { get; set; }
    }
}
