using System.ComponentModel.DataAnnotations.Schema;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class InformationSanPhamViewModel
    {
        public int Id { get; set; }
        public string? TenSanPham { get; set; }
        public string? NoiDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public int? LuotMua { get; set; }
        public float? GiaThanh { get; set; }
        public int? LuotYeuThich { get; set; }
        public int MaCuaHang { get; set; }
        public ICollection<CuaHang> CuaHangs { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
