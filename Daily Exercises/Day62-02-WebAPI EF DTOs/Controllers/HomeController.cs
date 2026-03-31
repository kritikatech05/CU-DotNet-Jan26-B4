using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppDI.Models;
using WebAppDI.Models;
using WebAppDI.Services;

namespace WebMVCAppDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGreetServices _service { get; set; }
        public HomeController(ILogger<HomeController> logger, IGreetServices service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
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
