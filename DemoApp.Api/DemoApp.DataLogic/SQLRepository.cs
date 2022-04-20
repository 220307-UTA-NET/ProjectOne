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
                int IsVerified = reader.GetInt32(1);
                string custFirstName = reader.GetString(2);
                string custLastName = reader.GetString(3);
                string custAddress = reader.GetString(4);
                //string DOB = reader.GetString(5);
                string DOB = null;

                if (reader.IsDBNull(5))
                {
                    DOB = "No orders found";
                }
                else
                {
                    DOB = reader.GetString(5);
                };



                result.Add(new Customer(CustomerId, IsVerified, custFirstName, custLastName,custAddress, DOB));
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
            Console.WriteLine(cmdString);


            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int CustomerId = reader.GetInt32(0);
                int IsVerified = reader.GetInt32(1);
                string custFirstName = reader.GetString(2);
                string custLastName = reader.GetString(3);
                string custAddress = reader.GetString(4);

                string DOB = null;

                if (reader.IsDBNull(5))
                {
                    DOB = "No orders found";
                }
                else
                {
                    DOB = reader.GetString(5);
                };

                result.Add(new Customer(CustomerId, IsVerified, custFirstName, custLastName, custAddress, DOB));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetCustomer");

            return result;
        }

        //Add Customer
        public async Task AddCustomer(Customer customer)
        {
            Console.WriteLine(customer.custFirstName);

            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"Insert Into BankManagementSystem.Customer (IsVerified,FirstName, LastName, CustAddress, DOB) VALUES ({customer.IsVerified},'{customer.custFirstName}', '{customer.custLastName}', '{customer.custAddress}', '{customer.dob}') ";


            using SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: CreateCustomer");

        }



        //UpdateCustomer
        public async Task UpdateCustomerAddress(Customer customer)
        {
            Console.WriteLine(customer.custFirstName);

            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdString =
              //  $"Insert Into BankManagementSystem.Customer (CustAddress) VALUES ('{customer.custAddress}') Where CustomerID = {customer.custId}";
            $"UPDATE BankManagementSystem.Customer set CustAddress = '{customer.custAddress}' WHERE CustomerID = {customer.custId}";

            using SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Updated Customer Address");

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

            string cmdString = $"SELECT * FROM Employee WHERE (EmlFirstName = '{input}') OR (EmlLastName = '{input}')";

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

                int accountId = reader.GetInt32(3);
                int transTypeId = reader.GetInt32(32);
                decimal debitAmount = reader.GetDecimal(4);
                decimal creditAmount = reader.GetDecimal(5);
                decimal  balance = reader.GetDecimal(6);
               
                
                result.Add(new Transaction());
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllTransactionss");

            return result;
        }


        //public async Task<List<Transaction>> GetTransaction(string input)
        //{
        //    List<Transaction> result = new List<Transaction>();

        //    using SqlConnection connection = new(_connectionString);
        //    await connection.OpenAsync();

        //    string cmdString =
        //        $"SELECT * FROM Transction WHERE AccountId = '{input}'";


        //    using SqlCommand cmd = new(cmdString, connection);

        //    using SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        int transId = reader.GetInt32(0);
        //        DateTime transDate = reader.GetDateTime(1);

        //        int accountId = reader.GetInt32(3);
        //        int transTypeId = reader.GetInt32(32);
        //        decimal debitAmount = reader.GetDecimal(4);
        //        decimal creditAmount = reader.GetDecimal(5);
        //        decimal balance = reader.GetDecimal(6);


        //        result.Add(new Transaction(transId, transDate,accountId, transTypeId, debitAmount,creditAmount,balance));
        //    }
        //    await connection.CloseAsync();

        //    _logger.LogInformation("Executed: GetProduct");

        //    return result;
        //}

    }
}
