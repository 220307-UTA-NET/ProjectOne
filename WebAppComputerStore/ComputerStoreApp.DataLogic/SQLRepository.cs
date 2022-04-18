using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStoreApp.BusinessLogic;
using Microsoft.Extensions.Logging;




namespace ComputerStoreApp.DataLogic
{
    public class SQLRepository : IRepository
    {
        //Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        //Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        public async Task<IEnumerable<Computer_Make>> GetAllComputers()
        {
            List<Computer_Make> result = new();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                "SELECT Computer_Make_ID, Computer_Make_Name, Computer_Make_Price, Computer_Type_ID, Computer_OS_ID FROM ComputerStore.Computer_Make;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ID = reader.GetInt32(0);
                var Name = reader.GetString(1);
                var Price = reader.GetDecimal(2);
                var Type = reader.GetInt32(3);
                var OS = reader.GetInt32(4);
                result.Add(new (ID, Name, Price, Type, OS));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Get All Computers!");


            return result;
        }

        public async Task<IEnumerable<Computer_Make>> GetComputer(string Name)
        {
            List<Computer_Make> result = new();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"SELECT * FROM ComputerStore.Computer_Make" +
                "WHERE Computer_Make_Name = @Name;";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@Name", Name);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ComputerID = reader.GetInt32(0);
                var ComputerName = reader.GetString(1);
                var ComputerPrice = reader.GetDecimal(2);
                var ComputerType = reader.GetInt32(3);
                var ComputerOS = reader.GetInt32(4);
                result.Add(new(ComputerID, ComputerName, ComputerPrice, ComputerType, ComputerOS));
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed: Get All Computers!!");
            return result;
        }
    }
}
