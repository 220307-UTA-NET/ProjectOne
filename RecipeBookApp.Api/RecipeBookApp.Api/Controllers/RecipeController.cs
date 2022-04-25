using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RecipeBookApp.DataLogic;
using RecipeBookApp.BusinessLogic;
using System.Text.Json;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBookApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<RecipeController> _logger;
        private readonly HttpClient httpClientInstance = new HttpClient();


        // Constructors
        public RecipeController(IRepository repository, ILogger<RecipeController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }
        ///////////////////////////////////////////////////////////////////


        // Methods
        [HttpGet("/Recipe")]
        public async Task<ActionResult<IEnumerable<Recipe>>> ListOfRecipesAsync()
        {

            IEnumerable<Recipe> recipe;
            try
            {
                recipe = await _repository.ListOfRecipes();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of users");
                return StatusCode(500);
            }
            return recipe.ToList();
        }


        [HttpGet("/SearchRecipes")]
        public async Task<ActionResult<IEnumerable<Recipe>>> SearchForARecipeAsync(string SpecificRecipe)
        {
            IEnumerable<Recipe> recipe;

            try
            {
                recipe = await _repository.FindRecipe(SpecificRecipe);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.Message, "SQL error - could not find recipe");
                //return StatusCode(500);

                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = ex.Message + "SQL error while getting list of ingredients for this recipe"
                };

            }
            if (!recipe.Any())   // Checks to see if IEnumerable is empty!
            {
                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = "This recipe could not be located."
                };
            }
            else
            { return recipe.ToList(); }
        }

        // POST api/<RecipeController>
        [HttpPost("/Recipe")]
        public async Task<ContentResult> CreateNewRecipeWithPost([FromBody] List<Recipe> newRecipe)
        {
            foreach (var recipeItemParam in newRecipe)
            {
                string RecipeName = recipeItemParam.RecipeName;
                decimal Rating = recipeItemParam.Rating;
                await _repository.CreateNewRecipe(RecipeName, Rating);
            }
            return new ContentResult() { StatusCode = 201 };
        }


        [HttpPost("/IngredientsList")]
        public async Task<ContentResult> AddToIngredientsListWithPost([FromBody] List<Ingredient> newIngredient)
        {
            foreach (var ingredientItemParam in newIngredient)
            {
                string RecipeName = ingredientItemParam.RecipeName;
                decimal IngredientQuantity = ingredientItemParam.IngredientQuantity;
                string UnitOfMeasure = ingredientItemParam.UnitOfMeasure;
                string IngredientName = ingredientItemParam.IngredientName;
                await _repository.AddToIngredientsList(RecipeName, IngredientQuantity, UnitOfMeasure, IngredientName);
            }
            return new ContentResult()
            {
                StatusCode = 201
                //ContentType = "application/json"
            };
        }

        [HttpGet("/IngredientsList")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> ListOfIngredientsAsync()
        {

            IEnumerable<Ingredient> recipe;
            try
            {
                recipe = await _repository.ListOfIngredients();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of users");
                return StatusCode(500);
            }
            return recipe.ToList();
        }


        [HttpGet("/SingleIngredientsList/{SpecificRecipe}")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> SingleListOfIngredientsAsync(string SpecificRecipe)
        {
            IEnumerable<Ingredient> singleIngredientsList;
            
            try
            {
                singleIngredientsList = await _repository.SingleListOfIngredients(SpecificRecipe);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of ingredients for {SpecificRecipe}", SpecificRecipe);
                //return StatusCode(500);

                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = ex.Message + "SQL error while getting list of ingredients for this recipe" 
                };
            }
            
            IEnumerable<Recipe> recipe;
            recipe = await _repository.FindRecipe(SpecificRecipe);
            if (!recipe.Any())   // Checks to see if IEnumerable is empty!
            {
                //return StatusCode(500);
                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = "This recipe could not be located."
                };
            }
            else
            { return singleIngredientsList.ToList(); }
        }


        [HttpGet("/SingleStepsList/{SpecificRecipe}")]
        public async Task<ActionResult<IEnumerable<Step>>> SingleListOfStepsAsync(string SpecificRecipe)
        {
            IEnumerable<Step> singleStepsList;

            try
            {
                singleStepsList = await _repository.SingleListOfSteps(SpecificRecipe);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of ingredients ");
                //return StatusCode(500);

                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = ex.Message 
                };
            }

            IEnumerable<Recipe> recipe;
            recipe = await _repository.FindRecipe(SpecificRecipe);
            if (!recipe.Any())   // Checks to see if IEnumerable is empty!
            {
                //return StatusCode(500);
                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = "This recipe could not be located."
                };
            }
            else
            { return singleStepsList.ToList(); }
        }





        [HttpDelete("/Recipes/{SpecificRecipe}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> DeleteARecipeAsync(string SpecificRecipe)
        {
            IEnumerable<Recipe> recipe;

            try
            {
                await _repository.DeleteRecipe(SpecificRecipe);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.Message, "SQL error - could not find recipe");
                //return StatusCode(500);

                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = ex.Message + "SQL error while getting list of ingredients for this recipe"
                };

            }
            recipe = await _repository.FindRecipe(SpecificRecipe);
            if (!recipe.Any())   // Checks to see if IEnumerable is empty!
            {
                return new ContentResult()
                {
                    StatusCode = 200,
                    Content = "This recipe has been deleted."
                };
            }
            else
            {
                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = "This recipe could not be deleted."
                };
            }
            //{ return recipe.ToList(); }
        }






        /*
                [HttpGet("/Details/{SpecificRecipe}")]
                public async Task<ActionResult<IEnumerable<FullDetail>>> DetailsForRecipeAsync(string SpecificRecipe)
                {
                    IEnumerable<FullDetail> detailList;

                    try
                    {
                        detailList = await _repository.FullRecipeDetails(SpecificRecipe);
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError(ex, "SQL error while getting details for {SpecificRecipe}", SpecificRecipe);
                        //return StatusCode(500);

                        return new ContentResult()
                        {
                            StatusCode = 500,
                            Content = ex.Message + "SQL error while getting details for this recipe"
                        };
                    }

                    IEnumerable<Recipe> recipe;
                    recipe = await _repository.FindRecipe(SpecificRecipe);
                    if (!recipe.Any())   // Checks to see if IEnumerable is empty!
                    {
                        //return StatusCode(500);
                        return new ContentResult()
                        {
                            StatusCode = 500,
                            Content = "This recipe could not be located."
                        };
                    }
                    else
                    { return detailList.ToList(); }
                }
        */







        //////////////////////////////////////////////////



        //        // GET api/<RecipeController>/5
        //        [HttpGet("{id}")]
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/<RecipeController>
        //    [HttpPost]
        //    public void Post([FromBody] string value)
        //    {
        //    }

        //    // PUT api/<RecipeController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<RecipeController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
        //}

    }
}

