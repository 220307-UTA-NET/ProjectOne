using Microsoft.AspNetCore.Mvc;
using Project1.DataLogic;
using Project1.Model;
using System.Data.SqlClient;
using System.Text.Json;
using System.Web;

namespace Project1.Api.Controllers

{

    [Route("[controller]")]
    [ApiController]
    public class FrontController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<FrontController> _logger;

        public FrontController(IRepository repository, ILogger<FrontController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpGet("/getallaccounts")]
        /*public async Task<ActionResult<IEnumerable<Account>>> GetAllAccountAsync()
        {
            IEnumerable<Account> bankAccounts;
            try
            {
                bankAccounts = await _repository.GetAllAccounts();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Login Failed");
                return StatusCode(500);

            }
            return bankAccounts.ToList();
        }*/
        public async Task<ContentResult> GetAllAccountAsync()
        {
            IEnumerable<Account> current = await _repository.GetAllAccounts();
            string json = JsonSerializer.Serialize(current);
            _logger.LogInformation("Get all accounts");

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }

        [HttpPost("/newaccount")]
        public async Task<IActionResult> RegisterAccountAsync(Account bankAccount)
        {
            //IEnumerable<Account> bankAccounts;
            try
            {
                await _repository.RegisterAccount(bankAccount);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Failed to make a new account");
                return StatusCode(500);

            }
        }

        [HttpPut("/updateaccount")]
        public async Task<IActionResult> UpdateAccountAsync(Account bankAccount)
        {
            try
            {
                await _repository.UpdateAccount(bankAccount);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Failed to update an account");
                return StatusCode(500);

            }
        }

        [HttpDelete("/deleteaccount(under construction)")]
        public async Task<IActionResult> DeleteAccountAsync(Account bankAccount)
        {
            try
            {
                await _repository.DeleteAccount(bankAccount);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Failed to delete an account");
                return StatusCode(500);

            }
        }

    }    
}
