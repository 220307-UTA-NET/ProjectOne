using Horoscope.Logic;
using System.Data.SqlClient;

namespace Horoscope.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        // will hold all of the communication to and from the database

        // Fields
        private readonly string _connectionString;

        // Constructor
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Methods
        public Client CreateNewClient(string ZODIAC_SIGN, string FIRST_NAME, string LAST_NAME, string BIRTH_DATE, string PHONE_NUMBER)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO Horoscope.Client (ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER)
                VALUES
                (@zODIAC_SIGN, @fIRST_NAME, @lAST_NAME, @bIRTH_DATE, @pHONE_NUMBER);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@zODIAC_SIGN", ZODIAC_SIGN);
            cmd.Parameters.AddWithValue("@fIRST_NAME", FIRST_NAME);
            cmd.Parameters.AddWithValue("@lAST_NAME", LAST_NAME);
            cmd.Parameters.AddWithValue("@bIRTH_DATE", BIRTH_DATE);
            cmd.Parameters.AddWithValue("@pHONE_NUMBER", PHONE_NUMBER);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT USER_ID, ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER
                FROM Horoscope.Client
                WHERE PHONE_NUMBER = @pHONE_NUMBER;"
                ;

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@pHONE_NUMBER", PHONE_NUMBER);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Client tmpClient;
            while (reader.Read())
            {
                return tmpClient = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            }
            connection.Close();
            Client noClient = new();
            return noClient;
        }


        public string GetUserZodiac(int USER_ID) 
        {
            string? ZODIAC_SIGN = "";
            
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            string cmdText = @"SELECT ZODIAC_SIGN
                FROM Horoscope.UserZodiac
                WHERE USER_ID = @ID;";
        

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@ID", USER_ID);

            using SqlDataReader reader = cmd.ExecuteReader();

         
            while (reader.Read())
            {
                ZODIAC_SIGN = reader.GetString(1);
                
            }

            connection.Close();

            if (ZODIAC_SIGN != null)
            { return ZODIAC_SIGN; }
            return null;
        }
    }
}
