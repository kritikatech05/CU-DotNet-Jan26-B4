using Microsoft.AspNetCore.Mvc;

namespace FinTrack_Pro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Summary()
        {
            ViewBag.Status = "Open";

            ViewData["TopGainer"] = "hp";
            ViewData["Volume"] = 200000;
            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker, int? days)
        {
            int actualDays = days ?? 30;

            ViewBag.Ticker = ticker;
            ViewBag.Days = actualDays;

            return View();
        }
    }
}
