using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Recipe.Logic;

namespace Recipe.DataInfrastructure
{
    public class SqlRepository : IRepository
    {

        // Fields
        private readonly string _connectionString;
        //public List<string> username;


        // Constructors
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        //public IEnumerable<User> listresult { get; private set; }

        //public IEnumerable<User> ListOfUsernames()
        //{
        //    return ListOfUsernames(username);
        //}


        // Methods

        //public IEnumerable<string> ListOfUsernames()
        //public string ListOfUsernames()
        public IEnumerable<User> ListOfUsers()
        {
            List<User> returnList = new();
            using SqlConnection connection = new SqlConnection
                (this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                //"SELECT username" +
                "SELECT *" +
                "FROM Recipes.Users;", connection);


            using SqlDataReader myReader = cmd.ExecuteReader();

            //List<string> result = new List<string>();

            while (myReader.Read())
            {
                string Username = myReader.GetString(0);
                string Password = myReader.GetString(1);
                string FirstName = myReader.GetString(2);
                string LastName = myReader.GetString(3);
                returnList.Add(new(Username, Password, FirstName, LastName));
                //yield return Username;

                //return sb.ToString();
            }

            connection.Close();
            return returnList;
            //return sb.ToString();
            //StringBuilder notSB = new();
            //return notSB;

        }
    }
}

//StringBuilder sb = new StringBuilder();
