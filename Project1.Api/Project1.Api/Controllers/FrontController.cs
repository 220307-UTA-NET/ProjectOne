using Microsoft.AspNetCore.Mvc;
using Project1.DataLogic;
using Project1.Model;
using System.Data.SqlClient;
using System.Web;

namespace Project1.Api.Controllers

{

    [Route("[controller]")]
    [ApiController]
    public class FrontController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<LoginController> _logger;

        public FrontController(IRepository repository, ILogger<LoginController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpGet("/getallaccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccountAsync()
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
    }    
}
