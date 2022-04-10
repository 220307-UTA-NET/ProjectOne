using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Logic
{
    public class RecipeClass
    {
        // Fields
        string RecipeName;
        DateTime DateAdded;
        string? Course;
        double Rating;
        public string? Description { get; set; }
        public int LevelOfDifficulty { get; set; }
        public string KeyIngredient { get; set; }
        //string? KeyIngredient;
        //int? LevelOfDifficulty;
        //string? Description;


        // Constructors
        public RecipeClass() { }
        public RecipeClass(string RecipeName, DateTime DateAdded, string Notes, string Course, double Rating, string KeyIngredient, int LevelOfDifficulty)
        {
            this.RecipeName = RecipeName;
            this.DateAdded = DateAdded;
            this.Description = Description;
            this.Course = Course;
            this.Rating = Rating;
            this.KeyIngredient = KeyIngredient;
            this.LevelOfDifficulty = LevelOfDifficulty;
        }


        // Methods
        // setters
        public void SetRecipeName(string RecipeName)
        { this.RecipeName = RecipeName; }
        public void SetCourse(string course)
        { this.Course = Course; }
        public void SetRating(int rating)
        { this.Rating = Rating; }
        public void SetKeyIngredient(string ingredient)
        { this.KeyIngredient = KeyIngredient; }

        // getters
        public string GetRecipeName()
        { return this.RecipeName; }
        public DateTime GetDateAdded()
        { return this.DateAdded; }
        public double GetRating()
        { return this.Rating; }


        //public int LevelOfDifficulty { get; set; }
        //public int LevelOfDifficulty { get; set; }
        //public void SetLevelOfDifficulty(int levelOfDifficulty)
        //{ this.LevelOfDifficulty = LevelOfDifficulty; }
        //public void SetDescription(string description)
        //{ this.Description = Description; }
        // string Description, string Course, double Rating, string KeyIngredient,


        //CalculateAvgRating()
    }
}

