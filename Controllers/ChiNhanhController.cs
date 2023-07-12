using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class ChiNhanhController : Controller
    {
        private readonly IDirectoryRepository _directoryRepository;
		private readonly IPhotoService _photoService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ChiNhanhController(IDirectoryRepository directoryRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _directoryRepository = directoryRepository;
			_photoService = photoService;
			_httpContextAccessor = httpContextAccessor;
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
                CuaHangs = cuaHang,
            };

            return View("InformationChiNhanh", chiNhanhCuaHang);
        }

		public IActionResult Create()
		{
			var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
			var createAdminViewModel = new AdminViewModel { UserId = curUserId };

			return RedirectToAction("Index", "Admin", createAdminViewModel);
		}

        [HttpPost]
        public async Task<IActionResult> Create(AdminViewModel adminVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(adminVM.chiNhanhViewModel.AnhDaiDien);

                var chiNhanh = new ChiNhanh
                {
                    TenChiNhanh = adminVM.chiNhanhViewModel.TenChiNhanh,
                    NoiDung = adminVM.chiNhanhViewModel.NoiDung,
                    AnhDaiDien = result.Uri.ToString(),
                    Email = adminVM.chiNhanhViewModel.Email,
                    SoDienThoai = adminVM.chiNhanhViewModel.SoDienThoai,
                    NgayHoatDong = adminVM.chiNhanhViewModel.NgayHoatDong,
                    ThoiGianHoatDong = adminVM.chiNhanhViewModel.ThoiGianHoatDong,
                    DiaChi = new DiaChi
                    {
                        Duong = adminVM.chiNhanhViewModel.DiaChi.Duong,
                        Phuong = adminVM.chiNhanhViewModel.DiaChi.Phuong,
                        Quan = adminVM.chiNhanhViewModel.DiaChi.Quan,
                        ThanhPho = adminVM.chiNhanhViewModel.DiaChi.ThanhPho,
                    }
                };

                _directoryRepository.Add(chiNhanh);
                return RedirectToAction("Index", "Admin");
            } else
            {
                ModelState.AddModelError("", "Lỗi không xác định xảy ra");
            }

            return RedirectToAction("Index", "ChiNhanh", adminVM);
        }
	}
}
