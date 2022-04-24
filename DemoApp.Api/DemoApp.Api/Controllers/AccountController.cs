using DemoApp.BusinessLogic;
using DemoApp.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<AccountController> _logger;

        // Constructors
        public AccountController(IRepository repository, ILogger<AccountController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAccountAsync(int input)
        {
            List<Account> account;
            try
            {
                account = await _repository.GetAccount(input);
                
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"SQL error while getting account by the account number of: {input}.");
                return StatusCode(500);
            }
            return account;

        }

        [HttpPost()]

        public async Task<IActionResult> AddNewAccountAsync([FromBody] Account account)
        {
            // List<Account> account;
            try
            {
                await _repository.AddAccount(account);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(JsonSerializer.Serialize(account));
                _logger.LogError(ex, " Account Regiateration Failed" + account);
                return StatusCode(500);


            }

        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAccountBalalaceAsync([FromBody] Account account)
        {
            // List<Customer> customer;
            try
            {
                await _repository.UpdateAccountBalance(account);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, " Updating account failed" + account);
                return StatusCode(500);


            }

        }




    }

        

    
}
