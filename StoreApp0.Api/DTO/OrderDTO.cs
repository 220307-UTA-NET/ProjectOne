using System;
namespace StoreApp0.Api.DTO
{
    public class Order
    {
        public int orderId { get; set; }
        public int customerId { get; set; }
        public int locationId { get; set; }
        public DateTime Date; //{get; set;}
        public List<Order> cart = new List<Order>();


    }
}