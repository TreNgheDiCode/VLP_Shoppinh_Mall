using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;

namespace VLPMall.Controllers
{
    public class BaiVietController : Controller
    {
		private readonly IArticleRepository _articleRepository;

		public BaiVietController(IArticleRepository articleRepository)
        {
			_articleRepository = articleRepository;
		}

        public async Task<IActionResult> Index()
        {
            var tinTuc = await _articleRepository.GetAllAsync();

            return View("IndexBaiViet", tinTuc);
        }
    }
}
