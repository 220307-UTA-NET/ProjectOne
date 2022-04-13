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
        public async Task<IEnumerable<BettaType>> GetAllBettaType(int y, string b, string c)
        {
            List<BettaType> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT tail_ID, tailType, description FROM BettaFish.Type;";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int tail_ID = reader.GetInt32(0);
                string tailType = reader.GetString(1);
                string description = reader.GetString(2);

                result.Add(new(tail_ID, tailType, description));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllBettaType");

            return result;
        }
        public async Task<IEnumerable<BettaFunFacts>> GetAllBettaFunFacts(int x, string a)
        {

            List<BettaFunFacts> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"SELECT fact_ID, funFact FROM BettaFish.Facts;";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int fact_ID = reader.GetInt32(0);
                string funFact = reader.GetString(1);

                result.Add(new(fact_ID, funFact));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllBettaFunFacts");

            return result;
        }

    }
}