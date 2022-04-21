using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.DataAccess
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? Time { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
