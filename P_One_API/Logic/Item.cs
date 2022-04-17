using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_One.Logic
{
    public class Item
    {
        public int itemID { get; set; }
        public string? itemName { get; set; }
        public int itemWeight { get; set; }


        public Item() { }
        public Item (int itemID, string itemName)
        {
            this.itemID = itemID;
            this.itemName = itemName;
        }

        public Item(int itemID, string itemName, int itemWeight)
        {
            this.itemID = itemID;
            this.itemName = itemName;
            this.itemWeight = itemWeight;
        }

    }
}
