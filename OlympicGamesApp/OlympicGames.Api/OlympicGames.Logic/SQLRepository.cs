using Microsoft.Extensions.Logging;
using OlympicGames.BusinessLogic;
using OlympicGames.DataLogic;
using System.Data.SqlClient;

namespace OlympicGames.DataLogic
{
    public class SQLRepository : IRepository
    {
        private readonly string connection;
        private readonly ILogger<SQLRepository> _logger;

        public SQLRepository(string connection, ILogger<SQLRepository> logger)
        {
            this.connection = connection;
            this._logger = logger;
        }

        public async Task<IEnumerable<Onboarding>> GetAbout()
        {
            List<Onboarding> about = new();
            using SqlConnection connection_ = new(connection);
            await connection_.OpenAsync();

            string sql = @"SELECT * FROM OlympicGames.About WHERE Description_ID = 1;";
            using SqlCommand cmd = new(sql, connection_);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var desc_Info = reader.GetString(1);
                var desc_Author = reader.GetString(2);
                DateTime desc_Date = reader.GetDateTime(3);
                var desc_Source = reader.GetString(4);
                about.Add(new(desc_Info, desc_Author, desc_Date, desc_Source));
            }
            await connection_.CloseAsync();
            _logger.LogInformation("Executed: GetAbout()");
            return about;
        }
        public async Task<IEnumerable<Onboarding>> GetMedalInfo()
        {
            List<Onboarding> about = new();
            using SqlConnection connection_ = new(connection);
            await connection_.OpenAsync();

            string sql = @"SELECT * FROM OlympicGames.About WHERE Description_ID = 2;";
            using SqlCommand cmd = new(sql, connection_);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var desc_Info = reader.GetString(1);
                var desc_Author = reader.GetString(2);
                DateTime desc_Date = reader.GetDateTime(3);
                var desc_Source = reader.GetString(4);
                about.Add(new(desc_Info, desc_Author, desc_Date, desc_Source));
            }
            await connection_.CloseAsync();
            _logger.LogInformation("Executed: GetMedalInfo()");
            return about;
        }
        

        public async Task PostConsumerToDatabase(string name)
        {
            using SqlConnection sqlConnection = new(connection);
            await sqlConnection.OpenAsync();
            string insert_name = "INSERT INTO OlympicGames.Consumer(C_Name) VALUES(@name);";
            using SqlCommand cmd = new(insert_name, sqlConnection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
            _logger.LogInformation($"Executed: PostConsumerToDatabase (name)");
        }

        
        public async Task<IEnumerable<Country>> GetCountryMedalInfo()
        {
            List<Country> about = new();
            using SqlConnection connection_ = new(connection);
            await connection_.OpenAsync();
            string sql = @"SELECT * FROM OlympicGames.Countries;";
            using SqlCommand cmd = new(sql, connection_);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var country = reader.GetString(1);
                var gold = reader.GetInt32(2);
                var silver = reader.GetInt32(3);
                var bronze = reader.GetInt32(4);
                var total = reader.GetInt32(5);
                about.Add(new(country, gold, silver, bronze, total));
            }
            await connection_.CloseAsync();
            _logger.LogInformation("Executed: GetCountryMedalInfo()");
            return about;
        }
        


            /*
            public async Task PostConsumerToDatabase(string name)
            {
                using SqlConnection sqlConnection = new(connection);
                await sqlConnection.OpenAsync();
                string insert_name = "INSERT INTO OlympicGames.Consumer(C_Name) VALUES({current.name});";
                using SqlCommand cmd = new(insert_name, sqlConnection);
                cmd.ExecuteNonQuery();
                await sqlConnection.CloseAsync();
                _logger.LogInformation($"Executed: AddToInventory Item:");
            }
            */
            public async Task PostConsumerToDatabase(Consumer consumer)
         {
            _logger.LogInformation(consumer.Name);
            using SqlConnection connection_ = new(connection);
            await connection_.OpenAsync();

            string cmdString = @"INSERT INTO OlympicGames.Consumer(C_Name) VALUES(@full_name);";
            using SqlCommand cmd = new(cmdString, connection_);

            cmd.Parameters.AddWithValue("@full_name", consumer.GetName());
            cmd.BeginExecuteNonQuery();
            await connection_.CloseAsync();
            _logger.LogInformation("Executed: PostConsumerToDatabase (name)");
        }

        /*
        public async Task<IEnumerable<Registration>>PostConsumerToDatabase()
        {
            using SqlConnection sqlConnection = new(connection);
            await sqlConnection.OpenAsync();
            string insert_name = "INSERT INTO OlympicGames.Consumer(C_Name) VALUES(@full_name);";
            using SqlCommand cmd = new(insert_name, sqlConnection);
            cmd.Parameters.AddWithValue("@fName", );
            cmd.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
            _logger.LogInformation($"Executed: AddToInventory Item:");
        }
        */
    }
}