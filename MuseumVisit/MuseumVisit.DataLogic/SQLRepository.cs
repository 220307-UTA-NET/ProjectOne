using System;

using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using MuseumVisit.BusinessLogic;
using Microsoft.Extensions.Logging;
using MuseumVisit;

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



        public async Task<IEnumerable<Person>> GetPerson(string FirstName, string LastName)
        {

            List<Person> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"SELECT Id, FirstName, LastName, Salary, VisitList FROM museum.patron WHERE FirstName = @FirstName AND LastName = @LastName;";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                var FName = reader.GetString(1);
                var LName = reader.GetString(2);
                var Salary = reader.GetInt32(3);
                var VisitList = reader.GetInt32(4);
                result.Add(new(Id, FName, LName, Salary, VisitList));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetPerson");

            return result;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            List<Person> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                "SELECT Id, FirstName, LastName, Salary, VisitList FROM museum.patron;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                var FName = reader.GetString(1);
                var LName = reader.GetString(2);
                var Salary = reader.GetInt32(3);
                var VisitList = reader.GetInt32(4);
                result.Add(new(Id, FName, LName, Salary, VisitList));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllPersons");

            return result;
        }

        public async Task<int> CreatePerson(Person person)
        {
            //int result;
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString =
             @"INSERT INTO museum.patron(FirstName, LastName, Salary, VisitList) VALUES (@FirstName, @LastName, @Salary, @VisitList)";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", person.LastName);
            cmd.Parameters.AddWithValue("@Salary", person.Salary);
            cmd.Parameters.AddWithValue("@VisitList", person.VisitList);
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();


            _logger.LogInformation("Executed: Inserted into DB");   

            await connection.OpenAsync();
            List<Person> result = new();

            string cmdString1 =
                @"SELECT Id, FirstName, LastName, Salary, VisitList FROM museum.patron WHERE FirstName = @FirstName AND LastName = @LastName;";

            using SqlCommand cmd1 = new(cmdString1, connection);

            cmd1.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd1.Parameters.AddWithValue("@LastName", person.LastName);
            using SqlDataReader reader = cmd1.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                var FName = reader.GetString(1);
                var LName = reader.GetString(2);
                var Sal = reader.GetInt32(3);
                var Visit = reader.GetInt32(4);
                result.Add(new(Id, FName, LName, Sal, Visit));
            }
            await connection.CloseAsync();

            return result[0].Id;

        }

        public async Task DeletePerson(int Id)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString =
             @"DELETE FROM museum.patron WHERE Id = @Id";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@Id", Id);
         
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();
        }

    }

}

