using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.BL
{
    public class NEISOEnergyReport
    {
        public DateTime Forcast_Date { get; set; }
        public int Hour { get; set; }
        public string Reliability_Region { get; set; }
        public int Mega_Watts { get; set; }

        public NEISOEnergyReport()
        {

        }

        public NEISOEnergyReport(DateTime Forcast_Date, int Hour, string Reliability_Region, int Mega_Watts)
        {
            this.Forcast_Date = Forcast_Date;
            this.Hour = Hour;
            this.Reliability_Region = Reliability_Region;
            this.Mega_Watts = Mega_Watts;
        }
    }
}
