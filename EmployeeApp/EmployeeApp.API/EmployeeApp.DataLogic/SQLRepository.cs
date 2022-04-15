using EmployeeApp.BusinessLogic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.DataLogic
{
    public class SQLRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        // Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        // Methods
        /// <summary>
        /// Get all employees information from the database.
        /// </summary>
        /// <returns>
        /// A list of all employees
        /// </returns>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            // Create an empty List to save all Employees
            List<Employee> result = new();

            // Create connection to the SQL Server database
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();   // Open the connection

            // Return control to user while the operation is being performed
            // SQL command/query to SELECT all Employees
            string cmdString =
                "SELECT * FROM p1.Employee;";

            // Use SqlCommand to store the SQL command/query
            using SqlCommand cmd = new(cmdString, connection);

            // Use SqlDataReader to read the stream of data (rows) from the SQL Server database
            using SqlDataReader reader = cmd.ExecuteReader();

            // While there is more row(s) to read
            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var BirthDate = reader.GetDateTime(3).Date;
                var BranchId = reader.GetInt32(4);
                var Department = reader.GetString(5);
                var Title = reader.GetString(6);
                var HiredDate = reader.GetDateTime(7).Date;
                result.Add(new(Id, FirstName, LastName, BirthDate, BranchId, Department, Title, HiredDate));
            }
            await connection.CloseAsync();  // Close the connection

            _logger.LogInformation("Executed: GetAllEmployeesAsync()");   // Create a log information

            return result;  // Return the list filled with all Employees
        }

        /// 
        /// <summary>
        /// Get a single employee using their Id as a parameter from the database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// A list with a single employee
        /// </returns>
        public async Task<IEnumerable<Employee>> GetEmployeeAsync(int Id)
        {
            // Create an empty List to save the Employee
            List<Employee> result = new();

            // Create connection to the SQL Server database
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync(); // Open the connection

            // SQL command/query to SELECT a single Employee
            string cmdString =
                @"SELECT * FROM p1.Employee 
                WHERE Id = @Id;";

            // Use SqlCommand to store the SQL command/query and use the connection
            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@Id", Id); // Replace the string value with the parameter

            // Use SqlDataReader to read the stream of data (rows) from the SQL Server database
            using SqlDataReader reader = cmd.ExecuteReader();

            // While there is more row(s) to read
            while(reader.Read())
            {
                var EmployeeId = reader.GetInt32(0);
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var BirthDate = reader.GetDateTime(3).Date;
                var BranchId = reader.GetInt32(4);
                var Department = reader.GetString(5);
                var Title = reader.GetString(6);
                var HiredDate = reader.GetDateTime(7).Date;
                result.Add(new(EmployeeId, FirstName, LastName, BirthDate, BranchId, Department, Title, HiredDate));
            }
            await connection.CloseAsync();  // Close the connection

            _logger.LogInformation("Executed: GetEmployeeAsync()");   // Create a log information

            return result;  // Return the list filled with an Employee
        }

        public async Task<IEnumerable<Employee>> AddEmployeeAsync(Employee emp)
        {
            // Create an empty List to save the Employee
            List<Employee> result = new();

            // Create connection to the SQL Server database
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync(); // Open the connection

            // SQL command/query to INSERT a new Employee
            string cmdString =
                @"INSERT INTO p1.Employee (FirstName, LastName, BirthDate, BranchId, Department, Title, HiredDate)
                VALUES (@FirstName, @LastName, @BirthDate, @BranchId, @Department, @Title, @HiredDate);";

            // Use SqlCommand to store the SQL command/query and use the connection
            using SqlCommand cmd = new(cmdString, connection);

            // Replace the string value with the parameter
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate);
            cmd.Parameters.AddWithValue("@BranchId", emp.BranchId);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Title", emp.Title);
            cmd.Parameters.AddWithValue("@HiredDate", emp.HiredDate);

            // ExecuteNonQuery command to the database
            cmd.ExecuteNonQuery();

            // SQL command/query to SELECT the new Employee
            string cmdString2 =
                @"SELECT TOP 1 * FROM p1.Employee ORDER BY Id DESC;";

            // Use SqlCommand to store the SQL command/query
            using SqlCommand cmd2 = new(cmdString2, connection);

            // Use SqlDataReader to read the stream of data (rows) from the SQL Server database
            using SqlDataReader reader = cmd2.ExecuteReader();

            // While there is more row(s) to read
            while (reader.Read())
            {
                var EmployeeId = reader.GetInt32(0);
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var BirthDate = reader.GetDateTime(3).Date;
                var BranchId = reader.GetInt32(4);
                var Department = reader.GetString(5);
                var Title = reader.GetString(6);
                var HiredDate = reader.GetDateTime(7).Date;
                result.Add(new(EmployeeId, FirstName, LastName, BirthDate, BranchId, Department, Title, HiredDate));
            }
            await connection.CloseAsync();  // Close the connection

            _logger.LogInformation("Executed: AddEmployeeAsync()");   // Create a log information

            return result;  // Return the list filled with the new Employee
        }

        public async Task<IEnumerable<Employee>> UpdateEmployeeAsync(Employee emp)
        {
            // Empty List to save the result
            List<Employee> result = new();

            // Create connection to SQL Database
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();   // Open the connection

            // SQL Command to UPDATE an Employee's department and title
            string cmdString =
                "UPDATE p1.Employee SET Department = @Department, Title = @Title WHERE Id = @Id;";

            // Use SqlCommand to store the SQL command/query and use the connection
            using SqlCommand cmd = new(cmdString, connection);

            // Parameters.AddWithValue
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Title", emp.Title);
            cmd.Parameters.AddWithValue("@Id", emp.Id);

            // Execute the SQL Command
            cmd.ExecuteNonQuery();

            // SQL Command to get the updated Employee
            string cmdString2 =
                "SELECT * FROM p1.Employee WHERE Id = @Id";

            // SqlCommand to store the new query using the same connection
            using SqlCommand cmd2= new(cmdString2, connection);

            // Use SqlDataReader to read the stream of data
            using SqlDataReader reader = cmd2.ExecuteReader();

            // Read the row of data
            while (reader.Read())
            {
                var EmployeeId = reader.GetInt32(0);
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var BirthDate = reader.GetDateTime(3).Date;
                var BranchId = reader.GetInt32(4);
                var Department = reader.GetString(5);
                var Title = reader.GetString(6);
                var HiredDate = reader.GetDateTime(7).Date;
                result.Add(new(EmployeeId, FirstName, LastName, BirthDate, BranchId, Department, Title, HiredDate));
            }
            await connection.CloseAsync();  // Close the connection

            _logger.LogInformation("Executed: UpdateEmployeeAsync()");  // Logging

            return result;
        }
        
        public async Task<IEnumerable<Employee>> DeleteEmployeeAsync(int Id)
        {
            // Empty List to save the Employee to be deleted
            List<Employee> result = new();

            // Create connection to SQL Database
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();   // Open the connection

            // SQL command/query to SELECT a single Employee
            string cmdString =
                @"SELECT * FROM p1.Employee 
                WHERE Id = @Id;";

            // Use SqlCommand to store the SQL command/query and use the connection
            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@Id", Id); // Replace the string value with the parameter

            // Use SqlDataReader to read the stream of data (rows) from the SQL Server database
            using SqlDataReader reader = cmd.ExecuteReader();

            // While there is more row(s) to read
            while (reader.Read())
            {
                var EmployeeId = reader.GetInt32(0);
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var BirthDate = reader.GetDateTime(3).Date;
                var BranchId = reader.GetInt32(4);
                var Department = reader.GetString(5);
                var Title = reader.GetString(6);
                var HiredDate = reader.GetDateTime(7).Date;
                result.Add(new(EmployeeId, FirstName, LastName, BirthDate, BranchId, Department, Title, HiredDate));
            }
            reader.Close();

            // SQL Command to UPDATE an Employee's department and title
            string cmdString2 =
                "DELETE FROM p1.Employee WHERE Id = @Id;";

            // Use SqlCommand to store the SQL command/query and use the connection
            using SqlCommand cmd2 = new(cmdString2, connection);

            // Parameters.AddWithValue
            cmd2.Parameters.AddWithValue("@Id", Id);

            // Execute the SQL Command
            cmd2.ExecuteNonQuery();

            await connection.CloseAsync();  // Close the connection

            _logger.LogInformation("Executed: DeleteEmployeeAsync()");  // Logging

            return result;
        }
    }
}
