using DemoApp.BusinessLogic;
using DemoApp.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text.Json;

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<TransactionController> _logger;

        // Constructors
        public TransactionController(IRepository repository, ILogger<TransactionController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsAsync()
        {
            List<Transaction> transactions;
            try
            {
                transactions = await _repository.GetAllTransactions();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of transactions.");
                return StatusCode(500);
            }
            return transactions;
        }
        [HttpGet("{input}")]
        public async Task<ActionResult<List<Transaction>>> GetTransctionAsync(string input)
                {   var transaction = new List<Transaction>();
                    List<Transaction> transactions;
                    try
                    {
                        //transactions = await _repository.GetTransaction(input);
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError(ex, $"SQL error while getting transactions with name of: {input}");
                        return StatusCode(500);
                    }
                    return transaction;
                }
            }
}
