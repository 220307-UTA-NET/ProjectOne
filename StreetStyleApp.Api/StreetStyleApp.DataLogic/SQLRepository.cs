using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using StreetStyleApp.BusinessLogic;

namespace StreetStyleApp.DataLogic
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
        public async Task <IEnumerable<Clothes>> GetAllClothes()
        {
            List<Clothes> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                "SELECT CLothingID, ClothingItem, ClothingBrand FROM Clothes.Clothing";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ClothingID = reader.GetInt32(0);
                var ClothingItem = reader.GetString(1);
                var ClothingBrand = reader.GetString(2);
                result.Add(new(ClothingID, ClothingItem, ClothingBrand));
            }

            _logger.LogInformation("Executed: GetAllClothes");

            return result;
        }

        public async Task <IEnumerable<Clothes>> AddClothes(Clothes clo)
        {
            List<Clothes> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"INSERT INTO Clothes.Clothing (ClothingItem, ClothingBrand)
                VALUES 
                (@ClothingItem, @ClothingBrand);";

            using SqlCommand cmd = new (cmdString, connection);

            cmd.Parameters.AddWithValue("@ClothingItem", clo.ClothingItem);
            cmd.Parameters.AddWithValue("@ClothingBrand", clo.ClothingBrand);

            cmd.ExecuteNonQuery();

            cmdString =
                @"SELECT ClothingID, ClothingItem, ClothingBrand 
                FROM Clothes.Clothing
                WHERE ClothingItem = @ClothingItem AND ClothingBrand = @ClothingBrand;";

            using SqlCommand cmd2 = new(cmdString, connection);

            cmd2.Parameters.AddWithValue("@ClothingItem", clo.ClothingItem);
            cmd2.Parameters.AddWithValue("@ClothingBrand", clo.ClothingBrand);


            using SqlDataReader reader = cmd2.ExecuteReader();          

            while (reader.Read())
            {
                var ClothingID = reader.GetInt32(0);
                var ClothingItem = reader.GetString(1);
                var ClothingBrand = reader.GetString(2);
                result.Add(new(ClothingID, ClothingItem, ClothingBrand));
            }

            //Clothes noClothes = new();
            _logger.LogInformation("Executed: AddClothes");

            return result;
        }

        public async Task <IEnumerable<Clothes>> DeleteClothes(int ID)
        {
            List<Clothes> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"SELECT * FROM Clothes.Clothing
                WHERE ClothingID = @ClothingID;";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@ClothingID", ID);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ClothingID = reader.GetInt32(0);
                var ClothingItem = reader.GetString(0);
                var ClothingBrand = reader.GetString(1);
                result.Add(new(ClothingID, ClothingItem, ClothingBrand));
            }
            reader.Close();

            cmdString =
                "DELETE FROM Clothes.Clothing" +
                "WHERE ClothingID = @ClothingID;";

            using SqlCommand cmd2 = new(cmdString, connection);

            cmd2.Parameters.AddWithValue("@ClothingID", ID);

            cmd2.ExecuteNonQuery();

            _logger.LogInformation("Executed: DeleteClothes");
            return result;
        }
    }
}
