using Microsoft.AspNetCore.Mvc;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class CuaHangController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IStoreRepository _storeRepository;

        public CuaHangController(IPhotoService photoService, IStoreRepository storeRepository)
        {
            _photoService = photoService;
            _storeRepository = storeRepository;
        }

        public IActionResult Index()
        {
            return View("IndexCuaHang");
        }

        public async Task<IActionResult> Information(string name)
        {
            var cuaHang = await _storeRepository.GetByNameAsync(name);

            var cuaHangVM = new InformationCuaHangVIewModel
            {
                Id = cuaHang.Id,
                TemCuaHang = cuaHang.TenCuaHang,
                NoiDung = cuaHang.NoiDung,
                AnhDaiDien = cuaHang.AnhDaiDien,
                Email = cuaHang.Email,
                SoDienThoai = cuaHang.SoDienThoai,
                NgayHoatDong = cuaHang.NgayHoatDong,
                ThoiGianHoatDong = cuaHang.ThoiGianHoatDong,
                DiaDiem = cuaHang.DiaDiem,
                LoaiCuaHang = cuaHang.LoaiCuaHang,
                LoaiAmThuc = cuaHang.LoaiAmThuc
            };

            return View("InformationCuaHang", cuaHangVM);
        }
    }
}