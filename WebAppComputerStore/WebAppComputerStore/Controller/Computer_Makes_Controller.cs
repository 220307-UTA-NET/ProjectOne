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
        private readonly ILogger<Computer_Makes_Controller> _logger;

        //Constructors
        public Computer_Makes_Controller(IRepository repository, ILogger<Computer_Makes_Controller> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer_Make>>> GetAllComputer()
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


      //  My Post Method
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Computer_Make>>> AddToComputer()
        {
            IEnumerable<Computer_Make> AddComputer;
            try
            {
                AddComputer = await _repository.AddComputer();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL Error while adding Computer.");
                return StatusCode(500);

            }
            return AddComputer.ToList();

        }

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
