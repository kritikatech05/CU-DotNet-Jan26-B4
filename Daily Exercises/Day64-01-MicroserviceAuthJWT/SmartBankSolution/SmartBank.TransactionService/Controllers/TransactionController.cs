using Microsoft.AspNetCore.Mvc;
//using SmartBank.TransactionService.Data;
using SmartBank.TransactionService.DTOs;
using SmartBank.TransactionService.Models;

[ApiController]
[Route("api/transactions")]
public class TransactionsController : ControllerBase
{
    private readonly TransactionDbContext _context;

    public TransactionsController(TransactionDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TransactionCreateDto dto)
    {
        if (dto.Amount <= 0)
            return BadRequest("Amount must be greater than zero");

        var transaction = new Transaction
        {
            AccountId = dto.AccountId,
            Amount = dto.Amount,
            Type = dto.Type,
            Description = dto.Description,
            Date = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return Ok(transaction);
    }

    [HttpGet("account/{accountId}")]
    public IActionResult GetByAccountId(int accountId)
    {
        var transactions = _context.Transactions
            .Where(t => t.AccountId == accountId)
            .OrderByDescending(t => t.Date)
            .ToList();

        return Ok(transactions);
    }
}