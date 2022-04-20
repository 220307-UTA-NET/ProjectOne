namespace GamesApp.BusinessLogic
{
    public class Game
    {
        //Fields
        public int gameID { get; set; }
        public string? title { get; set; }
        public string? genre { get; set; }
        // Constructors
        public Game() { }

        public Game(int gameID, string title, string genre)
        {
            this.gameID = gameID;
            this.title = title;
            this.genre = genre;
        }

        // Methods
        public string GetTitle()
        { return this.title; }

        public string GetGenre()
        { return this.genre; }
    }
}

