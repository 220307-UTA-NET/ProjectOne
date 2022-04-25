using System.Text;

namespace IndieGameStore.Logic
{
    public class Customer
    {
        //Fields
        public int CustomerID { get; set; }
        public string UserName { get; set; }

        //Constructors
        public Customer() { }
        public Customer(int customerid, string username)
        {
            this.CustomerID = customerid;
            this.UserName = username;
        }
        //Methods
        public int GetID()
        {
            return this.CustomerID;
        }
        public string GetUserName()
        {
            return this.UserName;
        }
        
    }
}