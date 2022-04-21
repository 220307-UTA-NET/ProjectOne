using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.BusinessLogic
{
    public class Country
    {
        public string Country_Name { get; set; }
        public int Gold_Medals { get; set; }
        public int Silver_Medals { get; set; }
        public int Bronze_Medals { get; set; }
        public int Total_Medal { get; set; }

        public Country()
        {

        }

        public Country(string Country_Name, int Gold_Medals, int Silver_Medals, int Bronze_Medals, int Total_Medals)
        {
            this.Country_Name = Country_Name;
            this.Gold_Medals = Gold_Medals;
            this.Silver_Medals = Silver_Medals;
            this.Bronze_Medals = Bronze_Medals;
            this.Total_Medal = Total_Medals;
        }
    }
}
