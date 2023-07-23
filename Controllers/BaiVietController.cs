using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
    public class BaiVietController : Controller
    {
        public IActionResult Index()
        {
            return View("IndexBaiViet");
        }
    }
}
