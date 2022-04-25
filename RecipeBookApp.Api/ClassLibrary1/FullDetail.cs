using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.BusinessLogic
{
    public class FullDetail
    {
        // Fields
        public string RecipeName { get; set; }
        public decimal Rating { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string IngredientName { get; set; }
        public int? StepNumber { get; set; }
        public string? StepDescription { get; set; }


        // Constructors
        public FullDetail() { }


        //public FullDetail()
        //{
        //    string RecipeName;
        //    int Rating;
        //    decimal IngredientQuantity;
        //    UnitOfMeasure = UnitOfMeasure;
        //    IngredientName = IngredientName;
        //    RecipeName;
        //    StepNumber = StepNumber;
        //    StepDescription = StepDescription;

        //}

        public FullDetail(string RecipeName, decimal Rating, decimal IngredientQuantity, string UnitOfMeasure, string IngredientName, int StepNumber, string StepDescription)
        {
            this.RecipeName = RecipeName;
            this.Rating = Rating;
            this.IngredientQuantity = IngredientQuantity;
            this.UnitOfMeasure = UnitOfMeasure;
            this.IngredientName = IngredientName;
            this.RecipeName = RecipeName;
            this.StepNumber = StepNumber;
            this.StepDescription = StepDescription;

        }
    }
}
