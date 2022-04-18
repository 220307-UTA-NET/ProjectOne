using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeconsole.information
{
    public class status
    {
        public int storeid { get; set; }
        public int mashrooms { get; set; }
        public int pineapples { get; set; }
        public int salalmi { get; set; }
        public int chicken { get; set; }
        public int chessee { get; set; }
        public status(int storeid, int mashrooms, int pineapples, int salalmi, int chicken, int chessee)
        {
            this.storeid = storeid;
            this.mashrooms = mashrooms;
            this.pineapples = pineapples;
            this.salalmi = salalmi;
            this.chicken = chicken;
            this.chessee = chessee;

        }
    }

}
