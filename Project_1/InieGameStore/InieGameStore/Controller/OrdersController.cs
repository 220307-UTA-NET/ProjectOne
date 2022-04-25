using IndieGameStore.DataInfrastructure;
using IndieGameStore.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace InieGameStore.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //Fields
        private readonly IRepository _repository;

        //Constructors
        public OrdersController(IRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsyc()
        {
            IEnumerable<Order> orders;
            try
            {
                orders = await _repository.GetAllOrders();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            return orders.ToList();

        }
    }
}
