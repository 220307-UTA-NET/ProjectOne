using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettaFishApp.Logic
{
    public class BettaStoreLocation
    {
        //Fields
        public int store_ID { get; set; }
        public string? storeName { get; set; }
        public string? storeAddress { get; set; }

        //Constructors
        public BettaStoreLocation (int store_ID, string storeName, string storeAddress)
        {
            this.store_ID = store_ID;
            this.storeName = storeName;
            this.storeAddress = storeAddress;
        }


        //Methods


    }
}
