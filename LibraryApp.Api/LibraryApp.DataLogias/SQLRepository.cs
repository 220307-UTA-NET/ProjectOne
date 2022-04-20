using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using LibraryApp.BusinessLogias;
using Microsoft.AspNetCore.Mvc;

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

            using SqlConnection connection = new(_connectionString);
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
        public async Task<IEnumerable<Book>> GetABook(int specBookID)
        {
            List<Book> result = new();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = "SELECT * FROM VLLibrary.Books WHERE BookID = @bookID;";
            using SqlCommand cmd = new(cmdString, connection);
            cmd.Parameters.AddWithValue("@bookID", specBookID);
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
        public async Task CreateMember(Member member)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = @"INSERT Into VLLibrary.Accounts (FirstName, LastName, Phone) VALUES (@fNAme, @lNAme, @phone)";
            using SqlCommand cmd = new(cmdString, connection);
            cmd.Parameters.AddWithValue("@fName", member.GetFName());
            cmd.Parameters.AddWithValue("@lName", member.GetLName());
            cmd.Parameters.AddWithValue("@phone", member.GetPhone());
            cmd.BeginExecuteNonQuery();
            await connection.CloseAsync();
            _logger.LogInformation("Finished creating new member");
        }
        public async Task<IEnumerable<Rental>> ViewAllRentals()
        {
            List<Rental> result = new List<Rental>();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = "SELECT * FROM VLLibrary.Rentals";
            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var rentalID = reader.GetInt32(0);
                var memberID = reader.GetInt32(1);
                var bookID = reader.GetInt32(2);
                result.Add(new(rentalID, memberID, bookID));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: running view all rentals");
            return result;
        }
        public async Task<List<Rental>> ViewUserRentals(int ID)
        {
            List<Rental> result = new List<Rental>();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = $"SELECT * FROM VLLibrary.Rentals WHERE MemberID = {ID};";
            using SqlCommand cmd = new(cmdString, connection);
            //cmd.Parameters.AddWithValue("@ID", ID);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var rentalID = reader.GetInt32(0);
                var memberID = reader.GetInt32(1);
                var bookID = reader.GetInt32(2);
                result.Add(new(rentalID, memberID, bookID));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: running view all rentals");
            return result;
        }
        /*public async Task<IEnumerable<Rental>> ViewAllRentals()
        {
            List<Rental> result = new List<Rental>();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = "SELECT ren.RentalID, acc.FirstName, acc.LastName, acc.MemberID, boo.BookID, boo.Title, boo.InStock " +
                "FROM VLLibrary.Books boo INNER JOIN VLLibrary.Rentals ren ON boo.BookID = ren.BookID " +
                "INNER JOIN VLLibrary.Accounts acc ON ren.MemberID = acc.MemberID;";
            using SqlCommand cmd = new(cmdString, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int rentalID = reader.GetInt32(0);
                string fName = reader.GetString(1);
                string lName = reader.GetString(2);
                int memberID = reader.GetInt32(3);
                int bookID = reader.GetInt32(4);
                string title = reader.GetString(5);
                int inOut = reader.GetInt32(6);
                result.Add(new(rentalID, fName, lName, memberID, bookID, title, inOut));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: running view all rentals");
            return result;
        }*/
        /*public async Task<List<Rental>> ViewUserRentals(int ID)
        {
            List<Rental> result = new List<Rental>();
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = $"SELECT ren.RentalID,  acc.FirstName, acc.LastName, acc.MemberID, boo.BookID, boo.Title, boo.InStock " +
                $"FROM VLLibrary.Books boo INNER JOIN VLLibrary.Rentals ren ON boo.BookID = ren.BookID INNER " +
                $"JOIN VLLibrary.Accounts acc ON ren.MemberID = acc.MemberID WHERE acc.MemberID = {ID};";
            using SqlCommand cmd = new(cmdString, connection);
            //cmd.Parameters.AddWithValue("@ID", ID);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int rentalID = reader.GetInt32(0);
                string fName = reader.GetString(1);
                string lName = reader.GetString(2);
                int memberID = reader.GetInt32(3);
                int bookID = reader.GetInt32(4);
                string title = reader.GetString(5);
                int inOut = reader.GetInt32(6);
                result.Add(new(rentalID, fName, lName, memberID, bookID, title, inOut));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Finished: running view all rentals");
            return result;
        }
        public async Task<int> LookUpABookInOutAsync(int bookID)
        {

        }*/
        public async Task CreateRental(Rental rental)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdString = @"INSERT Into VLLibrary.Rentals (MemberID, BookID) VALUES (@memberID, @bookID)";
            using SqlCommand cmd = new(cmdString, connection);
            cmd.Parameters.AddWithValue("@memberID", rental.GetMemberID());
            cmd.Parameters.AddWithValue("@bookID", rental.GetBookID());
            cmd.BeginExecuteNonQuery();            
            await connection.CloseAsync();
            _logger.LogInformation("Finished creating new rental");
        }
    }
}
