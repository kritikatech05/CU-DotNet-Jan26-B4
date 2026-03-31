using Microsoft.AspNetCore.Mvc;
using WebAppDI.Services;

namespace WebMVCAppDI.Controllers
{
    public class TestController : Controller
    {
        private IGreetServices _service { get; set; }
        public TestController(IGreetServices service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.greet = _service.SayHello();
            return View();
        }
    }
}
