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
		private readonly IProductRepository _productRepository;
		private readonly IDirectoryRepository _directoryRepository;

		public CuaHangController(IHttpContextAccessor httpContextAccessor, IPhotoService photoService, IStoreRepository storeRepository, IDirectoryRepository directoryRepository, IProductRepository productRepository)
        {
			_httpContextAccessor = httpContextAccessor;
			_photoService = photoService;
            _storeRepository = storeRepository;
			_productRepository = productRepository;
			_directoryRepository = directoryRepository;
		}

        public IActionResult Index()
        {
            return View("IndexCuaHang");
        }

        public async Task<IActionResult> Information(int maChiNhanh, string name)
        {
            if (!_storeRepository.CuaHangTonTai(name))
            {
                return NotFound("Không tìm thấy cửa hàng này, xin vui lòng thử lại");
            }

            var cuaHang = await _storeRepository.GetByNameAsync(name);
			var sanPhams = await _storeRepository.GetSanPhamByCuaHang(name);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState + ", có lỗi đã xảy ra");
			}

			var cuaHangVM = new InformationCuaHangViewModel
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
				SanPhams = sanPhams,
				DiaDiem = await _storeRepository.GetDiaDiemgById(maChiNhanh, cuaHang.Id)
			};

            if(cuaHang.LoaiAmThuc != null)
            {
				cuaHangVM.LoaiAmThuc = cuaHang.LoaiAmThuc;
            } else if (cuaHang.LoaiGiaiTri != null)
			{
                cuaHangVM.LoaiAmThuc = cuaHang.LoaiAmThuc;
            } else if (cuaHang.LoaiDichVu != null)
			{
				cuaHangVM.LoaiDichVu = cuaHang.LoaiDichVu;
			} else if (cuaHang.LoaiTienIch != null)
			{
				cuaHangVM.LoaiTienIch = cuaHang.LoaiTienIch;
			} else if (cuaHang.LoaiMuaSam != null)
			{
				cuaHangVM.LoaiMuaSam = cuaHang.LoaiMuaSam;
			}

            return View("InformationCuaHang", cuaHangVM);
        }

		public IActionResult Create()
		{
			var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
			var createAdminViewModel = new AdminViewModel
			{
				cuaHangViewModel = new CreateCuaHangViewModel
				{
					UserId = curUserId,
					SanPhams = new List<SanPham>()
				}
			};

			return RedirectToAction("Index", "Admin", createAdminViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(AdminViewModel adminVM)
		{
			var result = await _photoService.AddPhotoAsync(adminVM.cuaHangViewModel.AnhDaiDien);

            var cuaHang = new CuaHang
			{
				UserId = adminVM.cuaHangViewModel.UserId,
				TenCuaHang = adminVM.cuaHangViewModel.TenCuaHang,
				NoiDung = adminVM.cuaHangViewModel.NoiDung,
				AnhDaiDien = result.Url.ToString(),
				Email = adminVM.cuaHangViewModel.Email,
				SoDienThoai = adminVM.cuaHangViewModel	.SoDienThoai,
				NgayHoatDong = adminVM.cuaHangViewModel.NgayHoatDong1 + " - " + adminVM.cuaHangViewModel.NgayHoatDong2,
				ThoiGianHoatDong = adminVM.cuaHangViewModel.ThoiGianHoatDong1 + " - " + adminVM.cuaHangViewModel.ThoiGianHoatDong2,
				LoaiCuaHang = adminVM.cuaHangViewModel.LoaiCuaHang,
			};

			if (adminVM.cuaHangViewModel.LoaiAmThuc != null)
				cuaHang.LoaiAmThuc = adminVM.cuaHangViewModel.LoaiAmThuc;
			else if (adminVM.cuaHangViewModel.LoaiGiaiTri != null)
				cuaHang.LoaiGiaiTri = adminVM.cuaHangViewModel.LoaiGiaiTri;
			else if (adminVM.cuaHangViewModel.LoaiTienIch != null)
				cuaHang.LoaiTienIch = adminVM.cuaHangViewModel.LoaiTienIch;
			else if (adminVM.cuaHangViewModel.LoaiDichVu != null)
				cuaHang.LoaiDichVu = adminVM.cuaHangViewModel.LoaiDichVu;
			else if (adminVM.cuaHangViewModel.LoaiMuaSam != null)
				cuaHang.LoaiMuaSam = adminVM.cuaHangViewModel.LoaiMuaSam;

			var chiNhanhId = adminVM.cuaHangViewModel.SelectedChiNhanh;
			var sanPhamId = adminVM.cuaHangViewModel.SelectedSanPham;

			foreach (var item in chiNhanhId)
			{
				var chiNhanh = await _directoryRepository.GetByIdAsync(item);

				var diaDiem = adminVM.cuaHangViewModel.DiaDiem;

				_storeRepository.Add(cuaHang, chiNhanh, diaDiem);
			}

			foreach (var item in sanPhamId)
			{
				var sanPham = await _productRepository.GetByIdAsync(item);

				_storeRepository.Add(cuaHang, sanPham);
			}

			return RedirectToAction("Index", "CuaHang");
		}

		public async Task<IActionResult> Edit(int maChiNhanh, int maCuaHang)
		{
			var cuaHang = await _storeRepository.GetByIdAsync(maChiNhanh);

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
				LoaiAmThuc = cuaHang.LoaiAmThuc,
				DiaDiem = await _storeRepository.GetDiaDiemgById(maChiNhanh, maCuaHang)
			};

			return View("EditCuaHang", cuaHangVM);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EditCuaHangViewModel cuaHangVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Thất bại khi đang cập nhật cửa hàng");
				return View("EditCuaHang", cuaHangVM);
			}

			var userCuaHang = await _storeRepository.GetByIdAsyncNoTracking(id);

			var chiNhanh = _storeRepository.GetChiNhanhByCuaHang(id);
			var sanPham = _storeRepository.GetSanPhamByCuaHang(id);

            cuaHangVM.ChiNhanhs = chiNhanh;
			cuaHangVM.SanPhams = sanPham;

			if (userCuaHang != null)
			{
				try
				{
					await _photoService.DeletePhotoAsync(userCuaHang.AnhDaiDien);
				} catch (Exception ex)
				{
					ModelState.AddModelError("", "Không thể xóa ảnh");
					return View("EditChiNhanh", cuaHangVM);
				}

				var photoResult = await _photoService.AddPhotoAsync(cuaHangVM.HinhDaiDien);

				var cuaHang = new CuaHang
				{
					Id = id,
					TenCuaHang = cuaHangVM.TenCuaHang,
					NoiDung = cuaHangVM.NoiDung,
					AnhDaiDien = photoResult.Url.ToString(),
					Email = cuaHangVM.Email,
					SoDienThoai = cuaHangVM.SoDienThoai,
					NgayHoatDong = cuaHangVM.NgayHoatDong1 + " - " + cuaHangVM.NgayHoatDong2,
					ThoiGianHoatDong = cuaHangVM.ThoiGianHoatDong1 + " - " + cuaHangVM.ThoiGianHoatDong2,
					LoaiCuaHang = cuaHangVM.LoaiCuaHang,
					LoaiAmThuc = cuaHangVM.LoaiAmThuc,
                };

				return RedirectToAction("Index", "CuaHang");
			} else
			{
				return View("EditCuaHang", cuaHangVM);
			}
		}

	}
}