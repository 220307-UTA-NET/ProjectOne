using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Models
{
    public class Location
    {
        public Location()
        {
            Inventory = new();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<InventoryProduct> Inventory { get; set; }
    }
}
