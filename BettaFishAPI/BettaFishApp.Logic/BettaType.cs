using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettaFishApp.Logic
{
    public class BettaType
    {
        // Fields
        public int tail_ID { get; set; }
        public string? tailType { get; set; }
        public string? description { get; set; }


        // Constructors
        public BettaType() { }

        public BettaType(int tail_ID, string tailType, string description)
        {
            this.tail_ID = tail_ID;
            this.tailType = tailType;
            this.description = description;
        }

        //Methods
        //public string BettaDescription()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append($"[{tail_ID}] - {tailType} \n");
        //    return sb.ToString();
        //}


    }
}
