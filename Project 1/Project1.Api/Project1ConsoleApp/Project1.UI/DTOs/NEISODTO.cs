using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.UI.DTOs
{
    public class NEISODTO
    {  
        public int NEISO_ID { get; set; }
        public DateTime Forcast_Date { get; set; }
        public int Hour { get; set; }
        public string? Reliability_Region { get; set; }
        public int Mega_Watts { get; set; }
    }
}
