using System.Data.SqlClient;
using LibraryApp.BusinessLogias;
using LibraryApp.DataLogias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        //Fields
        private readonly IRepository _repository;
        private readonly ILogger<MembersController> _logger;

        //Constructors
        public MembersController(IRepository repository, ILogger<MembersController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        //Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> LookUpAllMemberInfoAsync()
        {
            IEnumerable<Member> members;
            try
            {
                members = await _repository.LookUpAllMemberInfo();
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
