using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
	public class GioiThieuController : Controller
	{
		public IActionResult Index()
		{
			return View("IndexGioiThieu");
		}
	}
}
