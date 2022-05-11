namespace StoreApp0.BusinessLogic
{

    public class Order
    {
        public int orderId { get; set; }
        public int customerId { get; set; }
        //public int locationId { get; set; }
        public DateTime Date { get; set; }
        //public List<Order> cart = new List<Order>();

        public Order()
        {}

        public Order(int OrderID, int CustomerId, DateTime Date)
        {
            this.orderId = OrderID;
            this.customerId = CustomerId;
           // this.locationId = LocationId;
            this.Date = Date;
        }


    }
}