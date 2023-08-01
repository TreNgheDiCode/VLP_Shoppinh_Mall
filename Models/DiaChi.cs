using System.ComponentModel.DataAnnotations;

namespace VLPMall.Models
{
    public class DiaChi
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên đường và số nhà (nếu có)")]
        public string? Duong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập phường")]
        public string? Phuong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập quận")]
        public string? Quan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thành phố")]
        public string? ThanhPho { get; set; }

        public ICollection<ChiNhanh>? ChiNhanhs { get; set; }
        public ICollection<NhaTuyenDung>? NhaTuyenDungs { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
