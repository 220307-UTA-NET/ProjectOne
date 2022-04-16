using Microsoft.Extensions.Logging;
using Project1.Model;
using System.Data.SqlClient;

namespace Project1.DataLogic
{
    public class SQLRepository : IRepository
    {
        //Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> logger;

        //Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)

        {
            this._connectionString = connectionString;
            this.logger = logger;
        }

        //Methods
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "Select * FROM Users;";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var bankUserId = reader.GetInt32(0);
                var bankUserFirstName = reader.GetString(1);
                var bankUserLastName = reader.GetString(2);
                var bankUserUsername = reader.GetString(3);
                var bankUserPassword = reader.GetString(4);
                
                result.Add(new(bankUserId, bankUserFirstName, bankUserLastName, bankUserUsername, bankUserPassword));
           }
            await connection.CloseAsync();

            logger.LogInformation("Executed: GetAllUsers");
            return result;

        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            List<Account> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "Select * FROM Account;";

            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var bankAccountId = reader.GetInt32(0);
                var bankAccountBalance = reader.GetDecimal(1);
                var bankUserId = reader.GetInt32(2);
                result.Add(new(bankAccountId, bankAccountBalance, bankUserId));
            }
            await connection.CloseAsync();

            logger.LogInformation("Executed: GetAllAccounts");
            return result;

        }

        public async Task RegisterUser(User bankUser)
        {

            //List<User> result = new();
            //logger.LogInformation(bankUser.bankUserFirstName);
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"INSERT INTO Users (bankUserFirstName,bankUserLastName,bankUserUsername,bankUserPassword) VALUES (@bankUserFirstName, @bankUserLastName, @bankUserUsername, @bankUserPassword);";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@bankUserFirstName", bankUser.GetbankUserFirstName());
            cmd.Parameters.AddWithValue("@bankUserLastName", bankUser.GetbankUserLastName());
            cmd.Parameters.AddWithValue("@bankUserUsername", bankUser.GetbankUserUsername());
            cmd.Parameters.AddWithValue("@bankUserPassword", bankUser.GetbankUserPassword());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            logger.LogInformation("New user registered!");
        }

        public async Task RegisterAccount(Account bankAccount)
        {

            //List<Account> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"INSERT INTO Account (bankAccountBalance ,bankUserId) values (@bankAccountBalance, @bankUserId);";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@bankAccountBalance", bankAccount.GetbankAccountBalance());
            cmd.Parameters.AddWithValue("@bankUserId", bankAccount.GetbankUserId());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            logger.LogInformation("Bank Account Registered");

        }

        public Task UpdateUser(User bankUser)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccount(Account bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}