using System.ComponentModel.DataAnnotations.Schema;
using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class TinTuc
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public string? AnhDaiDien { get; set; }
        public DateTime NgayDang { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public LoaiTinTuc? LoaiTinTuc { get; set; }
        public bool? TrangThai { get; set; }

    }
}
