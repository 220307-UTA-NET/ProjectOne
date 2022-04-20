using Microsoft.AspNetCore.Mvc;
using StreetStyleApp.BusinessLogic;
using System.Data.SqlClient;
using StreetStyleApp.DataLogic;

namespace StreetStyleApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddClothesController : Controller
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<AddClothesController> _logger;

        // Constructor
        public AddClothesController(IRepository repository, ILogger<AddClothesController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Clothes>>> AddClothesAsync(Clothes clo)
        {
            IEnumerable<Clothes> clothes;
            try
            {
                clothes = await _repository.AddClothes(clo);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while adding clothes.");
                return StatusCode(500);
            }
            return clothes.ToList();
        }


    }
}