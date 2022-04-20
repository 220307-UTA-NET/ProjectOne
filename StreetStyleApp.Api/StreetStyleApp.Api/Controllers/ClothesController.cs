using Microsoft.AspNetCore.Mvc;
using StreetStyleApp.BusinessLogic;
using System.Data.SqlClient;
using StreetStyleApp.DataLogic;

namespace StreetStyleApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : Controller
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<ClothesController> _logger;

        // Constructor
        public ClothesController(IRepository repository, ILogger<ClothesController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothes>>> GetAllClothesAsync()
        {
            IEnumerable<Clothes> clothes;
            try
            {
                clothes = await _repository.GetAllClothes();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting all clothes.");
                return StatusCode(500);
            }
            return clothes.ToList();
        }

       
    }
}
