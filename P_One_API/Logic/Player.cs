using System.Text;

namespace P_One.Logic
{
    public class Player
    {    
        public string? playerName { get; set; }
        public int playerID { get; set; }
        public int trash { get; set; }
        public int load { get; set; }
        public int moves { get; set; }
        public int itemID { get; set; }

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

        public string PlayerHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"----------GET TO CLEANING----------\n--  {playerName} TRASH CLEANED-{trash}, LOAD-{load} LBS, MOVES-{moves}  --\n");
            return sb.ToString();
        }

    }
}