﻿using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using P_One_UI.DTOs;

namespace P_One_UI
{
    public class Game
    {
        private HttpClient client { get; set; }
        private string? gPlayerName { get; set; }
        private int gRoom { get; set; }
        private int gPlayerID { get; set; }
        private int gTrash { get; set; }
        private int gLoad { get; set; }
        private int gMoves { get; set; }

        public Game(HttpClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Accepts input for player/worker name
        /// </summary>
        /// <returns></returns>
        public async Task StartGame()
        {

            Console.WriteLine("Congratulation on your new job cleaning houses!\nPlease enter your name, so we can pay you.\n\nYou are handed a long list of what you assume are previous employees. The last two entries are:\n");
            await ListLastTwoPlayer();
            Console.Write("Your name here: ");
            string input = NamePlayer();          
            if (input == "999")
            {
                Console.WriteLine("Enter the player number to delete.");
                Int32.TryParse(Console.ReadLine(), out int delete);
                int deleteID = delete;
                await DeletePlayer(deleteID);
                Console.Clear();
                await StartGame();
            }
            else
            {
                await CreatePlayer(input);
                PlayerDTO current = await GetPlayer(gPlayerID);
                SetCurrentPlayerStats(current);
                await CreatePlayerTable(gPlayerID);
                Console.Clear();
                await EnterHouse();
            }


        }
        /// <summary>
        /// Establishes random variables of house and sets the player to start in room 1
        /// </summary>
        /// <returns></returns>
        public async Task EnterHouse()
        {
            gRoom = 1;
            await FillRooms(gPlayerID);
            await EnterRoom(gRoom);
        }
        /// <summary>
        /// Prints out information about the room the player is currently in, shows the player their stats.
        /// Acts as main page of the game
        /// </summary>
        /// <param name="gRoom">current RoomID # in game, used to get info on the the room the player is in </param>
        /// <returns></returns>
        public async Task EnterRoom(int gRoom)
        {           
            while(gRoom!=-1)
            {
                if (gRoom == 1)
                {
                    await UpdatePlayer(new PlayerDTO()
                    {   
                        moves = gMoves,
                        trash = gTrash,
                        load = 0,
                    });
                    gLoad = 0;
                }
                Console.Clear();
                GameHeader();
                RoomDTO currentRoom = await GetRoom(gRoom);
                int[] roomIDs = new int[] { currentRoom.adjRoom1, currentRoom.adjRoom2, currentRoom.adjRoom3 };
                List<RoomDTO> otherRooms = await GetRooms(roomIDs);

                List<ItemDTO> roomTrash = await GetRoomInv(gRoom, gPlayerID);
                FormatRoomDescription(currentRoom, otherRooms, roomTrash);

                gRoom = await ChoiceMenu(currentRoom);           
            } 
            await RemovePlayerItemTable(gPlayerID);
            Console.Clear();
            Console.WriteLine("Why does nobody want to work??!?");

        }
        /// <summary>
        /// checks if the roomID the player tried to move to is an available adjacent room
        /// If it is the player will move to the room, otherwise the player will stay in their current location
        /// </summary>
        /// <param name="currentRoom">Current room DTO the player is in </param>
        /// <param name="newRoom">new roomID # the player is trying to move to</param>
        /// <returns>the RoomID # that the player has successfully moved to or stayed in</returns>
        public async Task<int> ChooseNextRoom(RoomDTO currentRoom, int newRoom)
        {
            List<int> adjRooms = new List<int> { currentRoom.adjRoom1, currentRoom.adjRoom2, currentRoom.adjRoom3 };
            foreach (int i in adjRooms)
            {
                if (i == newRoom && i != 0)
                {
                    gRoom = i;
                    gMoves++;


                    await UpdatePlayer(new PlayerDTO()
                    {
                        playerID = gPlayerID,
                        moves = gMoves,
                        trash = gTrash,
                        load = gLoad,
                    });
                    break;

                }
            }
            return gRoom;
            
        }
        /// <summary>
        /// Menu options for player input while in the EnterRoom method
        /// Q will quit the game upon returning
        /// I will print out the player inventory
        /// A succesfully parsed integer will attempt to move the player to that RoomID
        /// </summary>
        /// <param name="currentRoom">current room the player is located in</param>
        /// <returns>the Room ID # that the player will be moving to or staying in</returns>
        public async Task<int> ChoiceMenu(RoomDTO currentRoom)
        {
            int gRoom = currentRoom.roomID;
            string newRoomStr = Console.ReadLine().ToUpper();
            if (newRoomStr == "Q")
            { 
                return -1; 
            }
            else if (newRoomStr == "I")
            { 
                Inventory(gPlayerID); 
            }
            else if (newRoomStr == "C")
            {
                await Clean(gPlayerID, currentRoom);
            }
            else if (Int32.TryParse(newRoomStr, out int newRoom))
            { 
                gRoom=await ChooseNextRoom(currentRoom, newRoom); 
            }
            return gRoom;
        }
        /// <summary>
        /// Formats Player details and directions to be displayed as a game header
        /// </summary>
        public void GameHeader()
        {
            //ADD total trash
            StringBuilder sb = new StringBuilder();
            sb.Append($"--  {gPlayerName} TRASH-{gTrash}, LOAD-{gLoad}, MOVES-{gMoves}  --\n");
            Console.WriteLine(sb.ToString());
        }
        /// <summary>
        /// Sets in-game variables for Game Header from the current player that is created at the start of the game
        /// </summary>
        /// <param name="current"></param>
        public void SetCurrentPlayerStats(PlayerDTO current)
        {
            gPlayerID = current.playerID;
            gPlayerName = current.playerName;
            gTrash = current.trash;
            gLoad = current.load;
            gMoves = current.moves;
        }
        /// <summary>
        /// Formats the information displayed to the play upon entry to a new room
        /// </summary>
        /// <param name="currentRoom">current room the player is inside of</param>
        /// <param name="otherRooms">the adjacent rooms the player can immediately travel to</param>
        /// <param name="roomTrash">Items (0-3) inside of each room</param>
        public void FormatRoomDescription(RoomDTO currentRoom, List<RoomDTO> otherRooms, List<ItemDTO> roomTrash)
        {
            int doors = 0;
            if (gLoad < 11)
            {
                Console.WriteLine($"You stand in the {currentRoom.roomName}.\n{currentRoom.roomDescription}");
                if (roomTrash.Count() == 0)
                { Console.WriteLine("\tThis room is clean!"); }
                else
                { Console.WriteLine("On the floor there is trash from whoever used to live here.\n\nThe trash includes:"); }
                foreach (ItemDTO i in roomTrash)
                {
                    if (i.itemName != null)
                        Console.WriteLine($"\t{i.itemName}");
                }
                foreach (RoomDTO r in otherRooms)
                {
                    if (r.roomName != null)
                    { doors++; }
                }
                Console.WriteLine($"\nYou see {doors} other door(s) leading to:");
                foreach (RoomDTO r in otherRooms)
                {
                    if (r.roomName != null)
                        Console.WriteLine($"\t[{r.roomID}] - The {r.roomName}");
                }
                Console.WriteLine("\n[#] - Room \n[I] - Inventory \n[C] - Clean \n[Q] - Quit.\n");
            }
            else
            {
                Console.WriteLine($"You stand in the {currentRoom.roomName}.\n{currentRoom.roomDescription}");
                foreach (RoomDTO r in otherRooms)
                {
                    if (r.roomName != null)
                    { doors++; }
                }
                Console.WriteLine($"\nYou see {doors} other door(s) leading to:");
                foreach (RoomDTO r in otherRooms)
                {
                    if (r.roomName != null)
                        Console.WriteLine($"\t[{r.roomID}] - The {r.roomName}");
                }
                Console.WriteLine("You can't carry anymore!! Go to the Entryway take the trash out of the house!");
            }

        }
        /// <summary>
        /// Get the last two players created and displays them at the start of the game
        /// Could eventually be used to display "high score" players
        /// </summary>
        /// <returns></returns>
        public async Task ListLastTwoPlayer()
        {
            var information = "";
            HttpResponseMessage response = await client.GetAsync($"player/previous");
            if (response.IsSuccessStatusCode) 
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
 
            List<string> allPlayers = JsonSerializer.Deserialize<List<string>>(information);

            if (allPlayers != null)
            {
                foreach (string p in allPlayers)
                {

                    Console.WriteLine(p);
                }
            }
            
        }
        /// <summary>
        /// Gets the information/stats on the player created at the beginning of the game
        /// </summary>
        /// <param name="playerID">unique player id</param>
        /// <returns></returns>
        public async Task<PlayerDTO> GetPlayer(int playerID)
        {
            var information = "";
            HttpResponseMessage response = await client.GetAsync($"player/current?playerID={playerID}");
            if (response.IsSuccessStatusCode)
            {              
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            PlayerDTO current = JsonSerializer.Deserialize<PlayerDTO>(information);
            return current;
        }
        /// <summary>
        /// Hidden method available at the start of the game to delete players from the SQL table
        /// playerID is the number used to specify a player for deletion
        /// </summary>
        /// <param name="playerID">unique player id</param>
        /// <returns></returns>
        public async Task DeletePlayer(int playerID)
        {

            var information = "";
            HttpResponseMessage response = await client.DeleteAsync($"player/delete?playerID={playerID}");
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        /// <summary>
        /// Verifies the player has not left the name field empty
        /// </summary>
        /// <returns></returns>
        public string NamePlayer()
        {
            string newPlayer;
            while (true)
            {
                newPlayer = Console.ReadLine();
                if (newPlayer == null || newPlayer == "")
                { 
                    Console.Clear();
                    Console.Write("You must tell us your name to work here.\nYour name here:");}
                else
                { break;}
            }

            return newPlayer;        
        } 
        /// <summary>
        /// Uses player name to create a new entry in the SQL table of players
        /// </summary>
        /// <param name="newPlayer">name given to the player</param>
        /// <returns></returns>
        public async Task CreatePlayer(string newPlayer)
        {
            var information = "";
            HttpResponseMessage response = await client.PostAsJsonAsync($"player/create", newPlayer);
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1}) {2}", (int)response.StatusCode, response.ReasonPhrase, response.Headers);
            }
        }
        /// <summary>
        /// updates the Moves of the current player whenever they change from one room to another
        /// </summary>
        /// <param name="gPlayerID">unique player id whose Moves are updated</param>
        /// <returns></returns>
        public async Task UpdatePlayer(PlayerDTO current)
        {
            var information = "";         
            HttpResponseMessage response = await client.PutAsJsonAsync($"player/current/update", current);
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        /// <summary>
        /// Ideally in the future will be able to hold Items the player has picked up
        /// Player will be able to pick up Trash in rooms to clean them
        /// </summary>
        /// <param name="gPlayerID">unique player id whose items will be updated</param>
        public void Inventory(int gPlayerID)
        {
            Console.Clear();
            Console.WriteLine("---Inventory---\nYou have no items here.\nPress enter to exit.");
            Console.ReadLine();
        }
        /// <summary>
        /// Display items in the Room that are trash and allow the user to attempt to clean
        /// </summary>
        /// <param name="gPlayerID"></param>
        /// <param name="currentRoom"></param>
        public async Task Clean(int gPlayerID, RoomDTO currentRoom)
        {
            List<ItemDTO> roomTrash = await GetRoomInv(currentRoom.roomID, gPlayerID);
            Console.Clear(); 
            if (roomTrash.Count() == 0)
            { 
                Console.WriteLine("This room is cleaned!\nGo clean a different room!");
                Thread.Sleep(900);

            }
            else
            {
                Console.WriteLine("Choose a piece of trash to clean up.\n");
                for (int i = 1; i <= roomTrash.Count(); i++)
                {

                    Console.WriteLine($"\t[{i}] - {roomTrash[i - 1].itemName}");
                }
                await ValidateTrash(Console.ReadLine(), roomTrash, currentRoom.roomID, gPlayerID);
            }
                      
            
        }
        /// <summary>
        /// Check that the number entered for a the  trash is one of the  items in the room
        /// </summary>
        /// <param name="c"></param>
        /// <param name="roomTrash"></param>
        /// <param name="roomID"></param>
        /// <param name="gPlayerID"></param>
        public async Task ValidateTrash(string c, List<ItemDTO> roomTrash, int roomID, int gPlayerID)
        {
            if (Int32.TryParse(c, out int trashIndex) && trashIndex<=roomTrash.Count()&&trashIndex>0)
            {
                for (int i=1; i <= roomTrash.Count(); i++)
                {
                    if ( trashIndex == i && roomTrash[i-1].itemName !=null)
                    {
                        await RemoveTrash(new R_P_I_DTO()
                        {
                            player=new PlayerDTO() {playerID=gPlayerID },
                            item=new ItemDTO() {itemID=roomTrash[i-1].itemID},
                            room=new RoomDTO() {roomID=roomID},
                        });
                        gTrash++;
                        gLoad += roomTrash[i-1].itemWeight;
                        await UpdatePlayer(new PlayerDTO()
                        {
                            playerID = gPlayerID,
                            trash = gTrash,
                            load = gLoad,
                            moves=gMoves,
                        });
                    }
                }
            }
            else
            {
                Console.WriteLine("Are you blind?  That's not garbage!!");
                Thread.Sleep(900);
            }
        }
        /// <summary>
        /// Creates a unique table for the created player
        /// to hold the random items that will be 
        /// </summary>
        /// <param name="gPlayerID">unique player id used to associate this table of trash with the player</param>
        /// <returns></returns>
        public async Task CreatePlayerTable(int gPlayerID)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"player/create/table", gPlayerID);
            if (response.IsSuccessStatusCode)
            {
                var information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        /// <summary>
        /// Randomly generates trash for each of the rooms in the house
        /// this trash is stored in the table created for the player
        /// </summary>
        /// <param name="gPlayerID">unique player id</param>
        /// <returns></returns>
        public async Task FillRooms(int gPlayerID)
        {
            var information = "";
            HttpResponseMessage response = await client.PostAsJsonAsync($"/room/inventory/fill", gPlayerID);
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        /// <summary>
        /// Gets information about the room the player is moving into
        /// this is formatted and displayed 
        /// </summary>
        /// <param name="gRoom">Room ID # for the specific room</param>
        /// <returns></returns>
        public async Task<RoomDTO> GetRoom(int gRoom)
        {
            var information = "";
            HttpResponseMessage response = await client.GetAsync($"room/current?roomID={gRoom}");
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            RoomDTO currentRoom = JsonSerializer.Deserialize<RoomDTO>(information);
            return currentRoom;
        }
        /// <summary>
        /// Gets information on the available adjacent rooms to the current room
        /// Potential of 1-3 adjacent rooms
        /// </summary>
        /// <param name="adjRoomIDs">room IDs for the adjacent  rooms</param>
        /// <returns></returns>
        public async Task<List<RoomDTO>> GetRooms(int[]adjRoomIDs)
        {
            var information = "";
            //string json = JsonSerializer.Serialize(current);
            //var c = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.GetAsync($"room/adjacent?roomIDs={adjRoomIDs[0]}&roomIDs={adjRoomIDs[1]}&roomIDs={adjRoomIDs[2]}");
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            List<RoomDTO> otherRooms = JsonSerializer.Deserialize<List<RoomDTO>>(information);
            return otherRooms;
        }
        /// <summary>
        /// Gets the trash located in a specific room
        /// </summary>
        /// <param name="gRoom">room id to get trash from</param>
        /// <param name="gPlayerID">player id to get the trash of</param>
        /// <returns></returns>
        public async Task<List<ItemDTO>> GetRoomInv(int gRoom, int gPlayerID)
        {
            int[] gRgPID = new int[] {gRoom,gPlayerID};
            var information = "";
            HttpResponseMessage response = await client.GetAsync($"room/current/inventory?r_pID={gRgPID[0]}&r_pID={gRgPID[1]}");
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            List<ItemDTO> roomInventory = JsonSerializer.Deserialize<List<ItemDTO>>(information);
            return roomInventory;
        }
        /// <summary>
        /// Drops the player specific table of trash once the game has ended
        /// Could change to keep the table if there are items in it still 
        /// Only drop once a player has fully completed cleaning a house
        /// </summary>
        /// <param name="gPlayerID">unique player id for table to drop</param>
        /// <returns></returns>
        public async Task RemovePlayerItemTable(int gPlayerID)
        {
            var information = "";
            HttpResponseMessage response = await client.DeleteAsync($"player/delete/table?playerID={gPlayerID}");
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        public async Task RemoveTrash(R_P_I_DTO combo)
        {
            //int[] trash = new int[] {gPlayerID, itemID, roomID};
            var information = "";
            HttpResponseMessage response = await client.PutAsJsonAsync($"/room/item/delete", combo);
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
         
        }
    }
}