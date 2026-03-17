using Microsoft.AspNetCore.Mvc;
using QuickLoan.Models;

namespace QuickLoan.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> loans = new List<Loan>();

        public IActionResult Index()
        {
            return View(loans);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Id = loans.Count + 1;
                loans.Add(loan);

                return RedirectToAction("Index");
            }

            return View(loan);
        }

        public IActionResult Edit(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);

            if (loan == null)
                return NotFound();

            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loan loan)
        {
            if (ModelState.IsValid)
            {
                var existingLoan = loans.FirstOrDefault(x => x.Id == loan.Id);

                if (existingLoan != null)
                {
                    existingLoan.BorrowerName = loan.BorrowerName;
                    existingLoan.LenderName = loan.LenderName;
                    existingLoan.Amount = loan.Amount;
                    existingLoan.IsSettled = loan.IsSettled;
                }

                return RedirectToAction("Index");
            }

            return View(loan);
        }

        public IActionResult Delete(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);

            if (loan != null)
                loans.Remove(loan);

            return RedirectToAction("Index");
        }
    }
}