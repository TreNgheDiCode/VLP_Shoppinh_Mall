using VLPMall.Data.Enum;

namespace VLPMall.ViewModels
{
    public class ListAmThucViewModel
    {
        public int Id { get; set; }
        public string TenCuaHang { get; set; }
        public IFormFile? AmhDaiDien { get; set; }
        public string? LinkAnh { get; set; }
        public LoaiCuaHang? LoaiCuaHang { get; set; }
        public LoaiAmThuc? LoaiAmThuc { get; set; }
    }
}
