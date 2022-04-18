using business__logic;
using irepository;
using Microsoft.AspNetCore.Mvc;

namespace Webstore.controllers
{


    [Route("[controller]")]
    [ApiController]
    public class pizzaorders : Controller
    {

        private readonly Irepository _repository;
        private readonly ILogger<Customers> _logger;
        private readonly RequestDelegate _next;


        public pizzaorders(Irepository irepository, ILogger<Customers> logger)
        {
            this._repository = irepository;
            this._logger = logger;
        }


        [HttpPost]
        public async Task<ContentResult> PostRegisterOrders([FromBody] List<registerpizzaorders> orders)

        {

            foreach (var order in orders)
            {
                int storeid = order.storeid;
                string name = order.name;
                string lastname = order.lastname;
                string customerid = order.customerid;
                int number_of_pieces = order.number_of_pieces;
                DateTime date = order.date;
                await _repository.registerorders(name, lastname, storeid, date, customerid, number_of_pieces);


            }
            return new ContentResult() { StatusCode = 201 };
            ;
        }
    }
}
