using System;

using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using MuseumVisit.BusinessLogic;
using Microsoft.Extensions.Logging;

namespace MuseumVisit.DataLogic
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
	}


    public async Task<IEnumerable<Person>> GetPerson(string FirstName, string LastName)
    {

        List<Person> result = new();

        using SqlConnection connection = new(_connectionString);
        await connection.OpenAsync();

        string cmdString =
            @"SELECT Device_ID, Device_Name, Device_Type_ID, Device_OS_ID FROM RED.Device " +
            "WHERE Device_Name = @Name;";

        using SqlCommand cmd = new(cmdString, connection);

        cmd.Parameters.AddWithValue("@Name", Name);

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var ID = reader.GetInt32(0);
            var retName = reader.GetString(1);
            var Type = reader.GetInt32(2);
            var OS = reader.GetInt32(3);
            result.Add(new(ID, retName, Type, OS));
        }
        await connection.CloseAsync();

        _logger.LogInformation("Executed: GetAllDevices");

        return result;
    }
}

