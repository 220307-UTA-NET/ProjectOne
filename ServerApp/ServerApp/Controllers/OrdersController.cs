using Microsoft.AspNetCore.Mvc;
using StoreApplication.BusinessLogic;
using StoreApplication.DataLogic;
using System.Data.SqlClient;
using System.Text.Json;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly InterfaceRepo _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(InterfaceRepo repository, ILogger<OrdersController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders([FromBody]Orders orders)
        {
            ContentResult result;
            try
            {
                await _repository.AddOrders(orders);
                string json = JsonSerializer.Serialize(orders);
                result = new ContentResult()
                {
                    StatusCode = 201,
                    ContentType = "application/json",
                    Content = json
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL error while adding a customer.");
                return StatusCode(500);
            }
            _logger.LogCritical("Critical Event");
            _logger.LogInformation("Information Event");
            _logger.LogTrace("Trace Event");
            return result;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetOrder(int CustomerID) {
            Product order;
            ContentResult result;
            try
            {
                order = await _repository.GetOrderDetails(CustomerID);
                string json = JsonSerializer.Serialize(order);
                result = new ContentResult()
                {
                    StatusCode = 201,
                    ContentType = "application/json",
                    Content = json
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL error while adding a customer.");
                return StatusCode(500);
            }
            _logger.LogCritical("Critical Event");
            _logger.LogInformation("Information Event");
            _logger.LogTrace("Trace Event");
            return result;
        }

        [HttpGet("{Location}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersbyLocation(string Location)
        {
            ContentResult result;
            IEnumerable<Orders> orders;
            try
            {
                orders = await _repository.GetAllOrdersLoc(Location);
                string json = JsonSerializer.Serialize(orders);
                result = new ContentResult()
                {
                    StatusCode = 201,
                    ContentType = "application/json",
                    Content = json
                };
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting order history by location  {Location}.", Location);
                return StatusCode(500);
            }
            _logger.LogCritical("Critical Event");
            _logger.LogInformation("Information Event");
            _logger.LogTrace("Trace Event");
            return orders.ToList();
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersbyCustomer(int CustomerID)
        {
            ContentResult result;
            IEnumerable<Orders> orders;
            try
            {
                orders = await _repository.GetAllOrdersCust(CustomerID);
                string json = JsonSerializer.Serialize(orders);
                result = new ContentResult()
                {
                    StatusCode = 201,
                    ContentType = "application/json",
                    Content = json
                };
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting order history by customer ID: {CustomerID}.", CustomerID);
                return StatusCode(500);
            }
            _logger.LogCritical("Critical Event");
            _logger.LogInformation("Information Event");
            _logger.LogTrace("Trace Event");
            return orders.ToList();
        }
    }
}
