using Microsoft.Extensions.Logging;
using Project1.BL;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Project1.DL
{
    public class SQLRepository : IRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        public async Task<IEnumerable<ERCOT>> GetERCOTEnergy()
        {
            List<ERCOT> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                "SELECT ERCOT_ID, Year, Month, Peak_MegaWatts, Monthly_Total_Energy FROM dbo.ERCOT;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ERCOT_ID = reader.GetInt32(0);
                var Year = reader.GetInt32(1);
                var Month = reader.GetString(2);
                var Peak_MegaWatts = reader.GetInt32(3);
                var Monthly_Total_Energy = reader.GetInt32(4);
                result.Add(new(ERCOT_ID, Year, Month, Peak_MegaWatts, Monthly_Total_Energy));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllEnergyDemand");

            return result;
        }

        public async Task<IEnumerable<ERCOT>> GetEnergyERCOTMonth(string Month)
        {

            List<ERCOT> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"SELECT ERCOT_ID, Year, Month, Peak_MegaWatts, Monthly_Total_Energy FROM dbo.ERCOT " +
                "WHERE Month = @Month;";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@Month", Month);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ERCOT_ID = reader.GetInt32(0);
                var Year = reader.GetInt32(1);
                var returnMonth = reader.GetString(2);
                var Peak_MegaWatts = reader.GetInt32(3);
                var Monthly_Total_Energy = (int)reader.GetInt32(4);
                result.Add(new(ERCOT_ID, Year, returnMonth, Peak_MegaWatts, Monthly_Total_Energy));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetMonth");

            return result;
        }

        public async Task<IEnumerable<NEISO>> GetEnergyNEISO()
        {
            List<NEISO> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"SELECT * FROM dbo.NEISO";
            Console.WriteLine(cmdString);
            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var NEISO_ID = reader.GetInt32(0);
                var Forcast_Date = reader.GetDateTime(1);
                var Hour = reader.GetInt32(2);
                var Reliability_Region = reader.GetString(3);
                var Mega_Watts = reader.GetInt32(4);
                result.Add(new(NEISO_ID, Forcast_Date, Hour, Reliability_Region, Mega_Watts));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetEnergyNEISO");

            return result;
        }

        public async Task PostNEISOEnergyReport(NEISOEnergyReport HourlyEnergyReport)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"INSERT INTO dbo.NEISO (Forcast_Date, Hour, Reliability_Region, Mega_Watts) VALUES (@Forcast_Date, @Hour, @Reliability_Region, @Mega_Watts)";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Forcast_Date", SqlDbType.DateTime).Value = HourlyEnergyReport.Forcast_Date;
            cmd.Parameters.Add("@Hour", SqlDbType.Int).Value = HourlyEnergyReport.Hour;
            cmd.Parameters.Add("@Reliability_Region", SqlDbType.VarChar).Value = HourlyEnergyReport.Reliability_Region;
            cmd.Parameters.Add("@Mega_Watts", SqlDbType.Int).Value = HourlyEnergyReport.Mega_Watts;

            await cmd.ExecuteNonQueryAsync();

            await connection.CloseAsync();

            _logger.LogInformation("Executed: InsertHourlyEnergyReport");

 
        }

        public async Task PutNEISOEnergyReport(NEISO HourlyEnergyReport)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"UPDATE dbo.NEISO SET Forcast_Date = @Forcast_Date, Hour = @Hour, Reliability_Region = @Reliability_Region, 
                                Mega_Watts = @Mega_Watts WHERE NEISO_ID = @NEISO_ID";
            Console.WriteLine(cmdString);
            using SqlCommand cmd = new(cmdString, connection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@NEISO_ID", SqlDbType.Int).Value = HourlyEnergyReport.NEISO_ID;
            cmd.Parameters.Add("@Forcast_Date", SqlDbType.DateTime).Value = HourlyEnergyReport.Forcast_Date;
            cmd.Parameters.Add("@Hour", SqlDbType.Int).Value = HourlyEnergyReport.Hour;
            cmd.Parameters.Add("@Reliability_Region", SqlDbType.VarChar).Value = HourlyEnergyReport.Reliability_Region;
            cmd.Parameters.Add("@Mega_Watts", SqlDbType.Int).Value = HourlyEnergyReport.Mega_Watts;

            await cmd.ExecuteNonQueryAsync();

            await connection.CloseAsync();

            _logger.LogInformation("Executed: UpdateHourlyEnergyReport");


        }

        public async Task DeleteNEISOEnergyReport(int id)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = @"DELETE FROM dbo.NEISO WHERE NEISO_ID = @NEISO_ID";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@NEISO_ID", SqlDbType.Int).Value = id;

            await cmd.ExecuteNonQueryAsync();

            await connection.CloseAsync();

            _logger.LogInformation("Executed: DeleteHourlyEnergyReport");

        }

    }
}