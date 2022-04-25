using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.BusinessLogic
{
    public class Ingredient
    {
        // Fields
        public string RecipeName { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string IngredientName { get; set; }

        // Constructors
        public Ingredient() { }
        public Ingredient(string RecipeName, decimal IngredientQuantity, string UnitOfMeasure, string IngredientName)
        {
            this.RecipeName = RecipeName;
            this.IngredientQuantity = IngredientQuantity;
            this.UnitOfMeasure = UnitOfMeasure;
            this.IngredientName =IngredientName;
        }
    }  
}




    
    