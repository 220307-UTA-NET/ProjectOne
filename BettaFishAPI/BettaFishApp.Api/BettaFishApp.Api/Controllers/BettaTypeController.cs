﻿using BettaFishApp.DataLogic;
using BettaFishApp.InformationLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BettaFishApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BettaTypeController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<BettaTypeController> _logger;

        // Constructors
        public BettaTypeController(IRepository repository, ILogger<BettaTypeController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BettaType>>> GetDeviceByNameAsync(string id)
        {
            IEnumerable<BettaType> bettatypes;
            try
            {
                bettatypes = await _repository.GetBettaType(id);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting devices named {id}.", id);
                return StatusCode(500);
            }
            return bettatypes.ToList();
        }

    }
}
