using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.UI.DTOs
{
    public class StepDTO
    {
        public string? RecipeName { get; set; }
        public int? StepNumber { get; set; }
        public string? StepDescription { get; set; }

        public StepDTO( string RecipeName, int StepNumber, string StepDescription)
        {
            this.RecipeName = RecipeName;
            this.StepNumber = StepNumber;
            this.StepDescription = StepDescription;
        }
    }
}
