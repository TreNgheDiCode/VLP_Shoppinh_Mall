using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
	public class AdminController : Controller
	{
		private readonly IPhotoService _photoService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AdminController(IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
			_photoService = photoService;
			_httpContextAccessor = httpContextAccessor;
		}

        public IActionResult Index()
		{
			return View("IndexAdmin");
		}
	}
}
