using BettaFishApp.Logic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettaFishApp.DataLogic
{
    public class SQLRepository : IRepository
    {

        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        // Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        public async Task<IEnumerable<BettaType>> GetAllBettaTypeAsync()
        {
            List<BettaType> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT tail_ID, tailType, description FROM BettaFish.Type;";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var tail_ID = reader.GetInt32(0);
                var tailType = reader.GetString(1);
                var description = reader.GetString(2);

                result.Add(new(tail_ID, tailType, description));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Get All Betta Type");
            return result;
        }

        public async Task<List<BettaType>> GetBettaDescriptionAsync()
        {

            List<BettaType> bettadescription = new List<BettaType>();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT * FROM BettaFish.Type;";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var tail_ID = reader.GetInt32(0);
                var tailType = reader.GetString(1);
                var description = reader.GetString(2);

                bettadescription.Add(new(tail_ID, tailType, description));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Get Betta Description");
            return bettadescription;

        }

        public async Task<List<BettaStories>> GetAllBettaFanStoriesAsync()
        {

            List<BettaStories> bettafanstories = new List<BettaStories>();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT * FROM BettaFish.Stories";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var story_ID = reader.GetInt32(0);
                var nameOfBetta = reader.GetString(1);
                var story = reader.GetString(2);

                bettafanstories.Add(new(story_ID, nameOfBetta, story));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Get Betta Fan Stories");
            return bettafanstories;

        }

        public async Task<IEnumerable<BettaFunFacts>> GetAllBettaFunFactsAsync()
        {

            List<BettaFunFacts> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT * FROM BettaFish.Facts;";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var fact_ID = reader.GetInt32(0);
                var funFact = reader.GetString(1);

                result.Add(new(fact_ID, funFact));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Get All Betta Fun Facts");
            return result;
        }

        public async Task<List<BettaRegistration>> GetAllWebRegistrationAsync()
        {
            List<BettaRegistration> viewregistration = new List<BettaRegistration>();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT * FROM BettaFish.Registration";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var registration_ID = reader.GetInt32(0);
                var fName = reader.GetString(1);
                var lName = reader.GetString(2);
                var email = reader.GetString(2);


                viewregistration.Add(new(registration_ID, lName, fName, email));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: View Registration is Successful");
            return viewregistration;

        }

        public async Task<List<BettaStoreLocation>> GetAllStoreLocationAsync()
        {
            List<BettaStoreLocation> storelocation = new List<BettaStoreLocation>();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT * FROM BettaFish.Stores";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var store_ID = reader.GetInt32(0);
                var storeName = reader.GetString(1);
                var storeAddress = reader.GetString(2);

                storelocation.Add(new(store_ID, storeName, storeAddress));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Get All Store Location is Successful");
            return storelocation;

        }

        public async Task WebRegistration(BettaRegistration bettaregistration)
        {

           
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"INSERT INTO BettaFish.Registration (fName, lName, email) VALUES (@fName, @lName, @email);";


            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@fName", bettaregistration.GetfName());
            cmd.Parameters.AddWithValue("@lName", bettaregistration.GetlName());
            cmd.Parameters.AddWithValue("@email", bettaregistration.Getemail());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Registration is Successful.");

        }

        public async Task GetBettaStories(BettaStories bettastories)
        {

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"INSERT INTO BettaFish.Stories (nameOfBetta, story) VALUES (@nameOfBetta, @story);";


            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@nameOfBetta", bettastories.GetNameOfBetta());
            cmd.Parameters.AddWithValue("@story", bettastories.GetStory());

            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Story is created.");

        }


    }
    
}
