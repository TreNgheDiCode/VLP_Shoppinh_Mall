using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class InformationCuaHangVIewModel
    {
        public int Id { get; set; }
        public string TemCuaHang { get; set; }
        public string? NoiDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string? NgayHoatDong { get; set; }
        public string? ThoiGianHoatDong { get; set; }
        public string? DiaDiem { get; set; }
        public LoaiCuaHang LoaiCuaHang { get; set; }
        public LoaiAmThuc? LoaiAmThuc { get; set; }
    }
}
