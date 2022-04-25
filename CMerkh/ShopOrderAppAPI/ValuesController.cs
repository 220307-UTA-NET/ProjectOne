using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOrderAppAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/
        [HttpGet("-")]
        public async Task<string> Get([FromQuery] string compressed)
        {
            return compressed;
        }

        // POST api/<ValuesController>
        [HttpPost("/api/transfer")]
        public void Post([FromBody] string compressed)
        {
            bool test;
            List<int> info = new List<int>();
            List<string> temp = new List<string>();
            temp = compressed.Split('.').ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                info[i] = int.Parse(temp[i]);
            }
            //return test = await Maincode.PerformTransfer(info);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
