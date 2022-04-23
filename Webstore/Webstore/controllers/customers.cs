using System.Text.Json;
using business__logic;
using irepository;
using Microsoft.AspNetCore.Mvc;

namespace Webstore.controllers
{

    [Route("[controller]")]
    [ApiController]
    public class Customers : Controller


    {

        private readonly Irepository _repository;
        private readonly ILogger<Customers> _logger;
        private readonly RequestDelegate _next;
        private Irepository @object;

        public Customers() { }

        public Customers(Irepository irepository, ILogger<Customers> logger)
        {
            this._repository = irepository;
            this._logger = logger;
        }

        public Customers(Irepository @object)
        {
            this.@object = @object;
        }

        [HttpPost]
        public async Task<ContentResult> Registercustumers([FromBody] List<registercustomers> newcustomers)
        {


            string name = "";
            string lastname = "";
            foreach (var customers in newcustomers)
            {
                name = customers.name;
                lastname = customers.lastname;
            }

            await _repository.registercustomers(name, lastname);


            return new ContentResult() { StatusCode = 201 };
            ;



        }


        [HttpGet]

        public async Task<int> getcustomerid([FromBody] List<registercustomers> customerid)
        {
            string name = "";
            string lastname = "";
            int customernumerid = 0;
            foreach (var customers in customerid)
            {
                name = customers.name;
                lastname = customers.lastname;
            }

            customernumerid = await _repository.getcustomerid(name, lastname);
            return customernumerid;
        }


        [HttpGet("/customerid")]

        public async Task<ActionResult<IEnumerable<registercustomers>>> getcustomerid([FromBody] int customerid)
        {
            IEnumerable<registercustomers> customer;

            customer = await _repository.getregisteredcustomers(customerid);
            return customer.ToList();
        }





    }





}
