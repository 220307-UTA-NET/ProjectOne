using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleComputerStore.AppLogic
{
    public class Customer
    {
        //Fields
        int id;
        string Name;
        string Address;

        // Constructors 
        public Customer() { }

        public Customer(string name, string address)
        {
            Name = name;
            Address = address;
        }


        //Methods 
    }
}
