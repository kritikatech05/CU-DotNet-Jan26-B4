using FinTrack_Pro.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack_Pro.Controllers
{
    public class PortfolioController : Controller
    {

        private static List<Asset> assets = new List<Asset>()
        {
            new Asset { Id = 1, Name = "Apple", Price = 10000, Quantity = 5 },
            new Asset { Id = 2, Name = "lenovo", Price = 25000, Quantity = 3 },
            new Asset { Id = 3, Name = "hp", Price = 900000, Quantity = 1 }
        };
        public IActionResult Index()
        {
            double total = assets.Sum(x => x.Price * x.Quantity);
            ViewData["Total"] = total + 500; 
            return View(assets);
        }

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(i => i.Id == id);
            return View(asset);
        }

        public IActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(i => i.Id == id);
            if(asset != null)
            {
                assets.Remove(asset);
                TempData["Message"] = "Asset deleted succesfullyy yaayy";
            }
            return RedirectToAction("Index");
        }

    }
}
