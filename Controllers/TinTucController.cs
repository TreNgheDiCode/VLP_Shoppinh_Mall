using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.Repository;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
	public class TinTucController : Controller
	{
		private readonly IPhotoService _photoService;
		private readonly IArticleRepository _articleRepository;

		public TinTucController(IPhotoService photoService, IArticleRepository articleRepository)
        {
			_photoService = photoService;
			_articleRepository = articleRepository;
		}

        [HttpPost]
		public async Task<IActionResult> Create(AdminViewModel adminVM)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await _photoService.AddPhotoAsync(adminVM.tinTucViewModel.AnhDaiDien);

			var tinTuc = new TinTuc()
			{
				TieuDe = adminVM.tinTucViewModel.TieuDe,
				NoiDung = adminVM.tinTucViewModel.NoiDung,
				AnhDaiDien = result.Url.ToString(),
				NgayDang = adminVM.tinTucViewModel.NgayDang,
				UserId = adminVM.tinTucViewModel.UserId,
				LoaiTinTuc = adminVM.tinTucViewModel.LoaiTinTuc,
				TrangThai = adminVM.tinTucViewModel.TrangThai
			};

			_articleRepository.Add(tinTuc);

			return RedirectToAction("Index", "BaiViet");
		}

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTinTuc(int id)
        {
            var tinTuc = await _articleRepository.GetTinTucById(id);
            if (tinTuc == null) { return View("Error"); }

            _articleRepository.Delete(tinTuc);

            return RedirectToAction("Index", "Admin");
        }
    }
}
