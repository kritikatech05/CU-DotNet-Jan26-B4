using Microsoft.AspNetCore.Mvc;
using Vegabond.MVC.Models;
using Vegabond.MVC.Services;

namespace Vegabond.MVC.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;

        public TravelController(IDestinationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: Show form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Submit form
        [HttpPost]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (!ModelState.IsValid)
                return View(destination);

            await _service.AddAsync(destination);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        // GET: Load edit form
        public async Task<IActionResult> Edit(int id)
        {
            var dest = await _service.GetByIdAsync(id);
            return View(dest);
        }

        // POST: Submit edit
        [HttpPost]
        public async Task<IActionResult> Edit(Destination destination)
        {
            if (!ModelState.IsValid)
                return View(destination);

            await _service.UpdateAsync(destination);

            return RedirectToAction("Index");
        }
    }
}
