using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using StoreApplication.BusinessLogic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace StoreApplication.DataLogic
{ 
    public class SqlRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SqlRepository> _logger;

        // Constructors
        public SqlRepository(string connectionString, ILogger<SqlRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }


        // Methods
       // [TestMethod]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            List<Customer> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                "SELECT firstname, lastname, phone, product,location, amountspent, ID FROM StoreApplication.Customer;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var firstname = reader.GetString(0);
                var lastname = reader.GetString(1);
                var phone = reader.GetString(2);
                var product = reader.GetString(3);
                var location = reader.GetString(4);
                var amountspent = reader.GetString(5);
                var id = reader.GetString(6);

                result.Add(new(firstname, lastname, phone, product, location, amountspent, id));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllCustomers");

            return result;
        }


        //UnitTesting
       // [TestMethod]
        public async Task<IEnumerable<Customer>> GetCustomer(string firstname)
        {

            List<Customer> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"SELECT firstname, lastname, phone, product,location, amountspent, ID FROM StoreApplication.Customer " +
                 "WHERE firstname = @firstname;";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@firstname", firstname);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var firstname1 = reader.GetString(0);
                var lastname = reader.GetString(1);
                var phone = reader.GetString(2);
                var product = reader.GetString(3);
                var location = reader.GetString(4);
                var amountspent = reader.GetString(5);
                var id = reader.GetString(6);
                result.Add(new(firstname1, lastname, phone, product, location, amountspent, id));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllCustomers");

            return result;
        }

         //Unit testing 
        // [TestMethod]

        public async Task<IEnumerable<Customer>> AddCustomer(Customer cust)
        {
            List<Customer> result = new();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"Insert into StoreApplication.Customer(  firstname, lastname, phone, product,location, amountspent, ID )  " +
                 "Values (@f, @lastname, @phone, @product,@location, @amountspent, @ID);";


            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@f", cust.firstname);
            cmd.Parameters.AddWithValue("@lastname", cust.lastname);
            cmd.Parameters.AddWithValue("@phone", cust.phone);
            cmd.Parameters.AddWithValue("@product", cust.product);
            cmd.Parameters.AddWithValue("@location", cust.location);
            cmd.Parameters.AddWithValue("@amountspent", cust.amountspent);
            cmd.Parameters.AddWithValue("@ID", cust.id);

            using SqlDataReader reader = cmd.ExecuteReader();
            await connection.CloseAsync();
            _logger.LogInformation("Executed: GetAllCustomers");
            return result;     
        }

       
        //Unit Testing 
       // [TestMethod]

        public async Task<IEnumerable<Customer>> DeleteCustomer(string firstname)
        {
            List<Customer> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = @"DELETE FROM StoreApplication.Customer " +
                 "WHERE firstname = @firstname;";
            using SqlCommand cmd = new(cmdString, connection);
            cmd.Parameters.AddWithValue("@firstname", firstname);

            using SqlDataReader reader = cmd.ExecuteReader();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: DeleteCustomer");

            return result;

        }
            
    }
}
