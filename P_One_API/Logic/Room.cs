using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_One.Logic
{
    public class Room
    {
        public int roomID { get; set; }
        public string? roomName { get; set; }
        public string? roomDescription { get; set; }
        public int adjRoom1 { get; set; }
        public int adjRoom2 { get; set; }
        public int adjRoom3 { get; set; }

        public Room() { }

        public Room(int roomID, string roomName, string roomDescription, int adjRoom1, int adjRoom2, int adjRoom3)
        {
            this.roomID = roomID;
            this.roomName = roomName;
            this.roomDescription = roomDescription;
            this.adjRoom1 = adjRoom1;
            this.adjRoom2 = adjRoom2;
            this.adjRoom3 = adjRoom3;
            
        }

        public Room(string roomName, string roomDescription, int adjRoom1, int adjRoom2, int adjRoom3)
        {          
            this.roomName = roomName;
            this.roomDescription = roomDescription;
            this.adjRoom1 = adjRoom1;
            this.adjRoom2 = adjRoom2;
            this.adjRoom3 = adjRoom3;
        }
        public Room(string roomName, int roomID)
        {
            this.roomName=roomName;
            this.roomID=roomID;
        }

    }
}
