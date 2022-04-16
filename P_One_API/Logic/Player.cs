using System.Text;

namespace Logic
{
    public class Player
    {    
        public string? playerName { get; set; }
        public int playerID { get; set; }
        public int trash { get; set; }
        public int load { get; set; }
        public int moves { get; set; }
        List<Item> playerTrash { get; set; }

        public Player() { }

        public Player(string playerName)
        {
            this.playerName = playerName;
        }
        public Player(string playerName, int playerID, int trash, int load, int moves)
        {
            this.playerName = playerName;
            this.playerID = playerID;
            this.trash = trash;
            this.load = load;
            this.moves = moves;
        }

        public string? GetName()
        {
            return playerName;
        }
        public string PlayerInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"[{playerID}] - {playerName} \n");
            return sb.ToString();
        }


    }
}