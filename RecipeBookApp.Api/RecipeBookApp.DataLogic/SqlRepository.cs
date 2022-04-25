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

        public async Task<IEnumerable<Recipe>> ListOfRecipes()
        {
            List<Recipe> returnList = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string SQLcmd_string = ("SELECT * FROM Recipes.RecipeInfo;");

            using SqlCommand SQLcmd = new(SQLcmd_string, connection);

            using SqlDataReader myReader = SQLcmd.ExecuteReader();

            while (myReader.Read())
            {
                var RecipeName = myReader.GetString(0);
                var Rating = myReader.GetDecimal(1);
                returnList.Add(new(RecipeName, Rating));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed: ListOfRecipes");

            return returnList;
        }

        public async Task<IEnumerable<Recipe>> FindRecipe(string TheRecipeName)
        {
            List<Recipe> returnList = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string SQLcmd_string = ("SELECT * FROM Recipes.RecipeInfo WHERE RecipeName = @RecipeName;");

            using SqlCommand SQLcmd = new(SQLcmd_string, connection);

            SQLcmd.Parameters.AddWithValue("@RecipeName", TheRecipeName);

            using SqlDataReader myReader = SQLcmd.ExecuteReader();

            while (myReader.Read())
            {
                var RecipeName = myReader.GetString(0);
                var Rating = myReader.GetDecimal(1);
                returnList.Add(new(RecipeName, Rating));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed: Find Recipe ",TheRecipeName);

            return returnList;
        }


        public async Task<ContentResult> CreateNewRecipe(string RecipeName, decimal rating)
        {
            //List<User> returnList = new();
            using SqlConnection connection2 = new(_connectionString);
            //User newUser = new();
            await connection2.OpenAsync();

            string cmdTxt =
              @"INSERT INTO Recipes.RecipeInfo (RecipeName, Rating)  
              VALUES
                (@RecipeName, @ratingPlaceHolder);";

            using SqlCommand SQLcmd = new(cmdTxt, connection2);

            SQLcmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            SQLcmd.Parameters.AddWithValue("@ratingPlaceHolder", rating);

            SQLcmd.ExecuteNonQuery();

            await connection2.CloseAsync();
            _logger.LogInformation("New recipe has been added");
            return new ContentResult() { StatusCode = 201 };
        }


        public async Task<ContentResult> AddToIngredientsList(string RecipeName, decimal IngredientQuantity, string UnitOfMeasure, string Ingredient)
        {
            //List<User> returnList = new();
            using SqlConnection connection2 = new(_connectionString);
            //User newUser = new();
            await connection2.OpenAsync();

            string cmdTxt =
              @"INSERT INTO Recipes.Ingredients(RecipeName,IngredientQuantity, UnitOfMeasure, Ingredient)  
              VALUES
                (@RecipeName,@IngredientQuantity, @UnitOfMeasure, @Ingredient);";

            using SqlCommand SQLcmd = new(cmdTxt, connection2);

            SQLcmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            SQLcmd.Parameters.AddWithValue("@IngredientQuantity", IngredientQuantity);
            SQLcmd.Parameters.AddWithValue("@UnitOfMeasure", UnitOfMeasure);
            SQLcmd.Parameters.AddWithValue("@Ingredient", Ingredient);
                

            SQLcmd.ExecuteNonQuery();

            await connection2.CloseAsync();
            _logger.LogInformation("Added new ingredient to ingredients list. ");
            return new ContentResult() { StatusCode = 201 };
        }

        public async Task<IEnumerable<Ingredient>> ListOfIngredients()
        {
            List<Ingredient> returnList = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string SQLcmd_string = ("SELECT * FROM Recipes.Ingredients;");

            using SqlCommand SQLcmd = new(SQLcmd_string, connection);

            using SqlDataReader myReader = SQLcmd.ExecuteReader();

            while (myReader.Read())
            {
                var RecipeName = myReader.GetString(0);
                var IngredientQuantity = myReader.GetDecimal(1);
                var UnitOfMeasure = myReader.GetString(2);
                var Ingredient = myReader.GetString(3);
                returnList.Add(new(RecipeName, IngredientQuantity, UnitOfMeasure, Ingredient));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed: ListOfIngredients");

            return returnList;
        }


        public async Task<IEnumerable<Ingredient>> SingleListOfIngredients(string TheRecipeName)
        {
            List<Ingredient> returnList = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string SQLcmd_string = 
                (
                "SELECT IngredientQuantity, UnitOfMeasure, Ingredient " +
                "FROM Recipes.Ingredients " +
                "WHERE RecipeName = @RecipeName;"
                );

            using SqlCommand SQLcmd = new(SQLcmd_string, connection);

            SQLcmd.Parameters.AddWithValue("@RecipeName", TheRecipeName);

            using SqlDataReader myReader = SQLcmd.ExecuteReader();

            while (myReader.Read())
            {
                //var RecipeName = myReader.GetString(0);
                var IngredientQuantity = myReader.GetDecimal(0);
                var UnitOfMeasure = myReader.GetString(1);
                var Ingredient = myReader.GetString(2);
                returnList.Add(new(TheRecipeName, IngredientQuantity, UnitOfMeasure, Ingredient));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed: ListOfIngredients");

            return returnList;
        }


        public async Task<IEnumerable<Step>> SingleListOfSteps(string TheRecipeName)
        {
            List<Step> returnList = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string SQLcmd_string =
                (
                "SELECT StepNumber, StepDescription " +
                "FROM Recipes.Steps " +
                "WHERE RecipeName = @RecipeName;"
                );

            using SqlCommand SQLcmd = new(SQLcmd_string, connection);

            SQLcmd.Parameters.AddWithValue("@RecipeName", TheRecipeName);

            using SqlDataReader myReader = SQLcmd.ExecuteReader();

            while (myReader.Read())
            {
                //var RecipeName = myReader.GetString(0);
                var StepNumber = myReader.GetInt32(0);
                var StepDescription = myReader.GetString(1);
                returnList.Add(new(TheRecipeName, StepNumber, StepDescription));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed: Got SingleListOfSteps");

            return returnList;
        }







        public async Task<ContentResult> DeleteRecipe(string TheRecipeName)
        {
            using SqlConnection connection2 = new(_connectionString);
            //User newUser = new();
            await connection2.OpenAsync();

            string cmdTxt =
              @"DELETE FROM Recipes.RecipeInfo WHERE RecipeName = (@RecipeName);";

            using SqlCommand SQLcmd = new(cmdTxt, connection2);
            
            SQLcmd.Parameters.AddWithValue("@RecipeName", TheRecipeName);

            SQLcmd.ExecuteNonQuery();

            await connection2.CloseAsync();
            _logger.LogInformation("New recipe has been added");
            return new ContentResult() { StatusCode = 201 };
        }




        /*
                public async Task<IEnumerable<FullDetail>> FullRecipeDetails(string TheRecipeName)
                {

                    List<FullDetail> returnList = new();
                    FullDetail fullDetail = new FullDetail();



                    //recipe
                    using SqlConnection connection = new(_connectionString);
                    await connection.OpenAsync();

                    string SQLcmd_string1 = ("SELECT * FROM Recipes.RecipeInfo WHERE RecipeName = @RecipeName;");

                    using SqlCommand SQLcmd1 = new(SQLcmd_string1, connection);

                    SQLcmd1.Parameters.AddWithValue("@RecipeName", TheRecipeName);

                    using SqlDataReader myReader1 = SQLcmd1.ExecuteReader();

                    while (myReader1.Read())
                    {
                        fullDetail.RecipeName = myReader1.GetString(0);
                        fullDetail.Rating = myReader1.GetDecimal(1);
                        //returnList.Add(new(RecipeName, Rating));
                    }

                    await connection.CloseAsync();


                    //ingredients
                    using SqlConnection connection2 = new(_connectionString);
                    await connection2.OpenAsync();
                    string SQLcmd_stringIngredient =
                        (
                        "SELECT IngredientQuantity, UnitOfMeasure, Ingredient " +
                        "FROM Recipes.Ingredients " +
                        "WHERE RecipeName = @RecipeName;"
                        );

                    using SqlCommand SQLcmdIngredient = new(SQLcmd_stringIngredient, connection);

                    SQLcmdIngredient.Parameters.AddWithValue("@RecipeName", TheRecipeName);

                    using SqlDataReader myReaderIngredient = SQLcmdIngredient.ExecuteReader();

                    while (myReaderIngredient.Read())
                    {
                        //var RecipeName = myReader.GetString(0);
                        fullDetail.IngredientQuantity = myReaderIngredient.GetDecimal(0);
                        fullDetail.UnitOfMeasure = myReaderIngredient.GetString(1);
                        fullDetail.IngredientName = myReaderIngredient.GetString(2);
                        //returnList.Add(new(TheRecipeName, IngredientQuantity, UnitOfMeasure, Ingredient));
                    }
                    await connection2.CloseAsync();


                    //steps
                    using SqlConnection connection1 = new(_connectionString);
                    await connection1.OpenAsync();


                    string SQLcmd_string =
                        (
                        "SELECT StepNumber, StepDescription" +
                        "FROM Recipes.Steps " +
                        "WHERE RecipeName = @RecipeName;"
                        );
                    using SqlCommand SQLcmd = new(SQLcmd_string, connection);
                    SQLcmd.Parameters.AddWithValue("@RecipeName", TheRecipeName);

                    using SqlDataReader myReader = SQLcmd.ExecuteReader();
                    while (myReader1.Read())
                    {
                        fullDetail.StepNumber = myReader.GetInt32(0);
                        fullDetail.StepDescription = myReader.GetString(1);
                    }
                    await connection1.CloseAsync();


                    _logger.LogInformation("Executed: Got SingleListOfSteps");


                    //return fullDetail;
                    returnList.Add(fullDetail);
                    //return ;
                    return returnList;
                }*/






    }

}