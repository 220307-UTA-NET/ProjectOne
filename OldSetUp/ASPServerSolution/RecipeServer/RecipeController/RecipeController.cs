using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RecipeServer.RecipeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private static readonly List<string> usernames = new List<string> {"first username" };

        [HttpGet("/username")]
        public ContentResult GetSample()
        {
            string json = JsonSerializer.Serialize(usernames);

            var returnResult = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

            return returnResult;
        }

        [HttpPost("/username")]
        public ContentResult AddUsername([FromBody] string newName)
        {
            usernames.Add(newName);
            string json = JsonSerializer.Serialize(usernames);

            return new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };
        }

        [HttpPut("/username")]
        public ContentResult PutUsernameUpdate([FromBody] string oldName,string newName)
        {
            usernames.Remove(oldName);
            //string json_deleted = JsonSerializer.Serialize(usernames);
            usernames.Add(newName);
            string json = JsonSerializer.Serialize(usernames);
            return new ContentResult()
            {
                StatusCode = 202,
                ContentType = "application/json",
                Content = json
            };
        }



        [HttpDelete("/username/deletebody")]
        public ContentResult DeleteSpecificUser([FromBody] string newName)   // deletes the number in body
        {
            usernames.Remove(newName);
            string json = JsonSerializer.Serialize(usernames);

            return new ContentResult()
            {
                StatusCode = 202,
                ContentType = "application/json",
                Content = json
            };
        }

        [HttpDelete("/username/deleteEntireList")]
        public ContentResult DeleteAllUsers()   // deletes the full list of numbers 
        {
            usernames.Clear();
            string json = JsonSerializer.Serialize(usernames);

            return new ContentResult()
            {
                StatusCode = 203,
                ContentType = "application/json",
                Content = json
            };
        }



    }
}



// Add a range of items  
string[] authors = { "Mike Gold", "Don Box",
                        "Sundar Lal", "Neel Beniwal" };
AuthorList.AddRange(authors);