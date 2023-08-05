using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class CreateNhaTuyenDungViewModel
	{
        public string? TenNhaTuyenDung { get; set; }
        public IFormFile? AnhDaiDien { get; set; }
        public string? GioiThieu { get; set; }
        public LoaiNgheNghiep? NganhNghe { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? MangXaHoi { get; set; }
        public string? TrangChu { get; set; }
        public DiaChi? DiaChi { get; set; }
        public string? UserId { get; set; }
    }
}
