using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_One_UI.DTOs
{
    public class RoomDTO
    {
        public int roomID { get; set; }
        public string? roomName { get; set; }
        public string? roomDescription { get; set; }
        public int adjRoom1 { get; set; }
        public int adjRoom2 { get; set; }
        public int adjRoom3 { get; set; }


    }
}
