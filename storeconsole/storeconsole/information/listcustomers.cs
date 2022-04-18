using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeconsole.information
{
    [Serializable]
    internal class listcustomers
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public listcustomers(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;
        }
    }
}
