using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Server.FrontController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontController : ControllerBase
    {
        private static readonly List<int> s_sample = new() {26};

        [HttpGet("/sample")]
        public ContentResult GetSample()
        {
            string json = JsonSerializer.Serializer(s_sample);
            var result = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
            return result;
        }

        [HttpPost("/sample")]
        public ContentResult AddSample([FromBody]int sample)
        {
            s_sample.Add(sample);
            string json = JsonSerializer.Serializer(s_sample);
            var result = new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };
            return result;
        }

        [HttpDelete("/sample")]
        public ContentResult RemoveSample([FromBody] int sample)
        {
            s_sample.Add(sample);
            string json = JsonSerializer.Serializer(s_sample);
            var result = new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };
            return result;
        }

        [HttpPut("/sample")]
        public ContentResult AddSample([FromBody] int sample)
        {
            s_sample.Add(sample);
            string json = JsonSerializer.Serializer(s_sample);
            var result = new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };
            return result;
        }

    }
}
