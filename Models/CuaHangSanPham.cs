namespace VLPMall.Models
{
    public class CuaHangSanPham
    {
        public int MaCuaHang { get; set; }
        public int MaSanPham { get; set; }
        public CuaHang? CuaHang { get; set; }
        public SanPham? SanPham { get; set; }
    }
}
