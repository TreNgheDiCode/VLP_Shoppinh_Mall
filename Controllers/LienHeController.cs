using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
	public class LienHeController : Controller
	{
		public IActionResult Index()
		{
			return View("IndexLienHe");
		}
	}
}
