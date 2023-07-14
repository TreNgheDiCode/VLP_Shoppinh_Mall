﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class User : IdentityUser
    {
        public string? ProfileImageUrl { get; set; }
        public string? HoTen { get; set; }
        [ForeignKey("DiaChi")]
        public int? MaDiaChi { get; set; }
        public DiaChi? DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public ICollection<ChiNhanh>? ChiNhanh { get; set; }
        public ICollection<CuaHang>? CuaHang { get; set; }
    }
}
