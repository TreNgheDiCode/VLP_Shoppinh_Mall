using System.ComponentModel.DataAnnotations.Schema;
using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class TuyenDung
    {
        public int Id { get; set; }
        public string? TenTuyenDung { get; set; }
        public string? NoiDung { get; set; }
        public string? YeuCau { get; set; }
        public string? QuyenLoi { get; set; }
        public int SoLuong { get; set; } = 0;
        [ForeignKey("DiaChi")]
        public int MaDiaChi { get; set; }
        public DiaChi DiaChi { get; set; }
        public int? MucLuong { get; set; }
        public DateTime NgayDang { get; set; } = DateTime.Now;
        public DateTime NgayHetHan { get; set; }
        [ForeignKey("NhaTuyenDung")]
        public int MaNhaTuyenDung { get; set; }
        public NhaTuyenDung NhaTuyenDung { get; set; }
		[ForeignKey("User")]
		public string? UserId { get; set; }
		public User? User { get; set; }
		public LoaiNgheNghiep? LoaiNgheNghiep { get; set; }
        public LoaiHinhTuyenDung? LoaiHinhTuyenDung { get; set; }
        public LoaiKinhNghiem? LoaiKinhNghiem { get; set; }
        public LoaiTrinhDo? LoaiTrinhDo { get; set; }
    }
}
