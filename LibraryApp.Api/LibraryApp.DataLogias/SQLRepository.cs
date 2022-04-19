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

            string cmdString = "SELECT * FROM VLLibrary.Accounts;";
            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var memberID = reader.GetInt32(0);
                var memberFName = reader.GetString(1);
                var memberLName = reader.GetString(2);
                var phone = reader.GetString(3);
                result.Add(new(memberID, memberFName, memberLName, phone));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: LookUpAllMemberInfo");
            return result;
        }
        public async Task<IEnumerable<Member>> GetMemberInfoByName(string fName, string lName)
        {
            List<Member> result = new();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = @"SELECT * FROM VLLibrary.Accounts WHERE FirstName = @fName AND LastName = @lName;";
            using SqlCommand cmd = new(cmdString, connection);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@lName", lName);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var memberID = reader.GetInt32(0);
                var memberFName = reader.GetString(1);
                var memberLName = reader.GetString(2);
                var phone = reader.GetString(3);
                result.Add(new(memberID, memberFName, memberLName, phone));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: look up single user completed");
            return result;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            List<Book> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM VLLibrary.Books;";
            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var bookID = reader.GetInt32(0);
                var bookTitle = reader.GetString(1);
                var bookAuthor = reader.GetString(2);
                var bookPrice = reader.GetDecimal(3);
                var bookIn = reader.GetInt32(4);
                result.Add(new(bookID, bookTitle, bookAuthor, bookPrice, bookIn));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: Running GetAllBooks");
            return result;
        }
    }
}
