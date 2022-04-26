using Microsoft.AspNetCore.Mvc;
using Project1.BL;
using Project1.DL;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Api.Controllers
{
    [Route("NEISO")]
    [ApiController]
    public class NEISOController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<NEISOController> _logger;

        public NEISOController(IRepository repository, ILogger<NEISOController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // GET api/<NEISOController>/5
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<NEISO>>> GetAllNEISO()
        {
            IEnumerable<NEISO> energy;
            try
            {
                energy = await _repository.GetEnergyNEISO();
            }
            catch (SqlException ex)
            {
                string msg = $"SQL error.";
                _logger.LogError(ex, msg);
                return StatusCode(500);
            }
            return energy.ToList();
        }

        // POST api/<NEISOController>
        [HttpPost("Post")]
        public async Task<IActionResult> PostNEISOEnergyReport(NEISOEnergyReport HourlyEnergyReport)
        {
            try
            {
                await _repository.PostNEISOEnergyReport(HourlyEnergyReport);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                string msg = $"SQL error. {HourlyEnergyReport}";
                _logger.LogError(ex, msg);
                return StatusCode(500);
            }
        }

        // PUT api/<NEISOController>/5
        [HttpPut("Put")]
        public async Task<IActionResult> PutNEISOEnergyReport([FromBody] NEISO HourlyEnergyReport)
        {
            try
            {
                await _repository.PutNEISOEnergyReport(HourlyEnergyReport);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                string msg = $"SQL error. {HourlyEnergyReport}";
                _logger.LogError(ex, msg);
                return StatusCode(500);
            }
        }

        // DELETE api/<NEISOController>/5
        [HttpDelete("Delete/{NEISO_ID}")]
        public async Task<IActionResult> DeleteNEISOEnergyReport(int NEISO_ID)
        {
            try
            {
                await _repository.DeleteNEISOEnergyReport(NEISO_ID);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                string msg = $"SQL error.";
                _logger.LogError(ex, msg);
                return StatusCode(500);
            }
        }
    }
}
