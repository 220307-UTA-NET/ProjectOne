

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using RecipeBookApp.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBookApp.DataLogic
{
    public class SqlRepository : IRepository
    {

        // Fields
        public readonly string _connectionString;
        private readonly ILogger<SqlRepository> _logger;
        

        // Constructors
        public SqlRepository(string connectionString,
            ILogger<SqlRepository> logger)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this._logger = logger;
        }

        public async Task<IEnumerable<User>> ListOfUsers()
        {
            List<User> returnList = new();

            using SqlConnection connection = new (_connectionString);
            await connection.OpenAsync();

            string SQLcmd_string = ("SELECT * FROM Recipes.Users;");

            using SqlCommand SQLcmd = new(SQLcmd_string, connection);

            using SqlDataReader myReader = SQLcmd.ExecuteReader();

            

            while (myReader.Read())
            {
                var Username = myReader.GetString(0);
                var Password = myReader.GetString(1);
                var FirstName = myReader.GetString(2);
                var LastName = myReader.GetString(3);
                returnList.Add(new(Username, Password, FirstName, LastName));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed: ListOfUsers");

            return returnList;
        }

        public async Task<ContentResult> CreateNewUser(string username, string password, string firstName, string lastName)
        { 
            //List<User> returnList = new();
            using SqlConnection connection2 = new(_connectionString);
            //User newUser = new();
            await connection2.OpenAsync();

            string cmdTxt = 
              @"INSERT INTO Recipes.Users (username, password, FirstName, LastName)  
              VALUES
                (@username, @password, @firstName, @lastName);";

            using SqlCommand SQLcmd = new (cmdTxt, connection2);
            
            SQLcmd.Parameters.AddWithValue("@username", username);
            SQLcmd.Parameters.AddWithValue("@password", password);
            SQLcmd.Parameters.AddWithValue("@FirstName", firstName);
            SQLcmd.Parameters.AddWithValue("@LastName", lastName);

            SQLcmd.ExecuteNonQuery();

            await connection2.CloseAsync();
            _logger.LogInformation("New account has been created");
            return new ContentResult() { StatusCode = 201};
            
        }
    }
}