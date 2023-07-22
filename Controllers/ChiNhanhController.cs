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
                    AnhDaiDien = result.Url.ToString(),
                    Email = adminVM.chiNhanhViewModel.Email,
                    SoDienThoai = adminVM.chiNhanhViewModel.SoDienThoai,
                    NgayHoatDong = adminVM.chiNhanhViewModel.NgayHoatDong1 + " - " + adminVM.chiNhanhViewModel.NgayHoatDong2,
                    ThoiGianHoatDong = adminVM.chiNhanhViewModel.ThoiGianHoatDong1 + " - " + adminVM.chiNhanhViewModel.ThoiGianHoatDong2,
                    DiaChi = new DiaChi
                    {
                        Duong = adminVM.chiNhanhViewModel.DiaChi.Duong,
                        Phuong = adminVM.chiNhanhViewModel.DiaChi.Phuong,
                        Quan = adminVM.chiNhanhViewModel.DiaChi.Quan,
                        ThanhPho = adminVM.chiNhanhViewModel.DiaChi.ThanhPho,
                    }
                };

                var cuaHangId = adminVM.chiNhanhViewModel.SelectedCuaHang;

                foreach(var item in cuaHangId)
                {
                    _directoryRepository.Add(chiNhanh, item);
                }

                return RedirectToAction("Index", "ChiNhanh");
            } else
            {
                ModelState.AddModelError("", "Lỗi không xác định xảy ra");
            }

            return RedirectToAction("Index", "Admin", adminVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var chiNhanh = await _directoryRepository.GetByIdAsync(id);

            var cuaHang = _directoryRepository.GetCuaHangByChiNhanh(id);

            if (chiNhanh == null) { return View("Error"); }

            var chiNhanhVM = new EditChiNhanhViewModel
            {
                Id = chiNhanh.Id,
                TenChiNhanh = chiNhanh.TenChiNhanh,
                NoiDung = chiNhanh.NoiDung,
                AnhDaiDien = chiNhanh.AnhDaiDien,
                Email = chiNhanh.Email,
                SoDienThoai = chiNhanh.SoDienThoai,
                NgayHoatDong = chiNhanh.NgayHoatDong,
                ThoiGianHoatDong = chiNhanh.ThoiGianHoatDong,
                MaDiaChi = chiNhanh.MaDiaChi,
                DiaChi = chiNhanh.DiaChi,
                CuaHangs = cuaHang
            };

            return View("EditChiNhanh", chiNhanhVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditChiNhanhViewModel chiNhanhVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Thất bại khi đang cập nhật chi nhánh");
                return View("EditChiNhanh", chiNhanhVM);
            }

            var userChiNhanh = await _directoryRepository.GetByIdAsyncNoTracking(id);

            var cuaHang = _directoryRepository.GetCuaHangByChiNhanh(id);

            chiNhanhVM.CuaHangs = cuaHang;

            if (userChiNhanh != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userChiNhanh.AnhDaiDien);
                } catch (Exception ex)
                {
                    ModelState.AddModelError("", "Không thể xóa ảnh");
                    return View("EditChiNhanh", chiNhanhVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(chiNhanhVM.HinhDaiDien);

                var chiNhanh = new ChiNhanh
                {
                    Id = id,
                    TenChiNhanh = chiNhanhVM.TenChiNhanh,
                    NoiDung = chiNhanhVM.NoiDung,
                    AnhDaiDien = photoResult.Url.ToString(),
                    Email = chiNhanhVM.Email,
                    SoDienThoai = chiNhanhVM.SoDienThoai,
                    NgayHoatDong = chiNhanhVM.NgayHoatDong,
                    ThoiGianHoatDong = chiNhanhVM.ThoiGianHoatDong,
                    DiaChi = chiNhanhVM.DiaChi
                };

                _directoryRepository.Update(chiNhanh);

                return RedirectToAction("Index", "ChiNhanh");
            } else
            {
                return View("EditChiNhanh", chiNhanhVM);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteChiNhanh(int id)
        {
            var chiNhanh = await _directoryRepository.GetByIdAsync(id);
            if (chiNhanh == null) { return View("Error"); }

            _directoryRepository.Delete(chiNhanh);

            return RedirectToAction("Index", "Admin");
        }
	}
}
