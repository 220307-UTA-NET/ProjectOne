using System.Data.SqlClient;
using LibraryApp.BusinessLogias;
using LibraryApp.DataLogias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LibraryApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        //Fields
        private readonly IRepository _repository;
        private readonly ILogger<RentalController> _logger;

        //Constructors
        public RentalController(IRepository repository, ILogger<RentalController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        //Methods
        [HttpGet("/allrentals")]
        public async Task<ActionResult<IEnumerable<Rental>>> ViewAllRentalsAsync()
        {
            IEnumerable<Rental> rentals;
            try
            {
                rentals = await _repository.ViewAllRentals();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL communication error.");
                return StatusCode(500);
            }
            return rentals.ToList();
        }
        [HttpGet("/userrentals")]
        public async Task<ActionResult<IEnumerable<Rental>>> ViewUserRentalsAsync(int ID)
        {
            IEnumerable<Rental> rentals;
            try
            {
                rentals = await _repository.ViewUserRentals(ID);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL communication error.");
                return StatusCode(500);
            }
            return rentals.ToList();
        }
        [HttpPost("/arental")]
        public async Task<IActionResult> CreateRentalAsync(Rental rental)
        {
            try
            {
                await _repository.CreateRental(rental);
                return StatusCode(201);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Rental creation failed, check inputs");
                return StatusCode(500);
            }
        }
        //[HttpPut("/arental")]
    }
}
