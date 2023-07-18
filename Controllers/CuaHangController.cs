using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using VLPMall.Data;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.Repository;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class CuaHangController : Controller
    {
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IPhotoService _photoService;
        private readonly IStoreRepository _storeRepository;

		public CuaHangController(IHttpContextAccessor httpContextAccessor, IPhotoService photoService, IStoreRepository storeRepository, IDirectoryRepository directoryRepository)
        {
			_httpContextAccessor = httpContextAccessor;
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
                LoaiCuaHang = cuaHang.LoaiCuaHang,
                LoaiAmThuc = cuaHang.LoaiAmThuc
            };

            return View("InformationCuaHang", cuaHangVM);
        }

		public IActionResult Create()
		{
			var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
			var createAdminViewModel = new AdminViewModel
			{
				UserId = curUserId,
			};

			return RedirectToAction("Index", "Admin", createAdminViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(AdminViewModel adminVM)
		{
			if (ModelState.IsValid)
			{
				var result = await _photoService.AddPhotoAsync(adminVM.cuaHangViewModel.AnhDaiDien);

				var cuaHang = new CuaHang
				{
					TenCuaHang = adminVM.cuaHangViewModel.TenCuaHang,
					NoiDung = adminVM.cuaHangViewModel.NoiDung,
					AnhDaiDien = result.Url.ToString(),
					Email = adminVM.cuaHangViewModel.Email,
					SoDienThoai = adminVM.cuaHangViewModel	.SoDienThoai,
					NgayHoatDong = adminVM.cuaHangViewModel.NgayHoatDong1 + " - " + adminVM.cuaHangViewModel.NgayHoatDong2,
					ThoiGianHoatDong = adminVM.cuaHangViewModel.ThoiGianHoatDong1 + " - " + adminVM.cuaHangViewModel.ThoiGianHoatDong2,
					LoaiCuaHang = adminVM.cuaHangViewModel.LoaiCuaHang,
					LoaiAmThuc = adminVM.cuaHangViewModel.LoaiAmThuc,
					LoaiRapChieuPhim = adminVM.cuaHangViewModel.LoaiRapChieuPhim,
				};

				var chiNhanhId = adminVM.cuaHangViewModel.SelectedChiNhanh;

				foreach (var item in chiNhanhId)
				{
					_storeRepository.Add(cuaHang, item);
				}

				return RedirectToAction("Index", "CuaHang");
			}
			else
			{
				ModelState.AddModelError("", "Lỗi không xác định xảy ra");
			}

			return RedirectToAction("Index", "Admin", adminVM);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var cuaHang = await _storeRepository.GetByIdAsync(id);

			if (cuaHang == null) { return View("Error"); }

			var cuaHangVM = new EditCuaHangViewModel
			{
				Id = cuaHang.Id,
				TenCuaHang = cuaHang.TenCuaHang,
				NoiDung = cuaHang.NoiDung,
				AnhDaiDien = cuaHang.AnhDaiDien,
				Email = cuaHang.Email,
				SoDienThoai = cuaHang.SoDienThoai,
				NgayHoatDong = cuaHang.NgayHoatDong,
				ThoiGianHoatDong = cuaHang.ThoiGianHoatDong,
				LoaiCuaHang = cuaHang.LoaiCuaHang,
				LoaiAmThuc = cuaHang.LoaiAmThuc
			};

			return View("EditCuaHang", cuaHangVM);
		}
	}
}