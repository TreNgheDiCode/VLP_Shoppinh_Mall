﻿using Microsoft.AspNetCore.Mvc.Rendering;
using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class CreateCuaHangViewModel
	{
        public int Id { get; set; }
        public string? TenCuaHang { get; set; }
        public string? NoiDung { get; set; }
        public IFormFile? AnhDaiDien { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string? NgayHoatDong1 { get; set; }
        public string? NgayHoatDong2 { get; set; }
        public string? ThoiGianHoatDong1 { get; set; }
        public string? ThoiGianHoatDong2 { get; set; }
        public string? DiaDiem { get; set; }
        public LoaiCuaHang LoaiCuaHang { get; set; }
		public LoaiAmThuc? LoaiAmThuc { get; set; }
		public LoaiRapChieuPhim? LoaiRapChieuPhim { get; set; }
        public ICollection<ChiNhanh>? ChiNhanhs { get; set; }
        public List<int>? SelectedChiNhanh { get; set; }
        public SelectList? ChiNhanhSelectList { get; set; }
	}
}
