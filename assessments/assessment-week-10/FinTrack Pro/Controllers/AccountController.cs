using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinTrack_Pro.Data;
using FinTrack_Pro.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FinTrack_Pro.Controllers
{
    public class AccountController : Controller
    {
        private readonly FinTrack_ProContext _context;

        public AccountController(FinTrack_ProContext context)
        {
            _context = context;
        }

        // GET: Account
        public IActionResult Index()
        {
            var accounts = _context.Accounts
                .Include(a => a.Transactions)
                .ToList();

            return View(accounts);
        }


        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();

                TempData["Success"] = "Account created successfully";

                return RedirectToAction(nameof(Index));
            }
            return View(account);

        }

        public IActionResult Details(int id)
        {
            var account = _context.Accounts
                .Include(a => a.Transactions)
                .FirstOrDefault(a => a.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

    }
}
