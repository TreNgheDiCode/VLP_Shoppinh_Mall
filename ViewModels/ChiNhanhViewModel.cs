using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class ChiNhanhViewModel
    {
        public int Id { get; set; }
        public string TenChiNhanh { get; set; }
        public string? NoiDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string? NgayHoatDong { get; set; }
        public string? ThoiGianHoatDong { get; set; }
        public DiaChi? DiaChi { get; set; }
        public string? UserId { get; set; }
        public List<CuaHang>? CuaHangs { get; set; }
    }
}