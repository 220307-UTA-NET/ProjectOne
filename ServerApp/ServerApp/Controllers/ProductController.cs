using Microsoft.AspNetCore.Mvc;
using StoreApplication.BusinessLogic;
using StoreApplication.DataLogic;
using System.Data.SqlClient;
using System.Text.Json;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly InterfaceRepo _repository;
        private readonly ILogger<OrdersController> _logger;


        public ProductController(InterfaceRepo repository, ILogger<OrdersController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            IEnumerable<Product> products;
            ContentResult result;
            try
            {
                products = await _repository.GetAllProducts();
                string json = JsonSerializer.Serialize(products);
                //return Ok(json);
                result = new ContentResult()
                {
                    StatusCode = 200,
                    ContentType = "application/json",
                    Content = json
                };
            }
            catch (SqlException ex)
            {
                
                _logger.LogError(ex, "SQL error while getting all products");
                return StatusCode(500);
            }
            _logger.LogCritical("Critical Event");
            _logger.LogInformation("Information Event");
            _logger.LogTrace("Trace Event");
            return result;
        }
    }   
}
