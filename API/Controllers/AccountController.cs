using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoiThat.Services.Entity;
using NoiThat.Services.Interface;

namespace NoiThat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class AccountController : ControllerBase
    {
        IAccountServices _accountServices;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountServices accountServices, ILogger<AccountController> logger)
        {
           _accountServices = accountServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await _accountServices.GetAll();

            return Ok(accounts);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var account = await _accountServices.GetById(id);
            return Ok(account);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Account account)
        {
            await _accountServices.Add(account);

            return CreatedAtAction(nameof(Get), new { id = account._id }, account);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Account account)
        {
            await _accountServices.Update(id, account);

            return CreatedAtAction(nameof(Get), account);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _accountServices.Remove(id);

            return Ok();
        }
    }
}
