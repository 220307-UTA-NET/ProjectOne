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
                @"INSERT INTO Account (bankAccountBalance ,bankUserId) VALUES (@bankAccountBalance, @bankUserId);";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@bankAccountBalance", bankAccount.GetbankAccountBalance());
            cmd.Parameters.AddWithValue("@bankUserId", bankAccount.GetbankUserId());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            logger.LogInformation("Bank Account Registered");

        }

        public async Task UpdateUser(User bankUser)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString1 = @"UPDATE Users SET bankUserFirstName = (@bankUserFirstName) WHERE bankUserUsername = (@bankUserUsername);";
            string cmdString2 = @"UPDATE Users SET bankUserLastName = (@bankUserLastName) WHERE bankUserUsername = (@bankUserUsername);";
            string cmdString3 = @"UPDATE Users SET bankUserPassword = (@bankUserPassword) WHERE bankUserUsername = (@bankUserUsername);";

            using SqlCommand cmd1 = new(cmdString1, connection);
            cmd1.Parameters.AddWithValue("@bankUserFirstName", bankUser.GetbankUserFirstName());
            cmd1.Parameters.AddWithValue("@bankUserUsername", bankUser.GetbankUserUsername());
            cmd1.ExecuteNonQuery();
            using SqlCommand cmd2 = new(cmdString2, connection);
            cmd2.Parameters.AddWithValue("@bankUserLastName", bankUser.GetbankUserLastName());
            cmd2.Parameters.AddWithValue("@bankUserUsername", bankUser.GetbankUserUsername());
            cmd2.ExecuteNonQuery();
            using SqlCommand cmd3 = new(cmdString3, connection);
            cmd3.Parameters.AddWithValue("@bankUserUsername", bankUser.GetbankUserUsername());
            cmd3.Parameters.AddWithValue("@bankUserPassword", bankUser.GetbankUserPassword());
            cmd3.ExecuteNonQuery();

            await connection.CloseAsync();

            logger.LogInformation("Bank User Updated!");
        }

        public async Task UpdateAccount(Account bankAccount)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"UPDATE Account SET bankAccountBalance = (@bankAccountBalance) WHERE bankUserId = (@bankUserId);";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@bankAccountBalance", bankAccount.GetbankAccountBalance());
            cmd.Parameters.AddWithValue("@bankUserId", bankAccount.GetbankUserId());
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            logger.LogInformation("Bank Account Updated");
        }

        public async Task DeleteUser(User bankUser)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"DELETE FROM Users (bankUserFirstName,bankUserLastName,bankUserUsername,bankUserPassword) WHERE (@bankUserFirstName, @bankUserLastName, @bankUserUsername, @bankUserPassword);";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@bankUserFirstName", bankUser.GetbankUserFirstName());
            cmd.Parameters.AddWithValue("@bankUserLastName", bankUser.GetbankUserLastName());
            cmd.Parameters.AddWithValue("@bankUserUsername", bankUser.GetbankUserUsername());
            cmd.Parameters.AddWithValue("@bankUserPassword", bankUser.GetbankUserPassword());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            logger.LogInformation("User deleted!");
        }

        public async Task DeleteAccount(Account bankAccount)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"DELETE FROM Account (bankUserId) WHERE (@bankUserId);";

            using SqlCommand cmd = new(cmdString, connection);

            //cmd.Parameters.AddWithValue("@bankAccountBalance", bankAccount.GetbankAccountBalance());
            cmd.Parameters.AddWithValue("@bankUserId", bankAccount.GetbankUserId());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();

            logger.LogInformation("Account Deleted");
        }
    }
}