using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplication.UI.DTOs
{
    internal class CustomerDTO
    {
        // Fields
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Zipcode { get; set; }


        public CustomerDTO(int CustomerID, string FirstName, string LastName, String PhoneNumber, String Zipcode)
        {
            this.CustomerID = CustomerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Zipcode = Zipcode;
        }
    }
}
