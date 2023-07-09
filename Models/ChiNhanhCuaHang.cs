using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class ChiNhanhCuaHang
    {
        [Key]
        [ForeignKey("ChiNhanh")]
        public int MaChiNhanh { get; set; }
        [Key]
        [ForeignKey("CuaHang")]
        public int MaCuaHang { get; set; }
        public ChiNhanh? ChiNhanh { get; set; }
        public CuaHang? CuaHang { get; set; }
    }
}
