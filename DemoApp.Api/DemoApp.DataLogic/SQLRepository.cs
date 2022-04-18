using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public class SQLRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        // Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        // Methods

        // Customer methods
        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> result = new List<Customer>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM BankManagementSystem.Customer";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                int CustomerId = reader.GetInt32(0);
                string custFirstName = reader.GetString(1);
                string custLastName = reader.GetString(2);
                string custAddress = reader.GetString(3);

                string? DOB = null;

                if (reader.IsDBNull(4))
                {
                    DOB = "No orders found";
                }
                else
                {
                    DOB = reader.GetString(4);
                };



                result.Add(new Customer(CustomerId, custFirstName, custLastName,custAddress, DOB));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllCustomers");

            return result;
        }
        public async Task<List<Customer>> GetCustomer(string input)
        {
            Console.WriteLine(input);
            List<Customer> result = new List<Customer>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"SELECT * FROM BankManagementSystem.Customer WHERE (FirstName = '{input}') OR (LastName = '{input}')";


            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int CustomerId = reader.GetInt32(0);
                string custFirstName = reader.GetString(1);
                string custLastName = reader.GetString(2);
                string custAddress = reader.GetString(3);

                string? DOB = null;

                if (reader.IsDBNull(4))
                {
                     DOB = "No orders found";
                }
                else
                {
                     DOB = reader.GetString(4);
                };

                result.Add(new Customer(CustomerId, custFirstName, custLastName, custAddress, DOB));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetCustomer");

            return result;
        }

        public async Task AddCustomer(Customer customer)
        {

            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"Insert Into Customer (FirstName, LastName, Address, DOB) VALUES ({customer.custFirstName}, {customer.custLastName}, {customer.custAddress}, {customer.dob}) ";


            using SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: CreateCustomer");

        }

        

        // Employee Methods 
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM Employee";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int empId = reader.GetInt32(0);
                string empFirstName = reader.GetString(1);
                string empLastName = reader.GetString(2);
              
                result.Add(new Employee(empId, empFirstName, empLastName));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllEmployees");

            return result;
        }



        public async Task<List<Employee>> GetEmployee(string input)
        {
            List<Employee> result = new List<Employee>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = $"SELECT * FROM Employee WHERE username = '{input}'";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int empId = reader.GetInt32(0);
                string empFirstName = reader.GetString(1);
                string empLastName = reader.GetString(2);
              
                result.Add(new Employee(empId, empFirstName, empLastName));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetEmployee");

            return result;
        }


        // Transactions Methods 
        public async Task<List<Transaction>> GetAllTransactions()
        {
            List<Transaction> result = new List<Transaction>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM Transaction";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int transId = reader.GetInt32(0);
                DateTime transDate = reader.GetDateTime(1);
               
                int amount = reader.GetInt32(2);
                decimal price = reader.GetDecimal(3);
                string description = reader.GetString(4);
                
                result.Add(new Transaction());
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllProducts");

            return result;
        }
        //public async Task<List<Transaction>> GetTransaction(string input)
        //{
        //    List<Transaction> result = new List<Transaction>();

        //    using SqlConnection connection = new(_connectionString);
        //    await connection.OpenAsync();

        //    string cmdString =
        //        $"SELECT * FROM Product WHERE (name = '{input}') OR (location_id = {Int32.Parse(input)})";


        //    using SqlCommand cmd = new(cmdString, connection);

        //    using SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        int id = reader.GetInt32(0);
        //        string name = reader.GetString(1);
        //        int amount = reader.GetInt32(2);
        //        decimal price = reader.GetDecimal(3);
            
               
        //        result.Add(new Transaction(id, name));
        //    }
        //    await connection.CloseAsync();

        //    _logger.LogInformation("Executed: GetProduct");

        //    return result;
        //}

    }
}
