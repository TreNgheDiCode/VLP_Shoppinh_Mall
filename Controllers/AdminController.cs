using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
