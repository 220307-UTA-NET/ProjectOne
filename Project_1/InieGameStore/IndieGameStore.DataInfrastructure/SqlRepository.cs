using IndieGameStore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Text.Json;
namespace IndieGameStore.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        // Constructor
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        //Methods
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            
            List<Customer> result = new List<Customer>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT CustomerID, UserName FROM Customers;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                int ID = reader.GetInt32(0);
                string? UserName = reader.GetString(1);
                //Console.WriteLine(UserName);
                result.Add(new Customer(ID, UserName));
                
            }
            
            await connection.CloseAsync();
            foreach (Customer customer in result)
            {
                customer.GetUserName();
                customer.GetID();
            }
            //return JsonSerializer.Serialize(result);
            return result;
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            List<Game> result = new();
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            string cmdString = "Select * FROM IndieGames;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int GameID = reader.GetInt32(0);
                string GameName = reader.GetString(1);
                int Price = reader.GetInt32(2);
                result.Add(new(GameID,GameName,Price));
            }
            await connection.CloseAsync();
            
            return result;
        }
       
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            List<Order> result = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();
            string cmdString = "Select * FROM GAMESALES;";
            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int SaleID = reader.GetInt32(0);
                int CustomerID = reader.GetInt32(1);
                int GameID = reader.GetInt32(2);
                result.Add(new(SaleID,CustomerID,GameID));
            }
            await connection.CloseAsync();
            return result;
        }

        public async Task<IEnumerable<Customer>> CreateNewCustomer(string UserName)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdText =
                @"INSERT INTO Customers (UserName)
                VALUES
                (@name);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@name", UserName);
            

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT *
                FROM Customers";
            //WHERE Name = @name;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@name", UserName);
            
            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tmpCustomer;
            while (reader.Read())
            {
                return (IEnumerable<Customer>)(tmpCustomer = new Customer(reader.GetInt32(0), reader.GetString(1)));
            }
            await connection.CloseAsync();
            Customer noCustomer = new();
            return (IEnumerable<Customer>)noCustomer;
        }

        public async Task<IEnumerable<Game>> CreateNewGame(string GameName, int Price)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdText =
                @"INSERT INTO IndieGames (GameName,Price)
                VALUES
                (@name, @price);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@name", GameName);
            cmd.Parameters.AddWithValue("@price", Price);


            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT *
                FROM IndieGames";
            //WHERE Name = @name;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@name", GameName);
            cmd.Parameters.AddWithValue("@price", Price);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Game tmpGame;
            while (reader.Read())
            {
                return (IEnumerable<Game>)(tmpGame = new Game(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }
            await connection.CloseAsync();
            Game noGame = new();
            return (IEnumerable<Game>)noGame;
        }

        public async Task<IEnumerable<Order>> CreateNewOrder(int CustomerID, int ProductID)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdText =
                @"INSERT INTO GAMESALES (CustomerID,ProductID)
                VALUES
                (@cid, @pid);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@cid", CustomerID);
            cmd.Parameters.AddWithValue("@pid", ProductID);


            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT *
                FROM GAMESALES";
            //WHERE Name = @name;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@cid", CustomerID);
            cmd.Parameters.AddWithValue("@pid", ProductID);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Order tmpOrder;
            while (reader.Read())
            {
                return (IEnumerable<Order>)(tmpOrder = new Order(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
            }
            await connection.CloseAsync();
            Order noOrder = new();
            return (IEnumerable<Order>)noOrder;
        }
    }
}
