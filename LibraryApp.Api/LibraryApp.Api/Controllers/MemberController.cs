using System.Data.SqlClient;
using LibraryApp.BusinessLogias;
using LibraryApp.DataLogias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        //Fields
        private readonly IRepository _repository;
        private readonly ILogger<MembersController> _logger;

        //Constructors
        public MemberController(IRepository repository, ILogger<MembersController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet("/amember")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMemberInfoByNameAsync(string fName, string lName)
        {
            IEnumerable<Member> members;
            try
            {
                members = await _repository.GetMemberInfoByName(fName, lName);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL communication error.");
                return StatusCode(500);
            }
            return members.ToList();
        }    
    }
}
