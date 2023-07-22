using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class ChiNhanhCuaHang
    {
        public int MaChiNhanh { get; set; }
        public int MaCuaHang { get; set; }
        public string? DiaDiem { get; set; }
        public ChiNhanh? ChiNhanh { get; set; }
        public CuaHang? CuaHang { get; set; }
    }
}
