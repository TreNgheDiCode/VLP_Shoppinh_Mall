using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
    public class TuyenDungController : Controller
    {
        public IActionResult Index()
        {
            return View("IndexTuyenDung");
        }
    }
}
