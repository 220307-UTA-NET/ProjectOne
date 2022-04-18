using business__logic;
using irepository;
using Microsoft.AspNetCore.Mvc;

namespace Webstore.controllers
{
    [Route("[controller]")]
    [ApiController]
    public class status : Controller
    {
        private readonly Irepository _repository;
        private readonly ILogger<status> _logger;

        public status(Irepository irepository, ILogger<status> logger)
        {
            this._repository = irepository;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<inventory>>> Getstoreinventoryasync([FromBody] int l)
        {
            IEnumerable<inventory> currentinventory;
            try
            {
                currentinventory = await _repository.getinvetory(l);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL error while getting store id  {storeid}.", l);
                return StatusCode(500);
            }
            return currentinventory.ToList();
        }


        [HttpPost]
        public async Task<ContentResult> Updateinventory([FromBody ]List<inventory> updateinventory)
        {
           
             await _repository.Updateinventory(updateinventory);
            
            
            return new ContentResult() { StatusCode = 201 };
        }


    }
}
