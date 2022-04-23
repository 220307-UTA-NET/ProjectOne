using System.Data.SqlClient;
using business__logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace irepository
{
    public class sqldata : Irepository
    {
        private readonly string _connectionstring;
        private readonly ILogger<sqldata> _logger;

        public Irepository Object { get; }

        public sqldata(string connectionstring, ILogger<sqldata> logger)
        {
            this._connectionstring = connectionstring;
            this._logger = logger;
        }
        public sqldata() { }

        public sqldata(Irepository @object)
        {
            Object = @object;
        }

        public async Task<IEnumerable<inventory>> getinvetory(int storeid)
        {
            List<inventory> pizza = new List<inventory>();
            using SqlConnection connection = new SqlConnection(_connectionstring);
            await connection.OpenAsync();

            string cmdstring = @"select * from pizzastore.inventory where storeid = @storeid";
            using SqlCommand cmd = new SqlCommand(cmdstring, connection);
            cmd.Parameters.AddWithValue("@storeid", storeid);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var storeid1 = reader.GetInt32(0);
                var mashrooms = reader.GetInt32(1);

                var pineapples = reader.GetInt32(2);
                var salalmi = reader.GetInt32(3);
                var chicken = reader.GetInt32(4);
                var chessee = reader.GetInt32(5);
                pizza.Add(new(storeid, mashrooms, pineapples, salalmi, chicken, chessee));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Executed: getinventory");
            return pizza;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<ContentResult> Updateinventory(List<inventory> updateinventory)
        {

            int storeid = 0;
            int mashrooms = 0;
            int pineapples = 0;
            int salalmi = 0;
            int chicken = 0;
            int chessee = 0;
            foreach (var item in updateinventory)
            {
                storeid = item.storeid;
                mashrooms += item.mashrooms;
                pineapples += item.pineapples;
                salalmi += item.salalmi;
                chicken += item.chicken;
                chessee += item.chessee;
            }

            using SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();
            string cmdstring = @"update pizzastore.inventory 
                                 set 
                                 champinion =@mashrooms,
                                 pineapple =@pineapples,
                                 salami =@salalmi, 
                                 chicken =@chicken, 
                                 cheessen =@chessee 
                                 where storeid = @storeid";
            using SqlCommand cmd = new SqlCommand(cmdstring, connection);
            cmd.Parameters.AddWithValue("@storeid", storeid);
            cmd.Parameters.AddWithValue("@mashrooms", mashrooms);
            cmd.Parameters.AddWithValue("@pineapples", pineapples);
            cmd.Parameters.AddWithValue("@salalmi", salalmi);
            cmd.Parameters.AddWithValue("@chicken", chicken);
            cmd.Parameters.AddWithValue("@chessee", chessee);
            cmd.ExecuteNonQuery();
            connection.Close();
            _logger.LogInformation("Executed: uptadating Inventory ");
            return new ContentResult() { StatusCode = 201 };

        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ContentResult> registercustomers(string name, string lastname)
        {
            using SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();
            string cmdstring = @"insert into pizzastore.customers (customer_name, customer_lastname )
                                 values 
                                (@name,@lastname)";
            using SqlCommand cmd = new SqlCommand(cmdstring, connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.ExecuteNonQuery();
            connection.Close();
            _logger.LogInformation("Executed: registering customers ");
            return new ContentResult() { StatusCode = 201 };

        }

        public async Task<int> getcustomerid(string name, string lastname)
        {

            using SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();
            string cmdstring = @"select customerid from pizzastore.customers
                                 where customer_name = @name and customer_lastname = @lastname";
            using SqlCommand cmd = new SqlCommand(cmdstring, connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            using SqlDataReader reader = cmd.ExecuteReader();
            int customerid = 0;
            while (reader.Read())
            {
                customerid = reader.GetInt32(0);
            }
            await connection.CloseAsync();
            _logger.LogInformation("Executed: notifiying customersid ");
            return customerid;
        }

        public async Task<IEnumerable<registercustomers>> getregisteredcustomers(int customerid)
        {
            List<registercustomers> customer = new List<registercustomers>();
            using SqlConnection connection = new SqlConnection(_connectionstring);
            await connection.OpenAsync();

            string cmdstring = @"select customer_name, customer_lastname 
                                 from pizzastore.customers
                                 where customerid = @customerid";
            using SqlCommand cmd = new SqlCommand(cmdstring, connection);
            cmd.Parameters.AddWithValue("@customerid", customerid);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(0);
                var lastname = reader.GetString(1);


                customer.Add(new(name, lastname));
            }
            await connection.CloseAsync();
            _logger.LogInformation("Executed: getregisteredcustomers");
            return customer;


        }

        public async Task<ContentResult> registerorders(string name, string lastname, int storeid, DateTime date, string customerid, int number_of_pieces)
        {
            using SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();
            string cmdstring = @"insert into pizzastore.transactions (storeid,customer_name,customer_lastname,customeird,numberofpizzas,cost,Date )
                                 values 
                                 (@storeid,@name, @lastname, @customerid,@numberofpizzas, @numberofpizzas*5, @date)";
            using SqlCommand cmd = new SqlCommand(cmdstring, connection);
            cmd.Parameters.AddWithValue("@storeid", storeid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@customerid", customerid);
            cmd.Parameters.AddWithValue("@numberofpizzas", number_of_pieces);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
            connection.Close();
            _logger.LogInformation("Executed: registering orders ");
            return new ContentResult() { StatusCode = 201 };

        }


    }


}