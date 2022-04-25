using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieGameStore.Logic
{
    public class Order
    {
        //Fields
        public int OrderID { get; set; }
        public int customerID { get; set; }
        public int productID { get; set; }

        //Constructors
        public Order() { }
        public Order(int orderid, int customer, int productid)
        {
            this.OrderID = orderid;
            this.customerID = customer;
            this.productID = productid;
        }

        //Methods
        public int GetOrderID()
        { return this.OrderID; }
        public int GetCustomerID()
        { return this.customerID; }
        public int GetProductID()
        { return this.productID; }
        public void SetProductID(int gameID)
        { this.productID = gameID; }

        public void SetUserID(int userID)
        { this.customerID = userID; }

    }
}
