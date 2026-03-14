using FinTrack_Pro.Data;
using FinTrack_Pro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TransactionController : Controller
{
    private readonly FinTrack_ProContext _context;

    public TransactionController(FinTrack_ProContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var accounts = _context.Accounts.ToList();

        return View(accounts);
    }
    public IActionResult Create(int accountId)
    {
        ViewBag.AccountId = accountId;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();

        return RedirectToAction("Details", "Account",
            new { id = transaction.AccountId });
    }
}