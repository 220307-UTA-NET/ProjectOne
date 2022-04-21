using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.UI.DTOs
{
    public class OnboardingDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
    }
}
