using CarManagement.Data;
using CarManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarManagement.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Customer,User")]
        public IActionResult Index()
        {
            // Diagnostic: return explicit view path to confirm runtime can find the file on disk.
            // If this works, revert to `return View(_context.Car.ToList());` after fixing project/content root.
            return View("~/Views/Cars/Index.cshtml", _context.Car.ToList());
        }

        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Car.Add(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var car = _context.Car.Find(id);
            return View(car);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Update(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var car = _context.Car.Find(id);
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _context.Car.Find(id);
            _context.Car.Remove(car);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Customer,User")]
        public IActionResult Details(int id)
        {
            var car = _context.Car.Find(id);
            return View(car);
        }
    }
}