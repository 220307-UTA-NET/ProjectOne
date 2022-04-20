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

        //// Methods
        //[HttpGet]
        //public async Task<ActionResult<List<Account>>> GetAccountAsync(int input)
        //{
        //    //List<Account> account;
        //    ////try
        //    ////{
        //    ////    account = await _repository.GetAccount(input);
        //    ////    return StatusCode(200);
        //    ////}
        //    ////catch (SqlException ex)
        //    ////{
        //    ////    _logger.LogError(ex, $"SQL error while getting account by the account number of: {input}.");
        //    ////    return StatusCode(500);
        //    ////}
        //}

    }
}
