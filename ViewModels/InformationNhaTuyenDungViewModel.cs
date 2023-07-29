using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class InformationNhaTuyenDungViewModel
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
        public DiaChi? DiaChi { get; set; }
        public ICollection<TuyenDung>? TuyenDungs { get; set; }
    }
}
