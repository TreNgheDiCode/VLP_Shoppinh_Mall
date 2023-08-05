using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class AdminViewModel
	{
        public ICollection<ChiNhanh>? ChiNhanhs { get; set; }
        public ICollection<CuaHang>? CuaHangs { get; set; }
        public ICollection<SanPham>? SanPhams { get; set; }
        public ICollection<KhuyenMai>? KhuyenMais { get; set; }
        public ICollection<TinTuc>? TinTucs { get; set; }
        public ICollection<TuyenDung>? TuyenDungs { get; set; }
        public ICollection<NhaTuyenDung>? NhaTuyenDungs { get; set; }
        public CreateChiNhanhViewModel? chiNhanhViewModel { get; set; }
        public CreateCuaHangViewModel? cuaHangViewModel { get; set; }
        public CreateSanPhamViewModel? sanPhamViewModel { get; set; }
        public CreateKhuyenMaiViewModel? khuyenMaiViewModel { get; set; }
        public CreateNhaTuyenDungViewModel? nhaTuyenDungViewModel { get; set; }
        public CreateTuyenDungViewModel? tuyenDungViewModel { get; set; }
    }
}
