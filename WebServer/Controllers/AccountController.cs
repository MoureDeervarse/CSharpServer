using Microsoft.AspNetCore.Mvc;

using WebServer.DTOs;
using WebServer.Services;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto dto)
        {
            var result = await _accountService.CreateAccount(dto);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var result = await _accountService.GetAllAccounts();
            return new JsonResult(result);
        }
    }
}
