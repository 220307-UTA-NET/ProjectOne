using Microsoft.AspNetCore.Mvc;
using StreetStyleApp.BusinessLogic;
using System.Data.SqlClient;
using StreetStyleApp.DataLogic;
using System.Text.Json;
using System.Web.Mvc;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

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
        public async Task<ContentResult> GetAllClothesAsync()
        {
            IEnumerable<Clothes> clothes = new List<Clothes> ();
            try
            {
                clothes = await _repository.GetAllClothes();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting all clothes.");
                //return StatusCode = 500;
            }
            string closeJSon = JsonSerializer.Serialize(clothes);
            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = closeJSon
            };
            
            //return clothes.ToList();
        }


    }
}
