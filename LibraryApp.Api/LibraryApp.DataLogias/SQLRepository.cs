using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using LibraryApp.BusinessLogias;


namespace LibraryApp.DataLogias
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

        //Methods
        public async Task<IEnumerable<Member>> LookUpAllMemberInfo()
        {
            List<Member> result = new();

            using SqlConnection connection = new (_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM VLLibrary.Members;";
            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var memberID = reader.GetInt32(0);
                var fName = reader.GetString(1);
                var lName = reader.GetString(2);
                var phone = reader.GetInt32(3);
                result.Add(new(memberID, fName, lName, phone));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: LookUpAllMemberInfo");
            return result;
        }
    }
}
