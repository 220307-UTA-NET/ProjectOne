using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.BusinessLogic
{
    public class Onboarding
    {
        private string desc_Info;

        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }

        public Onboarding()
        {

        }

        public Onboarding(string Description, string Author, DateTime Date, string Source)
        {
            this.Description = Description;
            this.Author = Author;
            this.Date = Date;
            this.Source = Source;
        }

        public Onboarding(string desc_Info)
        {
            this.desc_Info = desc_Info;
        }
    }
}
