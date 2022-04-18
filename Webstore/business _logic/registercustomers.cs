using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business__logic
{
    public class registercustomers
    {

        public string name { set; get; }
        public string lastname { set; get; }

        public registercustomers(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;
        }
    }
}
