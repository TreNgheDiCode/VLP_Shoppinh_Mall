using Microsoft.AspNetCore.Mvc;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.Repository;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class KhuyenMaiController : Controller
    {
		private readonly IArticleRepository _articleRepository;
		private readonly IPhotoService _photoService;
		private readonly ISaleRepository _saleRepository;

		public KhuyenMaiController(IArticleRepository articleRepository, IPhotoService photoService, ISaleRepository saleRepository)
        {
			_articleRepository = articleRepository;
			_photoService = photoService;
			_saleRepository = saleRepository;
		}

        public async Task<IActionResult> Index()
        {
            var khuyenMais = await _articleRepository.GetTinTucByLoaiTinTUc(LoaiTinTuc.KhuyenMai);

            return View("_IndexTinTuc", khuyenMais);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminViewModel adminVM)
        {
            var cuaHangId = adminVM.khuyenMaiViewModel.SelectedCuaHang;

            var khuyenMai = new KhuyenMai()
            {
                TenKhuyenMai = adminVM.khuyenMaiViewModel.TenKhuyenMai,
                NgayBatDau = adminVM.khuyenMaiViewModel.NgayBatDau,
                NgayKetThuc = adminVM.khuyenMaiViewModel.NgayKetThuc,
                ChietKhau = adminVM.khuyenMaiViewModel.ChietKhau,
                UserId = adminVM.khuyenMaiViewModel.UserId,
            };

            if (cuaHangId != null)
                foreach (var item in cuaHangId)
                {
                    khuyenMai.MaCuaHang = item;

                    _saleRepository.Add(khuyenMai);

                }
            else
                _saleRepository.Add(khuyenMai);

            return RedirectToAction("Index", "CuaHang");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteKhuyenMai(int id)
        {
            var khuyenMai = await _saleRepository.GetByIdAsync(id);
            if (khuyenMai == null) { return View("Error"); }

            _saleRepository.Delete(khuyenMai);

            return RedirectToAction("Index", "Admin");
        }
    }
}
