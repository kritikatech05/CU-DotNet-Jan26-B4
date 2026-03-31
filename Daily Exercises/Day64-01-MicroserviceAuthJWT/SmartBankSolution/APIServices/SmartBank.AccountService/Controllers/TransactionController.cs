//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SmartBank.AccountService.DTOs;
//using SmartBank.AccountService.Data;
//using SmartBank.AccountService.DTOs;
//using SmartBank.AccountService.Models;

//namespace SmartBank.TransactionService.Controllers
//{
//    [ApiController]
//    [Route("api/transactions")]
//    [Authorize]
//    public class TransactionController : ControllerBase
//    {
//        private readonly Transactions _context;

//        public TransactionController(AccountDbContext context)
//        {
//            _context = context;
//        }

//        // ✅ CREATE TRANSACTION (Deposit / Withdraw)
//        [HttpPost]
//        public async Task<IActionResult> Create(TransactionCreateDto dto)
//        {
//            if (dto.Amount <= 0)
//                return BadRequest("Amount must be greater than zero");

//            var transaction = new Transaction
//            {
//                AccountId = dto.AccountId,
//                Amount = dto.Amount,
//                Type = dto.Type,
//                Description = dto.Description,
//                Date = DateTime.Now
//            };

//            _context.Transactions.Add(transaction);
//            await _context.SaveChangesAsync();

//            return Ok(transaction);
//        }

//        // ✅ GET TRANSACTIONS BY ACCOUNT ID
//        [HttpGet("account/{accountId}")]
//        public IActionResult GetByAccountId(int accountId)
//        {
//            var transactions = _context.Transactions
//                .Where(t => t.AccountId == accountId)
//                .OrderByDescending(t => t.Date)
//                .ToList();

//            return Ok(transactions);
//        }
//        public async Task Deposit(int accountId, decimal amount, string token)
//        {
//            if (amount <= 0)
//                throw new BadRequestException("Amount must be greater than zero");

//            var account = await _repo.GetByIdAsync(accountId);

//            account.Balance += amount;

//            await _repo.UpdateAsync(account);

//            // ✅ Call Transaction microservice ONLY
//            await _transactionClient.CreateTransaction(new TransactionCreateDto
//            {
//                AccountId = accountId,
//                Amount = amount,
//                Type = "Deposit",
//                Description = "Deposit via AccountService"
//            }, token);
//        }
//    }
//}