
using P_One.Logic;


namespace P_One.Database
{
    public interface IRepo
    {
        Task<List<Player>> LastTwoPlayers();
        Task<string> NewPlayer(Player player);
        Task<Player> GetPlayer(int playerID);
        Task<string> RemovePlayer(int playerID);
        Task EmptyAllRooms();
        Task<string> FillAllRooms(int playerID);
        Task<Room> GetRoom(int roomID);
        Task UpdatePlayerStats(Player current);
        Task<List<Item>> GetRoomInventory(int roomID, int playerID);
        Task CreatePlayerItemTable(int playerID);
        Task DropPlayerItemTable(int playerID);
        Task UpdateItemQuantity(R_P_I_DTO combo);
        Task AddToInventory(Player current);
        Task <List<Item>>GetInventory(int playerID);
        Task EmptyPlayerInventory(int playerID);
    }
}
