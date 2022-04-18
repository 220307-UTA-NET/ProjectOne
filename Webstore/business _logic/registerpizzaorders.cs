using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business__logic
{
    public class registerpizzaorders
    {

        public string name { get; set; }
        public string lastname { get; set; }
        public int storeid { get; set; }
        public DateTime date { get; set; }
        public string customerid { get; set; }
        public int number_of_pieces { get; set; }

        public registerpizzaorders(string name, string lastname, int storeid, DateTime date, string customerid, int number_of_pieces)
        {
            this.name = name;
            this.lastname = lastname;
            this.storeid = storeid;
            this.date = date;
            this.customerid = customerid;
            this.number_of_pieces = number_of_pieces;
        }
    }
}
