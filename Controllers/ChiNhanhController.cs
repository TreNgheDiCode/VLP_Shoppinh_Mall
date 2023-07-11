using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class ChiNhanhController : Controller
    {
        private readonly IDirectoryRepository _directoryRepository;

        public ChiNhanhController(IDirectoryRepository directoryRepository)
        {
            _directoryRepository = directoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var directories = await _directoryRepository.GetAllAsync();
            return View("IndexChiNhanh", directories);
        }

        public async Task<IActionResult> Information(int id)
        {
            ChiNhanh chiNhanh = await _directoryRepository.GetByIdAsync(id);
            var cuaHang = _directoryRepository.GetCuaHangByChiNhanh(id);

            if (chiNhanh == null || cuaHang == null)
            {
                return NotFound("Không tìm thấy, xin vui lòng thử lại!");
            }

            var chiNhanhCuaHang = new ChiNhanhViewModel()
            {
                Id = chiNhanh.Id,
                TenChiNhanh = chiNhanh.TenChiNhanh,
                NoiDung = chiNhanh.NoiDung,
                AnhDaiDien = chiNhanh.AnhDaiDien,
                Email = chiNhanh.Email,
                SoDienThoai = chiNhanh.SoDienThoai,
                NgayHoatDong = chiNhanh.NgayHoatDong,
                ThoiGianHoatDong = chiNhanh.ThoiGianHoatDong,
                DiaChi = chiNhanh.DiaChi,
                CuaHangs = cuaHang
            };

            return View("InformationChiNhanh", chiNhanhCuaHang);
        }

        public IActionResult Create()
        {
            return View("CreateChiNhanh");
        }
    }
}
