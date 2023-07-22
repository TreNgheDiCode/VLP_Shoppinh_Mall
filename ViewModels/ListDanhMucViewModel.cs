using VLPMall.Data.Enum;

namespace VLPMall.ViewModels
{
    public class ListDanhMucViewModel
    {
        public int Id { get; set; }
        public string TenCuaHang { get; set; }
        public IFormFile? AnhDaiDien { get; set; }
        public string? LinkAnh { get; set; }
        public LoaiCuaHang? LoaiCuaHang { get; set; }
        public LoaiAmThuc? LoaiAmThuc { get; set; }
        public LoaiGiaiTri? LoaiGiaiTri { get; set; }
        public LoaiDichVu? LoaiDichVu { get; set; }
        public LoaiTienIch? LoaiTienIch { get; set; }
        public LoaiMuaSam? LoaiMuaSam { get; set; }

    }
}
