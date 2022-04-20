using Microsoft.AspNetCore.Mvc;
using StreetStyleApp.BusinessLogic;
using System.Data.SqlClient;
using StreetStyleApp.DataLogic;

namespace StreetStyleApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteClothesController : Controller
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<DeleteClothesController> _logger;

        // Constructor
        public DeleteClothesController(IRepository repository, ILogger<DeleteClothesController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Clothes>>> DeleteClothesAsync(int ID)
        {
            IEnumerable<Clothes> clothes;
            try
            {
                clothes = await _repository.DeleteClothes(ID);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while deleting clothes.");
                return StatusCode(500);
            }
            return clothes.ToList();
        }
    }
}
