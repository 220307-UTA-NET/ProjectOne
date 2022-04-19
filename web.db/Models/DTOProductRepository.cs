using Microsoft.Data.SqlClient;
namespace web.db.Models
{
    public class DTOProductRepository : IProductRepository
    {
        private readonly string ConnectionString;

        public DTOProductRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<Product> Products { get {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Products";
                var reader = command.ExecuteReader();
                var products = new List<Product>();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = (long?)reader["ProductID"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"],
                        Category = (string)reader["Category"]
                    });
                }
                return products;
            }
        } }
        

        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Quantity = @Quantity, Category = @Category WHERE ProductID = @ProductID";
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Products WHERE ProductID = @ProductID";
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.ExecuteNonQuery();
            }
        }

        public void CreateProduct(Product product)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Products (Name, Description, Price, Quantity, Category) VALUES (@Name, @Description, @Price, @Quantity, @Category)";
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.ExecuteNonQuery();
            }
        }
    }
}