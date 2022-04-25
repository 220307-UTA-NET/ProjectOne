using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBookApp.DataLogic;
using RecipeBookApp.BusinessLogic;
using System.Text.Json;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Logging;

namespace RecipeBookApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<UserController> _logger;
        private readonly HttpClient httpClientInstance = new HttpClient();
        //private User newUserAct;
        //Uri uri = new Uri("https://localhost:7089");
        //private readonly List<string> userList = new List<string>();
        //private readonly RequestDelegate _requestDelegate;
        //create a user object to put json into 

        // Constructors
        public UserController(IRepository repository, ILogger<UserController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }
        ////private static readonly List<string> usernames = new List<string> { "first username" };


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        /*
                public void SqlRepoCreateNewUser_SendingToRepo_RepoUpdated()
                {
                    // Arrange 
                    string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project0.txt");

                    IRepository repo = new SqlRepository(connectionString);
                    repo.CreateNewUser("user2", "upassword", "anotherName", "onceAgain");
                    Console.WriteLine("user created!! woot woot!");
                    // Act


                    // Assert
                }
        */

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        // Methods
        [HttpGet("/userAccount")]
        public async Task<ActionResult<IEnumerable<User>>> ListOfUsersAsync()
        {

            IEnumerable<User> users;
            try
            {
                users = await _repository.ListOfUsers();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of users");
                return StatusCode(500);
            }
            return users.ToList();
            //var returnResult = new ContentResult()
            //{
            //    StatusCode = 200,
            //    ContentType = "application/json",
            //    Content = json
            //};
            //return returnResult;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        [HttpPost("/userAccount")]
        public async Task<ContentResult> CreateNewUserWithPost([FromBody] List<User> newAccts)
        {

            foreach (var stringUserItem in newAccts)
            {
                string username = stringUserItem.Username;
                string password = stringUserItem.UserPassword;
                string firstName = stringUserItem.FirstName;
                string lastName = stringUserItem.LastName;
                await _repository.CreateNewUser(username, password, firstName, lastName);
            }

            return new ContentResult() { StatusCode = 201 };
        }

        [HttpPost("/user2")]
        private async Task<ActionResult> CreateNewUser(string username, string password, string firstName, string lastName)
        {

            try
            {
                await _repository.CreateNewUser(username, password, firstName, lastName);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of users");
                return StatusCode(500);
            }

            var returnResult = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
            };
            return returnResult;
        }







    }
}
       
























//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

/*
                [HttpPost("/userAccount/newAcct")]
                public async Task<ContentResult> CreateNewUserAsync(string username, string password, string firstName, string lastName)
                {
                    //User newsestUser = new User(username, password, firstName, lastName);
                    string[] userParameter = { "username", "password", "firstName", "lastName " };
                    userList.AddRange(userParameter);

                    //try
                    //{
                    //    User userInput = await _repository.CreateNewUser(username, password, firstName, lastName);
                    //}
                    //catch (Exception ex)
                    //{
                    //    _logger.LogError(ex, "error with post method");

                    //    return StatusCode(400);
                    //} 
                    string json = JsonSerializer.Serialize(userList);
                    return new ContentResult()
                    {
                        StatusCode = 201,
                        ContentType = "application/json",
                        Content = json
                    };
                }
        */

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

/*
        [HttpDelete("/userAccount/delect")]
        public ContentResult DeleteSpecificUser([FromBody] string username)   // deletes the number in body
        {
            userAcct.Remove(username);
            string json = JsonSerializer.Serialize(usernames);

            return new ContentResult()
            {
                StatusCode = 202,
                ContentType = "application/json",
                Content = json
            };
        }
*/




/*
        ///////////////////////////
        // POST api/<ValuesController>
        [HttpPost("/username")]
        //public async Task<ActionResult<IEnumerable<User>>> CreateNewUserAsync([FromBody] string username, string password, string firstName, string lastName)
        public async Task<ActionResult<IEnumerable<User>>> CreateNewUserAsync([FromBody] string username, string password, string firstName, string lastName)
        {

            //User newsestUser = new User(username, password, firstName, lastName);
            string[] userParameter = { "username", "password", "firstName", "lastName " };
            userList.AddRange(userParameter);
            string json = JsonSerializer.Serialize(userList);

            try
            {
                User userInput = await _repository.CreateNewUser(username, password, firstName, lastName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error with post method");

                return StatusCode(400);
            }
            return new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };

            //return User.userInput;
            //userAcctList.Add(newName);
            //string json = JsonSerializer.Serialize(usernames);
        }
*/

//[HttpPost("/username")]
//public async Task<User> CreateNewUserAsync([FromBody] string username, string password, string firstName, string lastName) 
////public async Task<ActionResult<IEnumerable<User>>> AddUsersAsync([FromBody] string newName)
////public ContentResult AddUsername([FromBody] string newName)
//{

//    usernames.Add(newName);
//    string json = JsonSerializer.Serialize(usernames);

//    return new ContentResult()
//    {
//        StatusCode = 201,
//        ContentType = "application/json",
//        Content = json
//    };

//    IEnumerable<User> CreateNewUser(username, password, firstName, lastName);
//    try
//    {
//        users = await _repository;
//    }
//    catch (SqlException ex)
//    {
//        _logger.LogError(ex, "SQL error while getting list of users");
//        return StatusCode(500);
//    }
//    return User.ToList();


//}


//[HttpPut("/username")]
//public ContentResult PutUsernameUpdate([FromBody] string oldName, string newName)
//{
//    usernames.Remove(oldName);
//    //string json_deleted = JsonSerializer.Serialize(usernames);
//    usernames.Add(newName);
//    string json = JsonSerializer.Serialize(usernames);
//    return new ContentResult()
//    {
//        StatusCode = 202,
//        ContentType = "application/json",
//        Content = json
//    };
//}



//[HttpDelete("/username/deletebody")]
//public ContentResult DeleteSpecificUser([FromBody] string newName)   // deletes the number in body
//{
//    usernames.Remove(newName);
//    string json = JsonSerializer.Serialize(usernames);

//    return new ContentResult()
//    {
//        StatusCode = 202,
//        ContentType = "application/json",
//        Content = json
//    };
//}

//[HttpDelete("/username/deleteEntireList")]
//public ContentResult DeleteAllUsers()   // deletes the full list of numbers 
//{
//    usernames.Clear();
//    string json = JsonSerializer.Serialize(usernames);

//    return new ContentResult()
//    {
//        StatusCode = 203,
//        ContentType = "application/json",
//        Content = json
//    };
//}




/*

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RecipeServer.RecipeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private static readonly List<string> usernames = new List<string> { "first username" };

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
        public ContentResult PutUsernameUpdate([FromBody] string oldName, string newName)
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
*/