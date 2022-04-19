using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettaFishApp.Logic
{
    public class BettaRegistration
    {

        //Fields
        public int registration_ID { get; set; }
        public string? fName { get; set; }
        public string? lName { get; set; }
        public string? email { get; set; }


        //Constructors
        public BettaRegistration() { }
        public BettaRegistration(int registration_ID, string fName, string lName, string email)
        {
            this.registration_ID = registration_ID;
            this.fName = fName;
            this.lName = lName;
            this.email = email;
        }

        //Methods
        public string GetfName()
        { return this.fName; }
        public string GetlName()
        { return this.lName; }
        public string Getemail()
        { return this.email; }

    }
}
