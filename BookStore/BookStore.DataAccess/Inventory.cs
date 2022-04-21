using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.DataAccess
{
    public partial class Inventory
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
