using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettaFishApp.Logic
{
    public class BettaStories
    {
        //Fields
        public int story_ID { get; set; }
        public string? nameOfBetta { get; set; }
        public string? story { get; set; }

        //Constructors
        public BettaStories() { }

        public BettaStories(int story_ID, string nameOfBetta, string story ) 
        { 
        
            this.story_ID = story_ID;
            this.nameOfBetta = nameOfBetta;
            this.story = story; 

        }

        //Methods
        public string GetNameOfBetta()
        { return this.nameOfBetta; }
        public string GetStory()
        { return this.story; }
       
    }
}
