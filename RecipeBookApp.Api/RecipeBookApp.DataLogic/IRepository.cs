using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBookApp.BusinessLogic;


namespace RecipeBookApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<User>> ListOfUsers();
        Task<ContentResult> CreateNewUser(string username, string password, string firstName, string lastName);
        Task<IEnumerable<Recipe>> ListOfRecipes();
        Task<IEnumerable<Recipe>> FindRecipe(string TheRecipeName);
        Task<ContentResult> CreateNewRecipe(string RecipeName, decimal rating);
        Task<ContentResult> AddToIngredientsList(string RecipeName, decimal IngredientQuantity, string UnitOfMeasure, string Ingredient);

        Task<IEnumerable<Ingredient>> ListOfIngredients();

        Task<IEnumerable<Ingredient>> SingleListOfIngredients(string TheRecipeName);

        Task<IEnumerable<Step>> SingleListOfSteps(string TheRecipeName);



        Task<ContentResult> DeleteRecipe(string TheRecipeName);


        /*
                Task<IEnumerable<FullDetail>> FullRecipeDetails(string TheRecipeName);
        */


    }
}


        
