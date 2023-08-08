using VLPMall.Data.Enum;

namespace VLPMall.ViewModels
{
	public class CreateTinTucViewModel
	{
        public string TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public IFormFile? AnhDaiDien { get; set; }
        public DateTime NgayDang { get; set; }
        public string? UserId { get; set; }
        public LoaiTinTuc? LoaiTinTuc { get; set; }
        public bool TrangThai { get; set; }
    }
}
