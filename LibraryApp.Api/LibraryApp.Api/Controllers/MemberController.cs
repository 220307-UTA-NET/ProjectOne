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
        private readonly ILogger<MemberController> _logger;

        //Constructors
        public MemberController(IRepository repository, ILogger<MemberController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet("/amember")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMemberInfoByNameAsync(string fName, string lName)
        {
            IEnumerable<Member> member;
            try
            {
                member = await _repository.GetMemberInfoByName(fName, lName);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL communication error.");
                return StatusCode(500);
            }
            return member.ToList();
        }
        [HttpPost("/amember")]
        public async Task<IActionResult> CreateMemberAsync(Member member)
        {
            try
            {
                await _repository.CreateMember(member);
                return StatusCode(201);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Member creation failed, check inputs");
                return StatusCode(500);
            }        
        }
        [HttpGet("/allmembers")]
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
