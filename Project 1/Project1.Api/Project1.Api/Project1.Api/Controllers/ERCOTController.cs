using Project1.BL;
using Project1.DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Project1.Api.Controllers
{
    [Route("ERCOT/[controller]")]
    [ApiController]
    public class ERCOTController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<ERCOTController> _logger;

        // Constructors
        public ERCOTController(IRepository repository, ILogger<ERCOTController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ERCOT>>> GetMonthAsync(string Month)
        {
            IEnumerable<ERCOT> energy;
            try
            {
                energy = await _repository.GetEnergyERCOTMonth(Month);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error.", Month);
                return StatusCode(500);
            }
            return energy.ToList();
        }
    }
}
