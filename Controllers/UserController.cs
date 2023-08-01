using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
