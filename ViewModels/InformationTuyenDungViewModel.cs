using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class InformationTuyenDungViewModel
    {
        public int Id { get; set; }
        public string? TenTuyenDung { get; set; }
        public string? NoiDung { get; set; }
        public int? MucLuong { get; set; }
        public DateTime NgayDang { get; set; } = DateTime.Now;
        public DateTime NgayHetHan { get; set; }
        public NhaTuyenDung NhaTuyenDung { get; set; }
        public LoaiNgheNghiep? LoaiNgheNghiep { get; set; }
        public LoaiHinhTuyenDung? LoaiHinhTuyenDung { get; set; }
        public LoaiKinhNghiem? LoaiKinhNghiem { get; set; }
        public LoaiTrinhDo? LoaiTrinhDo { get; set; }
    }
}
