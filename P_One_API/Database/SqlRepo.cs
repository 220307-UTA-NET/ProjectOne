
using System.Data.SqlClient;
using P_One.Logic;
using Microsoft.Extensions.Logging;


namespace P_One.Database
{
    public class SqlRepo : IRepo
    {
        private readonly string _connString;
        private readonly ILogger<SqlRepo> _logger;
        public SqlRepo(string connString, ILogger<SqlRepo> logger)
        {
            this._connString = connString ?? throw new ArgumentNullException(nameof(connString));
            this._logger = logger;
        }
        public async Task<List<Player>> LastTwoPlayers()
        {
            List<Player> playerList = new List<Player>();

            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText = $"SELECT TOP 2 * FROM ProjOne.Player ORDER BY PlayerID DESC";
            using SqlCommand cmd = new(cmdText, connect);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int trash = reader.GetInt32(2);
                int load = reader.GetInt32(3);
                int moves = reader.GetInt32(4);

                playerList.Add(new(name, id, trash, load, moves));
            }
            await connect.CloseAsync();

            _logger.LogInformation("Executed: LastTwoPlayers");
            return playerList;
        }
        public async Task<string> RemovePlayer(int playerID)
        {
            string deletedPlayer = "";
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText = $"SELECT * FROM ProjOne.Player WHERE PlayerID = '{playerID}';";
            using SqlCommand cmd = new(cmdText, connect);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                deletedPlayer = reader.GetString(1);
            }
            await connect.CloseAsync();

            await connect.OpenAsync();
            cmdText = $"DELETE FROM ProjOne.Player WHERE PlayerID = '{playerID}';";
            using SqlCommand cmd2 = new(cmdText, connect);
            cmd2.ExecuteNonQuery();
            await connect.CloseAsync();

