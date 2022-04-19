using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.BusinessLogic
{
    public class Location
    {
        // Fields
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // Contstructor
        public Location() { }

        public Location(int Id, string City, string State, string Country)
        {
            this.Id = Id;
            this.City = City;
            this.State = State;
            this.Country = Country;
        }

        // Methods
    }
}
