using Microsoft.AspNetCore.Mvc;
using WebAppDI.Services;
namespace WebAppDI.Controllers
{
    public class GreetController : Controller
    {
        //GreetService service = new GreetService();
        private IGreetServices _service { get; set; }
        public GreetController(IGreetServices service)
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
