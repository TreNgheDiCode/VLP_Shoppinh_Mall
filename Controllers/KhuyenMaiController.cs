using Microsoft.AspNetCore.Mvc;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;

namespace VLPMall.Controllers
{
    public class KhuyenMaiController : Controller
    {
		private readonly IArticleRepository _articleRepository;

		public KhuyenMaiController(IArticleRepository articleRepository)
        {
			_articleRepository = articleRepository;
		}

        public async Task<IActionResult> Index()
        {
            var khuyenMais = await _articleRepository.GetTinTucByLoaiTinTUc(LoaiTinTuc.KhuyenMai);

            return View("_IndexTinTuc", khuyenMais);
        }
    }
}
