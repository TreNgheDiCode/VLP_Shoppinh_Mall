using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
    public class KhuyenMaiController : Controller
    {
        public IActionResult Index()
        {
            return View("IndexKhuyenMai");
        }
    }
}
