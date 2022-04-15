using BettaFishApp.InformationLogic;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;

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

        // Methods
        public async Task<IEnumerable<BettaType>> GetAllBettaTypeAsync()
        {
            List<BettaType> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT * FROM BettaFish.Type;";

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

            _logger.LogInformation("Executed: GetAllBettaType");
            return result;
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

            _logger.LogInformation("Executed: GetAllBettaFunFacts");
            return result;
        }

        public async Task WebRegistration(Registration registration)
        {

            //List<Registration> result = new();

            _logger.LogInformation(registration.fName);
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"INSERT INTO BettaFish.Registration (fName, lName, email) VALUES (@fName, @lName, @email);";
            

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@fName", registration.GetfName());
            cmd.Parameters.AddWithValue("@lName", registration.GetlName());
            cmd.Parameters.AddWithValue("@email", registration.Getemail());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Registration is Successful.");

        }

    }
}