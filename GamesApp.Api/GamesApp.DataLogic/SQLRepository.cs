using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using GamesApp.BusinessLogic;

namespace GamesApp.DataLogic
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
        public async Task<IEnumerable<Game>> GetAllGames()
        {
            List<Game> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                "SELECT gameID, title, genre FROM Games.titles;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var gameID = reader.GetInt32(0);
                var title = reader.GetString(1);
                var genre = reader.GetString(2);
                result.Add(new(gameID, title, genre));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllGames");

            return result;
        }

        public async Task<IEnumerable<Game>> CreateNewGame(Game newGame)
        {
            List<Game> result = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            using SqlCommand cmd = new(
                @"INSERT INTO Games.titles(title, genre) VALUES (@title, @genre);"
                , connection);

            cmd.Parameters.AddWithValue("@title", newGame.title);
            cmd.Parameters.AddWithValue("@genre", newGame.genre);

            cmd.ExecuteNonQuery();

            using SqlCommand cmd2 = new(
                @"SELECT GameID FROM Games.titles WHERE title = @title AND genre = @genre;", connection);
            cmd2.Parameters.AddWithValue("@title", newGame.title);
            cmd2.Parameters.AddWithValue("@genre", newGame.genre);

            using SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                var gameID = reader.GetInt32(0);
                var title = reader.GetString(1);
                var genre = reader.GetString(2);
                result.Add(new(gameID, title, genre));
            }
            connection.Close();

            return result;

        }

        //public async Task<IEnumerable<Game>> GetGame(string title)
        //{
        //    List<Game> result = new();

        //    using SqlConnection connection = new(_connectionString);
        //    await connection.OpenAsync();

        //    string cmdString =
        //        @"SELECT gameID, title, genre FROM Games.titles " +
        //        "WHERE Games.titles = @title;";

        //    using SqlCommand cmd = new(cmdString, connection);

        //    cmd.Parameters.AddWithValue("@title", title);

        //    using SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        var gameID = reader.GetInt32(0);
        //        var Gtitle = reader.GetString(1);
        //        var genre = reader.GetString(2);
        //        result.Add(new(gameID, Gtitle, genre));
        //    }
        //    await connection.CloseAsync();

        //    _logger.LogInformation("Executed: GetAllGames");

        //    return result;
        //}
    }
}

