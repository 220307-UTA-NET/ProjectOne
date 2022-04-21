using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Models
{
    public class Order
    {
        public Order()
        {
            Items = new();
        }

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public List<InventoryProduct> Items { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
