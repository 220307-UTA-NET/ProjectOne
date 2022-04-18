using ComputerStoreApp.BusinessLogic;
using ComputerStoreApp.DataLogic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppComputerStore.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class Computer_Makes_Controller : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<Computer_Make_Controller> _logger;

        //Constructors
        public Computer_Makes_Controller(IRepository repository, ILogger<Computer_Make_Controller> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer_Make>>> GetAllComputer_MakesAsync()
        {
            IEnumerable<Computer_Make> Computer_makes;
            try
            {
               Computer_makes = await _repository.GetAllComputers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL Error while getting Computer_Makes.");
                return StatusCode(500);
               
            }    
            return Computer_makes.ToList();
           
        }

        // GET api/<StoreController>/5
      /*  [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<StoreController>
      /*  [HttpPost]
        public void Post([FromBody] string value)
        {
        }
*/
        // PUT api/<StoreController>/5
      /*  [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<StoreController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