            _logger.LogInformation($"Executed: RemovePlayer ID={playerID}");
            return $"{deletedPlayer} deleted.";

        }
        public async Task<string> NewPlayer(Player player)
        {
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText = @"INSERT INTO ProjOne.Player (PlayerName, Trash, Load, Moves) VALUES (@name, 0, 0, 0);";
            using SqlCommand cmd = new(cmdText, connect);
            cmd.Parameters.AddWithValue("@name", player.GetName());

            cmd.ExecuteNonQuery();
            await connect.CloseAsync();

            _logger.LogInformation($"Executed: NewPlayer Name: {player.GetName()}");
            return $"New Player {player.GetName()} added!";

        }
        public async Task<Player> GetPlayer(int playerID)
        {
            Player currentPlayer = new Player();
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText;
            if (playerID == 0)
            {
                cmdText = "SELECT TOP 1 * FROM ProjOne.Player ORDER BY PlayerID DESC;";
            }
            else
            {
                cmdText = $"SELECT * FROM ProjOne.Player WHERE PlayerID= {playerID};";
            }
            using SqlCommand cmd = new(cmdText, connect);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int trash = reader.GetInt32(2);
                int load = reader.GetInt32(3);
                int moves = reader.GetInt32(4);
                currentPlayer = new(name, id, trash, load, moves);
            }
            await connect.CloseAsync();

            _logger.LogInformation($"Executed: GetPlayer ID: {playerID}");
            return currentPlayer;
        }
        public async Task UpdatePlayerStats(Player current)
        {
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();
            string loadString = "";
            if (current.load == -1)
            { 
                loadString = $"Load ={current.load+1}"; 
            }
            else
            { loadString = $"Load +={current.load}"; }

            string cmdText = $"UPDATE ProjOne.Player SET Moves+={current.moves}, Trash+={current.trash}, {loadString} WHERE PlayerID={current.playerID};";
            using SqlCommand cmd = new(cmdText, connect);
            cmd.ExecuteNonQuery();

            _logger.LogInformation($"Executed: UpdatePlayerStats {current.moves} moves, {current.trash} trash, {current.load} load");
            await connect.CloseAsync();
        }

        //Unneccesarry after changed to making custom table per player
        public async Task EmptyAllRooms()
        {           
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText = $"DELETE FROM ProjOne.RoomInventory";
            using SqlCommand cmd2 = new(cmdText, connect);
            cmd2.ExecuteNonQuery();

            _logger.LogInformation("Executed: EmptyAllRooms");
            await connect.CloseAsync();           
        }
        public async Task<string> FillAllRooms(int playerID)
        {  
            int numberOfRooms = 0;
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText = $"SELECT TOP 1 * FROM ProjOne.Room ORDER BY RoomID DESC;";
            using SqlCommand cmd = new(cmdText, connect);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberOfRooms = reader.GetInt32(0);
            }
            await connect.CloseAsync();

            using SqlConnection connect2 = new SqlConnection(this._connString);
            await connect2.OpenAsync();
            for (int i = 1; i <= numberOfRooms; i++)
            {
                cmdText = $"INSERT INTO ProjOne.Player{playerID}RoomItems(RoomID, ItemID1, ItemID2, ItemID3) VALUES ({i}, FLOOR(RAND() * (14 - 0 + 1)) + 0, FLOOR(RAND() * (14 - 0 + 1)) + 0, FLOOR(RAND() * (14 - 0 + 1)) + 0);";
                using SqlCommand cmd2 = new(cmdText, connect2);
                cmd2.ExecuteNonQuery();
            }
            await connect2.CloseAsync();

            _logger.LogInformation($"Executed: FillAllRooms Rooms: {numberOfRooms}");
            return "Rooms Filled!";
        }
        public async Task<Room> GetRoom(int roomID)
        {
            Room currentRoom = new Room();
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText = $"SELECT * FROM ProjOne.Room WHERE RoomID={roomID};";
            using SqlCommand cmd = new(cmdText, connect);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {                
                string roomName = reader.GetString(1);
                string roomDetails = reader.GetString(2);
                int adjRoom1 = reader.GetInt32(3);
                int adjRoom2 = reader.GetInt32(4);
                int adjRoom3 = reader.GetInt32(5);
                currentRoom = new(roomID, roomName, roomDetails, adjRoom1, adjRoom2, adjRoom3);
            }
            await connect.CloseAsync();
            _logger.LogInformation($"Executed: GetRoom RoomID: {roomID}");
            return currentRoom;
            
        }
        public async Task<List<Item>> GetRoomInventory(int roomID, int playerID)
        {
            List<Item> roomInventory = new List<Item>();
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            for (int i = 1; i < 4; i++)
            { 
                string cmdText = $"SELECT * FROM ProjOne.Items INNER JOIN ProjOne.Player{playerID}RoomItems  ON Items.ItemID = Player{playerID}RoomItems.ItemID{i} WHERE ProjOne.Player{playerID}RoomItems.RoomID = {roomID};";
                using SqlCommand cmd = new(cmdText, connect); 

                using SqlDataReader reader =cmd.ExecuteReader();
                while(reader.Read())
                {
                    int itemID = reader.GetInt32(0);
                    string itemName = reader.GetString(1);
                    int itemWeight = reader.GetInt32(2);
                    roomInventory.Add(new(itemID, itemName, itemWeight));
                }          
            }
            await connect.CloseAsync();
            _logger.LogInformation($"Executed: GetRoomInventory RoomID: {roomID}");
            return roomInventory;
        }
        public async Task CreatePlayerItemTable(int playerID)
        {
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText =$"CREATE TABLE ProjOne.Player{playerID}RoomItems(RoomID INT PRIMARY KEY CONSTRAINT FK_Player{playerID}_RoomID_Inventory FOREIGN KEY(RoomID) REFERENCES ProjOne.Room(RoomID) ON DELETE CASCADE, ItemID1 INT, ItemID2 INT, ItemID3 INT,);";
            using SqlCommand cmd = new(cmdText, connect);
            cmd.ExecuteNonQuery();
            await connect.CloseAsync();

            _logger.LogInformation($"Executed CreatePlayerItemTable PlayerID: {playerID}");
        }
        public async Task DropPlayerItemTable(int playerID)
        {
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();
            string cmdText = $"DROP TABLE ProjOne.Player{playerID}RoomItems;";
            using SqlCommand cmd = new(cmdText, connect);
            cmd.ExecuteNonQuery();
            await connect.CloseAsync();

            _logger.LogInformation($"Executed DropPlayerItemTable PlayerID: {playerID}");
        }
        public async Task UpdateItemQuantity(R_P_I_DTO combo)
        {
            List <int> items = new List<int> ();
            string delete="";
            using SqlConnection connect = new SqlConnection(this._connString);
            await connect.OpenAsync();

            string cmdText = $"SELECT * FROM ProjOne.Player{combo.player.playerID}RoomItems WHERE RoomID = {combo.room.roomID};";
            using SqlCommand cmd = new(cmdText, connect);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while(reader.Read())
                {
                    int itemID1 = reader.GetInt32(1);
                    int itemID2 = reader.GetInt32(2);
                    int itemID3 = reader.GetInt32(3);
                    items = new() { itemID1, itemID2, itemID3 };  
                }

            for(int i = 0; i < items.Count; i++)
            {
                if (items[i] == combo.item.itemID)
                { 
                    delete = $"ItemID{i + 1}";
                    break;
                }
                
            }
 
            cmdText = $"UPDATE ProjOne.Player{combo.player.playerID}RoomItems SET {delete} = 0 WHERE RoomID = {combo.room.roomID} AND {delete}={combo.item.itemID};";
            using SqlCommand cmd2 = new(cmdText, connect);
            cmd2.ExecuteNonQuery();

            await connect.CloseAsync();

            _logger.LogInformation($"Executed: DeleteOneItem Room: {combo.room.roomID}");
        }

        public async Task AddToInventory(Player current)
        {
            using SqlConnection connect = new SqlConnection(_connString);
            await connect.OpenAsync();
            string cmdText = $"INSERT INTO ProjOne.PlayerInventory(PlayerID, ItemID) VALUES ({current.playerID}, {current.itemID});";

            using SqlCommand cmd = new(cmdText, connect);
            cmd.ExecuteNonQuery();

            await connect.CloseAsync();

            _logger.LogInformation($"Executed: AddToInventory Item: {current.itemID}");
        }
        public async Task<List<Item>> GetInventory(int playerID)
        {
            List<Item> inventory = new List<Item>();
            using SqlConnection connect = new SqlConnection(_connString);
            await connect.OpenAsync();
            string cmdText = $"SELECT* FROM ProjOne.PlayerInventory INNER JOIN ProjOne.Items ON Items.ItemID = PlayerInventory.ItemID WHERE PlayerID = {playerID};";

            using SqlCommand cmd = new(cmdText, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int itemID = reader.GetInt32(3);
                string itemName = reader.GetString(4);
                int itemWeight  = reader.GetInt32(5);
                inventory.Add(new Item(itemID, itemName, itemWeight));
            }
            await connect.CloseAsync();

            _logger.LogInformation($"Executed: GetInventory {inventory.Count} items");

            return inventory;
        }
        public async Task EmptyPlayerInventory(int playerID)
        {
            using SqlConnection connect = new SqlConnection(_connString);
            await connect.OpenAsync();
            string cmdText = $"DELETE FROM ProjOne.PlayerInventory WHERE PlayerID = {playerID};";

            using SqlCommand cmd = new(cmdText, connect);
            cmd.ExecuteNonQuery();
            await connect.CloseAsync();

            _logger.LogInformation($"Executed: EmptyPlayerInventory playerID:{playerID}");
        }
    }
}