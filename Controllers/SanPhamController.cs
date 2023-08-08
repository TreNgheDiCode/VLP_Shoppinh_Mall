using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.Repository;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;
		private readonly IStoreRepository _storeRepository;

		public SanPhamController(IProductRepository productRepository, IPhotoService photoService, IStoreRepository storeRepository)
        {
            _productRepository = productRepository;
            _photoService = photoService;
			_storeRepository = storeRepository;
		}

        public async Task<IActionResult> Information(string name)
        {
            var sanPham = await _productRepository.GetSanPhamByName(name);
            var cuaHang = await _productRepository.GetCuaHangBySanPham(name);

            var sanPhamVM = new InformationSanPhamViewModel()
            {
                Id = sanPham.Id,
                TenSanPham = sanPham.TenSanPham,
                NoiDung = sanPham.NoiDung,
                AnhDaiDien = sanPham.AnhDaiDien,
                LuotMua = sanPham.LuotMua,
                GiaThanh = sanPham.GiaThanh,
                LuotYeuThich = sanPham.LuotYeuThich,
                CuaHangs = cuaHang,
            };

            return View("InformationSanPham", sanPhamVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminViewModel adminVM)
        {
            if (ModelState.IsValid)
            {
				var result = await _photoService.AddPhotoAsync(adminVM.sanPhamViewModel.AnhDaiDien);

                var sanPham = new SanPham()
                {
                    UserId = adminVM.sanPhamViewModel.UserId,
                    TenSanPham = adminVM.sanPhamViewModel.TenSanPham,
                    NoiDung = adminVM.sanPhamViewModel.NoiDung,
                    AnhDaiDien = result.Url.ToString(),
                    GiaThanh = adminVM.sanPhamViewModel.GiaThanh
                };

                var cuaHangId = adminVM.sanPhamViewModel.SelectedCuaHang;

                if (cuaHangId != null)
                    foreach (var item in cuaHangId)
                    {
                        var cuaHang = await _storeRepository.GetByIdAsync(item);

                        _productRepository.Add(cuaHang, sanPham);
                    }
                else
                {
                    _productRepository.Add(sanPham);
                }
			}

            return RedirectToAction("Index", "CuaHang");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var sanPham = await _productRepository.GetByIdAsync(id);
            if (sanPham == null) { return View("Error"); }

            _productRepository.Delete(sanPham);

            return RedirectToAction("Index", "Admin");
        }
    }
}
