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
        //private readonly object cmd;

        // Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        // Methods

        // -----------Customer methods -------------------

        //GetAllCustomers
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



                result.Add(new Customer(CustomerId, IsVerified, custFirstName, custLastName, custAddress, DOB));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllCustomers");

            return result;
        }

        //GetCustomer
        public async Task<List<Customer>> GetCustomer(string input)
        {
            Console.WriteLine(input);
            List<Customer> result = new List<Customer>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"SELECT * FROM BankManagementSystem.Customer WHERE (FirstName = '{input}') OR (LastName = '{input}') OR (CustomerID = {Int32.Parse(input)})";
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
        public async Task UpdateCustomerAddress(int CustomerID, string address)
        {
            List<Customer> customer = await GetCustomer(CustomerID.ToString());
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdString =
            //  $"Insert Into BankManagementSystem.Customer (CustAddress) VALUES ('{customer.custAddress}') Where CustomerID = {customer.custId}";
            $"UPDATE BankManagementSystem.Customer set CustAddress = '{address}' WHERE CustomerID = {customer[0].custId}";

            using SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Updated Customer Address");

        }

        //Delete Customer
        public async Task DeleteCustomer(int CustomerId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdString =
            $"DELETE FROM BankManagementSystem.Customer WHERE CustomerID = {CustomerId};";

            using SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Updated Customer Address");

        }


        // ------------Transactions Methods--------------------

        public async Task<List<Transaction>> GetAllTransactions()
        {
            List<Transaction> result = new List<Transaction>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM BankManagementSystem.AccountTransaction";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                long transId = reader.GetInt64(0);
                DateTime transDate = reader.GetDateTime(1);

                int accountId = reader.GetInt32(2);
                int transTypeId = reader.GetInt32(3);
                decimal debitAmount = reader.GetDecimal(4);
                decimal creditAmount = reader.GetDecimal(5);
                decimal balance = reader.GetDecimal(6);


                result.Add(new Transaction(transId, transDate, accountId, transTypeId, debitAmount, creditAmount, balance));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllTransactions");

            return result;
        }




        public async Task<List<Transaction>> GetTransaction(int input)
        {
            List<Transaction> result = new List<Transaction>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"SELECT * FROM BankManagementSystem.AccountTransaction WHERE TransId = {input}";


            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                long transId = reader.GetInt64(0);
                DateTime transDate = reader.GetDateTime(1);

                int accountId = reader.GetInt32(2);
                int transTypeId = reader.GetInt32(3);
                decimal debitAmount = reader.GetDecimal(4);
                decimal creditAmount = reader.GetDecimal(5);
                decimal balance = reader.GetDecimal(6);


                result.Add(new Transaction(transId, transDate, accountId, transTypeId, debitAmount, creditAmount, balance));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetTransaction");

            return result;
        }

        //connecting to sp on sql

        //public async Task<List<Transaction>>InternalTransfer(Account a1, Account a2)
        //{
        //    using SqlConnection connection = new(_connectionString);
        //    await connection.OpenAsync();

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    //using (var conn = new SqlConnection(connection))
        //    //using (var command = new SqlCommand("ProcedureName", conn)
        //    //{
        //    //    CommandType = cmd.StoredProcedure
        //    //})
        //    //{
        //    //    conn.Open();
        //    //    command.ExecuteNonQuery();
        //    //}

        //}
        



            //---------------Account Methods------------------------

            public async Task<List<Account>> GetAccount(int input)
        {
            Console.WriteLine();
            List<Account> result = new List<Account>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"SELECT * FROM BankManagementSystem.Account WHERE AccountNumber = {input}";
            Console.WriteLine(cmdString);


            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int accountId = reader.GetInt32(0);
                int accountNumber = reader.GetInt32(1);
                int customerId = reader.GetInt32(2);
                int accountType = reader.GetInt32(3);
                string OpenningDate = reader.GetString(4);
                string LastTransactionDate = reader.GetString(5);
                int Status = reader.GetInt32(6);
                decimal accountBalance = reader.GetDecimal(7);

                result.Add(new Account(accountId, accountNumber, customerId, accountType, OpenningDate, LastTransactionDate, Status, accountBalance));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAccount");

            return result;
        }


        // GetAllAccounts

        public async Task<List<Account>> GetAllAccounts()
        {
            List<Account> result = new List<Account>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM BankManagementSystem.Account";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int accountId = reader.GetInt32(0);
                int accountNumber = reader.GetInt32(1);
                int customerId = reader.GetInt32(2);
                int accountType = reader.GetInt32(3);
                string OpenningDate = reader.GetString(4);
                string LastTransactionDate = reader.GetString(5);
                int Status = reader.GetInt32(6);
                decimal accountBalance = reader.GetDecimal(7);

                result.Add(new Account(accountId, accountNumber, customerId, accountType, OpenningDate, LastTransactionDate, Status, accountBalance));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Getting All Accounts");

            return result;
        }


        public async Task AddAccount(Account account)
        {
            Console.WriteLine(account.accountNumber);

            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"Insert Into BankManagementSystem.Account (AccountNumber,CustomerID, Type, OpenningDate, LastTransactionDate,Status,Balance) VALUES ({account.accountNumber},{account.customerId}, {account.accountType}, '{account.OpenningDate}', '{account.LastTransactionDate}', {account.Status}, {account.accountBalance}) ";
            Console.WriteLine(cmdString);

            using SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Account Created");

        }


        public async Task UpdateAccountBalance(Account account)
        {
            Console.WriteLine(account.accountNumber);

            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdString =
            
            $"UPDATE BankManagementSystem.Account set Balance = '{account.accountBalance}' WHERE AccountNumber = {account.accountNumber}";

            using SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            await connection.CloseAsync();

            _logger.LogInformation("Executed: Updated Account Balance");

        }

        // ------------Employee Methods------------------
        // GetAllEmployees 
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


        //Get an Employee
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

       
    }
       
}

