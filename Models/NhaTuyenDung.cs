﻿using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class NhaTuyenDung
    {
        public int Id { get; set; }
        public LoaiNgheNghiep? NganhNghe { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? MangXaHoi { get; set; }
        public string? TrangChu { get; set; }
        public DiaChi? DiaChi { get; set; }

        public ICollection<TuyenDung>? TuyenDungs { get; set; }
    }
}