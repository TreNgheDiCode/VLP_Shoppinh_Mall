using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class CreateSanPhamViewModel
    {
        public string? TenSanPham { get; set; }
        public string? NoiDung { get; set; }
        public IFormFile? AnhDaiDien { get; set; }
        public int? LuotMua { get; set; } = 0;
        public float? GiaThanh { get; set; }
        public int? LuotYeuThich { get; set; } = 0;
        public string? UserId { get; set; }
        public ICollection<CuaHang>? CuaHangs { get; set; }
        public List<int>? SelectedCuaHang { get; set; }
    }
}
