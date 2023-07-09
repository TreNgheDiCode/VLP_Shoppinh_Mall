using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class User : IdentityUser
    {
        public string? ProfileImageUrl { get; set; }
        [ForeignKey("DiaChi")]
        public int? MaDiaChi { get; set; }
        public DiaChi? DiaChi { get; set; }
        public ICollection<ChiNhanh>? ChiNhanh { get; set; }
        public ICollection<CuaHang>? CuaHang { get; set; }
    }
}
