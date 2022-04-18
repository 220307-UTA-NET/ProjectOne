using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppComputerStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Computer_Make_Controller : ControllerBase
    {
        // GET: api/<Computer_Make_Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Computer_Make_Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Computer_Make_Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Computer_Make_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Computer_Make_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
