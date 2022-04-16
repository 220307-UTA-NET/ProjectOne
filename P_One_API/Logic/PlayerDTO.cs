

namespace Logic
{
    internal class PlayerDTO
    {
        public string? playerName { get; set; }
        public int playerID { get; set; }
        public int hp { get; set; }
        public int str { get; set; }
        public int dex { get; set; }

        public PlayerDTO() { }

        public PlayerDTO(string playerName)
        {
            this.playerName = playerName;
        }
        public PlayerDTO(string playerName, int playerID, int hp, int str, int dex)
        {
            this.playerName = playerName;
            this.playerID = playerID;
            this.hp = hp;
            this.str = str;
            this.dex = dex;
        }
    }
}
