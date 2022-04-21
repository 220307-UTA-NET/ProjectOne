using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.BusinessLogic
{
    public class Consumer
    {
        public string Name { get; set; }

        public Consumer()
        {

        }

        public Consumer(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
