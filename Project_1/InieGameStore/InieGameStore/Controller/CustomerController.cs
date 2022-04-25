using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using IndieGameStore.Logic;
using IndieGameStore.DataInfrastructure;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InieGameStore.Controller
{

    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //Fields
        private readonly IRepository _repository;

        //Constructors
        public CustomerController(IRepository repository)
        {
            this._repository = repository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsyc()
        {
            IEnumerable<Customer> customers;
            try
            {
                customers = await _repository.GetAllCustomers();
                
            }
            catch(SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            return customers.ToList();
            
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Customer>>> PostCustomersAsyc([FromBody] string username)
        {
            //string username = "TestName";
            IEnumerable<Customer> newcustomer;
            try
            {
                newcustomer = await _repository.CreateNewCustomer(UserName: username);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            return newcustomer.ToList();
        }
        
        
        
    }
}
