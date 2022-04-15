using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettaFishApp.InformationLogic
{
    public class BettaFunFacts
    {
        // Fields
        public int fact_ID { get; set; }
        public string? funFact { get; set; }


        // Constructors
        public BettaFunFacts() { }

        public BettaFunFacts(int fact_ID, string funFact)
        {
            this.fact_ID = fact_ID;
            this.funFact = funFact;

        }

        // Methods


    }
}