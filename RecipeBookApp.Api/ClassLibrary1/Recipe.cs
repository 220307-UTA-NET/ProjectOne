
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.BusinessLogic
{
    public class Recipe
    {
        // Fields
        public string RecipeName { get; set; }
        public decimal Rating { get; set; }

        //DateTime DateAdded;
        //string? Ingredients;



        // Constructors
        public Recipe() { }
        public Recipe(string RecipeName, decimal Rating)
        {
            this.RecipeName = RecipeName;
            this.Rating = Rating;
        }
    }
}



        //Methods
//        //setters
//        public void SetRecipeName(string RecipeName)
//        { this.RecipeName = RecipeName; }
//        public void SetCourse(string course)
//        { this.Course = Course; }
//        public void SetRating(int rating)
//        { this.Rating = Rating; }
//        public void SetKeyIngredient(string ingredient)
//        { this.KeyIngredient = KeyIngredient; }

//        // getters
//        public string GetRecipeName()
//        { return this.RecipeName; }
//        public DateTime GetDateAdded()
//        { return this.DateAdded; }
//        public double GetRating()
//        { return this.Rating; }

//    }
//}
