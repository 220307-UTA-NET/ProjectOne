using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.BusinessLogic
{
    public class Step
    {
        //Fields
        public string RecipeName { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }

        // Constructors
        public Step() { }
        public Step(string RecipeName, int StepNumber, string StepDescription)
        {
            this.RecipeName = RecipeName;
            this.StepNumber = StepNumber;
            this.StepDescription = StepDescription;
        }
    }
}

