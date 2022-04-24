using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Logging;
using StoreApp0.BusinessLogic;



namespace StoreApp0.DataLogic
{

    public class SqlRepository : IRepository
    {
        // will hold all of the communication to and from the database

        // Fields
        private readonly string _connectionString;
        private SqlConnection conn = null;

        // Constructor
        public SqlRepository(string? connectionString =null)
        {
            //this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this._connectionString = "Server=tcp:bruk.database.windows.net,1433;Initial Catalog=bruk;Persist Security Info=False;User ID=loginbruk;Password=Chuchu@2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        }

        // Methods
        /*
        public bool CreatConnection()

        {

            this.conn = new SqlConnection(this._connectionString);

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }

            //Console.Read();
        }
        */

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            List<Customer> result = new();
            string sqlQuery = "Select * from Store.Customer";



            using (var _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (var command = new SqlCommand(sqlQuery, _connection))
                {
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer(Convert.ToInt32(reader["customerID"]),
                                reader["firstName"].ToString(), reader["lastName"].ToString());

                          result.Add(customer);
                        }
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            //  command.ExecuteNonQuery();

            return result;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Customer customer = null;
            string sqlQuery = "Select * from Store.Customer where customerID = @id";


            using (var _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (var command = new SqlCommand(sqlQuery, _connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customer = new Customer(Convert.ToInt32(reader["customerID"]),
                                reader["firstName"].ToString(), reader["lastName"].ToString());
                            
                        }
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            //  command.ExecuteNonQuery();

            return customer;
        }

        public async Task<int> CreateCustomer(string firstName, string lastName)
        {
            string sqlQuery = "insert into Store.Customer(FirstName, LastName) values(@firstName, @lastName); SELECT CAST(scope_identity() AS int);";
            var insertedId = 0;

            using (var _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (var command = new SqlCommand(sqlQuery, _connection))
                {
                    command.Parameters.AddWithValue("firstName", firstName);
                    command.Parameters.AddWithValue("lastName", lastName);
                    insertedId = (int)await command.ExecuteScalarAsync();                    
                }
                _connection.Close();
            }
            //  command.ExecuteNonQuery();

            return insertedId;
        }



    }

}
