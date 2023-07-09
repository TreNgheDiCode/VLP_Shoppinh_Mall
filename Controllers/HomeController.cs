using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDirectoryRepository _directoryRepository;

        public HomeController(ILogger<HomeController> logger, IDirectoryRepository directoryRepository)
        {
            _logger = logger;
            _directoryRepository = directoryRepository;
        }

        public IActionResult Index()
        {
            var directories =  _directoryRepository.GetAll();
            return View(directories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}