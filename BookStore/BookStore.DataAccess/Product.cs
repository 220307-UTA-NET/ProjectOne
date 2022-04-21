using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.DataAccess
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
