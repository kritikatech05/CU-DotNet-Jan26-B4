using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.AccountService.DTOs;
using SmartBank.AccountService.Services;
using System.Security.Claims;

namespace SmartBank.AccountService.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly ITransactionApiClient _transactionClient;


        public AccountController(IAccountService service,ITransactionApiClient transactionclient)
        {
            _service = service;
            _transactionClient = transactionclient;
        }
        [HttpPost("create-transaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionCreateDto dto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token is missing");

            await _transactionClient.CreateTransaction(dto, token);

            return Ok("Transaction created");
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateAccountDto dto)
        //{
        //    var account = await _service.CreateAccount(dto.UserId);
        //    return Ok(account);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var account = await _service.CreateAccount(userId);
            return Ok(account);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    if (userId == null)
        //        return Unauthorized();

        //    var account = await _service.CreateAccount(userId);

        //    return Ok(account);
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var account = await _service.GetAllAccounts();
            return Ok(account);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var account = await _service.GetAccount(id);
            return Ok(account);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var account = await _service.GetAccount(id);

        //    if (account.UserId != userId)
        //        return Forbid();

        //    return Ok(account);
        //}

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _service.Deposit(dto.AccountId, dto.Amount);
            return Ok("Deposit successful");
        }

        //[HttpPost("deposit")]
        //// [Authorize(Roles = "Customer")]
        //public async Task<IActionResult> Deposit(TransactionDto dto)
        //{
        //    var token = Request.Headers["Authorization"]
        //                    .ToString()
        //                    .Replace("Bearer ", "");

        //    await _service.Deposit(dto.AccountId, dto.Amount, token);

        //    return Ok("Deposit successful");
        //}

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _service.Withdraw(dto.AccountId, dto.Amount);
            return Ok("Withdraw successful");
        }

        //[HttpPost("withdraw")]
        // [Authorize(Roles = "Customer")]
        //[HttpPost("withdraw")]
        //public async Task<IActionResult> Withdraw(TransactionDto dto)
        //{
        //    var authHeader = Request.Headers["Authorization"].ToString();

        //    if (string.IsNullOrEmpty(authHeader))
        //        return Unauthorized("Missing token");

        //    var token = authHeader.Replace("Bearer ", "");

        //    try
        //    {
        //        await _service.Withdraw(dto.AccountId, dto.Amount, token);

        //        return Ok(new
        //        {
        //            message = "Withdrawal successful"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            message = ex.Message
        //        });
        //    }

    //}
    //}
    }
}
