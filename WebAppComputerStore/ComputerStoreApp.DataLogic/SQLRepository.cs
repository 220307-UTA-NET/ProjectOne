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

        public async Task<IEnumerable<Computer_Make>> AddComputer()
        {
            SqlCommand command;
            List<Computer_Make> computer = new List<Computer_Make>();
            using SqlConnection connection = new(_connectionString);
            using (command = connection.CreateCommand()) ; 
            SqlDataAdapter adapter = new SqlDataAdapter();
            await connection.OpenAsync();
            string cmdString = "INSERT INTO ComputerStore.Computer_Make"+
                "Values('Chroombook', 200, 1, 3);";
            
            adapter.InsertCommand = new SqlCommand(cmdString, connection);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return computer;
        }

        public async Task<IEnumerable<Computer_Make>> GetAllComputers()
        {
            List<Computer_Make> result = new();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
               // "SELECT Computer_Make_ID, Computer_Make_Name, Computer_Make_Price, Computer_Type_ID, Computer_OS_ID FROM ComputerStore.Computer_Make;";
                "SELECT distinct ComputerStore.Computer_OS.OS_Name,ComputerStore.Computer_Type.Computer_Type_Name, Computer_Make_Price, Computer_Make_Name FROM ComputerStore.Computer_OS JOIN ComputerStore.Computer_Make ON Computer_OS_ID = Computer_Make.Computer_OS_ID JOIN ComputerStore.Computer_Type ON Computer_Type.Computer_Type_ID = Computer_Make.Computer_Type_ID;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                /*var ID = reader.GetInt32(0);
                var Name = reader.GetString(1);
                var Price = reader.GetDecimal(2);
                var Type = reader.GetInt32(3);
                var OS = reader.GetInt32(4);
                result.Add(new (ID, Name, Price, Type, OS));*/
             
                var OS_Name = reader.GetString(0);
                var Type_Name = reader.GetString(1);
                var Price = reader.GetDecimal(2);
                var MakeName = reader.GetString(3);
                result.Add(new(OS_Name, Type_Name, Price, MakeName));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Get All Computers!");


            return result;
        }

    }
}
