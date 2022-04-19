using Microsoft.AspNetCore.Mvc;
using Project1.DataLogic;
using Project1.Model;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Text.Json;

namespace Project1.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IRepository repository, ILogger<LoginController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpGet("/getallusers")]
        /* public async Task<ActionResult<IEnumerable<User>>> GetAllUserAsync()
         {
             IEnumerable<User> bankUsers;
             try
             {
                 bankUsers = await _repository.GetAllUsers();
             }
             catch (SqlException ex)
             {
                 _logger.LogError(ex, "Login Failed");
                 return StatusCode(500);

             }
             return bankUsers.ToList();
         }*/
        public async Task<ContentResult> GetAllUserAsync()
        {
            IEnumerable<User> current = await _repository.GetAllUsers();
            string json = JsonSerializer.Serialize(current);
            _logger.LogInformation("Get all users");

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }


        [HttpPost("/registeruser")]
        public async Task<IActionResult> RegisterUserAsync(User bankUser)
        {
            //IEnumerable<User> bankUsers;
            try
            {
                await _repository.RegisterUser(bankUser);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Register Failed");
                return StatusCode(500);

            }
        }

        [HttpPut("/updateuser")]
        public async Task<IActionResult> UpdateUserAsync(User bankUser)
        {
            //IEnumerable<User> bankUsers;
            try
            {
                await _repository.UpdateUser(bankUser);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Failed to update a user");
                return StatusCode(500);

            }
        }

        [HttpDelete("/deleteuser(under construction)")]
        public async Task<IActionResult> DeleteUserAsync(User bankUser)
        {
            //IEnumerable<User> bankUsers;
            try
            {
                await _repository.DeleteUser(bankUser);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Failed to delete a user");
                return StatusCode(500);

            }
        }

    }
}
