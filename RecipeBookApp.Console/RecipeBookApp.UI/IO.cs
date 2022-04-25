
using RecipeBookApp.UI.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeBookApp.UI
{
    public class IO
    {
        // Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        // Constructors
        public IO(Uri uri)
        {
            this.uri = uri;
        }

        // Methods
        public async Task BeginAsync()
        {
            Console.WriteLine("RecipeBook.App.ConApp has started...");
            bool loop = true;

            do
            {
                int option = MainMenu();

                switch (option)
                {
                    case 404:
                        Console.WriteLine("Invalid response.\nPlease press any key and try again.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayAllUsersAsync();
                        break;

                    case 2:
                        await CreateNewUserAcctAsync();
                        Console.WriteLine("Finished case 2.");
                        break;
                    case 3:
                        await GetRecipeList();
                        Console.WriteLine("Finished case 3.");
                        break;
                    case 4:
                        await CreateNewRecipeAsync();
                        Console.WriteLine("Finished case 4.");
                        break;
                    case 5:
                        await CreateIngredientsListAsync();
                        Console.WriteLine("Finished case 5.");
                        break;
                    case 6:
                        await GetIngredientsListAsync();
                        Console.WriteLine("Finished case 6.");
                        break;
                    case 7:
                        await GetSingleIngredientsListAsync();
                        Console.WriteLine("Finished case 7.");
                        break;
                    case 8:
                        await GetStepsList();
                        Console.WriteLine("finished case 8");
                        break;
                    default:
                        Console.WriteLine("maybe over.");
                        break;
                }
            }
            while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int option;
            Console.WriteLine("Please select from the options below:");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get details for every account.");
            Console.WriteLine("[2] - Create a new account.");
            Console.WriteLine("[3] - View List of Recipes, Table of Contents");
            Console.WriteLine("[4] - Add a new recipe.");
            Console.WriteLine("[5] - Create ingredients list.");
            Console.WriteLine("[6] - View ingredients list for every recipe.");
            Console.WriteLine("[7] - View ingredients list for a recipe.");
            Console.WriteLine("[8] - view list of steps for a recipe");
            string? input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out option))
            { option = 404; }
            return option;
        }


        private async Task DisplayAllUsersAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "userAccount");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var users = await httpResponse.Content.ReadFromJsonAsync<List<UserDTO>>();

                if (users != null)
                {
                    Console.WriteLine("User Accounts:  ");
                    foreach (var user in users)
                    {
                        Console.WriteLine("Username: " + user.Username);
                    }
                }
                else
                {
                    Console.WriteLine("No accounts found. \nPlease press any key to continue.");
                    Console.ReadLine();
                    //"to be associated with this username. ");
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public async Task CreateNewUserAcctAsync()
        {
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "userAccount");
            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "userAccount");

            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            ////////////////////////

            Console.Write("\nPlease enter your first name:    ");
            string? FirstName = Console.ReadLine(); // maybe put in try-parse

            Console.Write("\nPlease enter you last name:    ");
            string? LastName = Console.ReadLine();

            Console.Write("\nPlease choose a username:    ");  // add method to check against other usernames
            string? Username = Console.ReadLine();

            Console.Write("\nPlease choose a password:    ");  // need to add second input for verification
            string? UserPassword = Console.ReadLine();

            var acctInfo = new UserDTO(Username, UserPassword, FirstName, LastName);

            List<UserDTO> acctInfoList = new List<UserDTO>();
            acctInfoList.Add(acctInfo);

            //Console.WriteLine("The acct into is:    " + acctInfoList);   
            //Console.ReadLine();
            ////
            //            foreach (var user in acctInfoList)
            //            {
            //                Console.WriteLine(user);
            //            }
            HttpResponseMessage Response = await httpClient.PostAsJsonAsync(uri.ToString() + "userAccount", acctInfoList);

            //Console.WriteLine("The Response sent is:    " + Response);
            //Console.ReadLine();

            string response = Response.Content.ReadAsStringAsync().Result;

            if (response != null)
            {
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("there is no response");
                Console.ReadLine();
            }
            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
        }

        public async Task GetRecipeList()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Recipe");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));



            using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var recipes = await httpResponse.Content.ReadFromJsonAsync<List<RecipeDTO>>();

                if (recipes != null)
                {
                    Console.WriteLine("Recipes:  ");
                    foreach (var recipe in recipes)
                    {
                        Console.Write(" ~ " + recipe.RecipeName + "\tRating: " + recipe.Rating);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No recipes found. \nPlease press any key to continue.");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public async Task CreateNewRecipeAsync()
        {
            Console.Write("\nPlease enter a recipe:    ");
            string? RecipeName = Console.ReadLine(); // maybe put in try-parse

            Console.Write("\nPlease enter your rating:    ");
            decimal Rating = decimal.Parse(Console.ReadLine());

            var recipeInfo = new RecipeDTO(RecipeName, Rating);
            List<RecipeDTO> recipeInfoList = new List<RecipeDTO>();
            recipeInfoList.Add(recipeInfo);

            HttpResponseMessage Response = await httpClient.PostAsJsonAsync(uri.ToString() + "Recipe", recipeInfoList);

            string response = Response.Content.ReadAsStringAsync().Result;

            if (response != null)
            {
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("there is no response");
                Console.ReadLine();
            }
        }

        public async Task CreateIngredientsListAsync()
        {
            char moreIngredients = 'y';
            Console.Write("\nPlease enter the recipe:    ");
            string? RecipeName = Console.ReadLine(); // maybe put in try-parse
                                                     // maybe add a loop to add multiple ingredients and ends loop when user is finished
            do
            {
                Console.Write("\nPlease enter the ingredient:    ");
                string? IngredientName = Console.ReadLine();

                Console.Write("\nPlease enter the ingredient quantity:    ");
                decimal IngredientQuantity = decimal.Parse(Console.ReadLine());

                Console.Write("\nPlease enter the unit of measurement:    ");
                string? UnitOfMeasure = Console.ReadLine();


                var ingredientInfo = new IngredientDTO(RecipeName, IngredientQuantity, UnitOfMeasure, IngredientName);
                List<IngredientDTO> ingredientInfoList = new List<IngredientDTO>();
                ingredientInfoList.Add(ingredientInfo);

                HttpResponseMessage Response = await httpClient.PostAsJsonAsync(uri.ToString() + "IngredientsList", ingredientInfoList);

                string response = Response.Content.ReadAsStringAsync().Result;

                if (response != null)
                {
                    Console.WriteLine(response);
                }
                else
                {
                    Console.WriteLine("there is no response");
                    Console.ReadLine();
                }

                Console.Write("\nDo you have more ingredients to add? \nEnter 'y' for yes and 'n' for no.    ");
                moreIngredients = char.Parse(Console.ReadLine());


            } while (moreIngredients == 'y');
        }

        public async Task GetIngredientsListAsync()
        {
            //Console.Write("Please enter the recipe for which you would like to see the ingredient list: \t");
            //string RecipeToGet = Console.ReadLine();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "IngredientsList/");

            //request.Headers.Add("SpecificRecipe", "cookies");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));



            //request.Content.("SpecificRecipe = cookies");
            //Console.Write(request.Options);
            //request.Headers.Add(string RecipeNameParam)


            using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var ingredients = await httpResponse.Content.ReadFromJsonAsync<List<IngredientDTO>>();

                if (ingredients != null)
                {
                    Console.WriteLine("recipe Name");
                    Console.WriteLine("Ingredients List for this recipe:  ");
                    Console.WriteLine();
                    Console.WriteLine("IngredientQuantity  \t" + "UnitOfMeasure  \t" + "IngredientName");
                    foreach (var ingredient in ingredients)
                    {
                        Console.WriteLine(ingredient.IngredientQuantity + "\t" + ingredient.UnitOfMeasure + "\t" + ingredient.IngredientName);
                    }
                }
                else
                {
                    Console.WriteLine("No recipes found. \nPlease press any key to continue.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public async Task GetSingleIngredientsListAsync()
        {
            Console.Write("Please enter the recipe for which you would like to see the ingredient list: \t");
            string RecipeToGet = Console.ReadLine();

            
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "SingleIngredientsList/" + RecipeToGet);

            //request.Headers.Add("SpecificRecipe", "cookies");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var ingredients = await httpResponse.Content.ReadFromJsonAsync<List<IngredientDTO>>();

                if (ingredients != null)
                {
                    Console.Clear();
                    Console.WriteLine("\t" + RecipeToGet);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                    //Console.WriteLine("Ingredients List for this recipe:  ");
                    //Console.WriteLine();
                    Console.WriteLine("Ingredient" + "\t   " + "Quantity  ");
                    foreach (var ingredient in ingredients)
                    {
                        //Console.WriteLine(ingredient.RecipeName);
                        Console.WriteLine(ingredient.IngredientName + "\t\t    " + ingredient.IngredientQuantity + " " + ingredient.UnitOfMeasure);
                    }
                }
                else
                {
                    Console.WriteLine("No recipes found. \nPlease press any key to continue.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public async Task GetStepsList()
        {
            Console.Write("Please enter the recipe for which you would like to see the steps for: \t");
            string RecipeToGet = Console.ReadLine();



            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "SingleStepsList/" + RecipeToGet);

            //request.Headers.Add("SpecificRecipe", "cookies");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var steps = await httpResponse.Content.ReadFromJsonAsync<List<StepDTO>>();

                if (steps != null)
                {
                    //Console.Clear();
                    //Console.WriteLine("\t" + "Steps");
                    //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                    //Console.WriteLine("Ingredients List for this recipe:  ");
                    //Console.WriteLine();
                    Console.WriteLine("Steps ");
                    foreach (var step in steps)
                    {
                        Console.WriteLine("- " + step.StepNumber + "\t\t" + step.StepDescription);
                    }
                }
                else
                {
                    Console.WriteLine("No recipes found. \nPlease press any key to continue.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

/*
        public async Task GetRecipeInfoAsync()
        {
            Console.Write("Please enter the recipe for which you would like to see the ingredient list: \t");
            string RecipeToGet = Console.ReadLine();



            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "SingleIngredientsList/" + RecipeToGet);

            //request.Headers.Add("SpecificRecipe", "cookies");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var ingredients = await httpResponse.Content.ReadFromJsonAsync<List<IngredientDTO>>();

                if (ingredients != null)
                {
                    Console.Clear();
                    Console.WriteLine("\t" + RecipeToGet);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                    //Console.WriteLine("Ingredients List for this recipe:  ");
                    //Console.WriteLine();
                    Console.WriteLine("Ingredient" + "\t   " + "Quantity  ");
                    foreach (var ingredient in ingredients)
                    {
                        //Console.WriteLine(ingredient.RecipeName);
                        Console.WriteLine(ingredient.IngredientName + "\t\t    " + ingredient.IngredientQuantity + " " + ingredient.UnitOfMeasure);
                    }
                }
                else
                {
                    Console.WriteLine("No recipes found. \nPlease press any key to continue.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
*/

        ////////////////////////////////////////////////////
        //////////////////////////////////////////////////
        
        
        //public async Task GetInfoAsync()
        //{
        //    Console.Write("Please enter the recipe name: \t");
        //    string RecipeToGet = Console.ReadLine();
        //    string continueOn = "true";
        //    ////////////////////////////////////////

        //    do
        //    {

        //        ///////////////// ingredients
        //        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "SingleIngredientsList/" + RecipeToGet);

        //        //request.Headers.Add("SpecificRecipe", "cookies");
        //        request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

        //        using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
        //        {
        //            httpResponse.EnsureSuccessStatusCode();
        //            if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
        //            {
        //                throw new ArrayTypeMismatchException();
        //            }

        //            var ingredients = await httpResponse.Content.ReadFromJsonAsync<List<IngredientDTO>>();

        //            Console.WriteLine("\t" + RecipeToGet);
        //            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        //            //Console.WriteLine("Ingredients List for this recipe:  ");
        //            //Console.WriteLine();
        //            Console.WriteLine("Ingredient" + "\t   " + "Quantity  ");
        //            foreach (var ingredient in ingredients)
        //            {
        //                //Console.WriteLine(ingredient.RecipeName);
        //                Console.WriteLine(ingredient.IngredientName + "\t\t    " + ingredient.IngredientQuantity + " " + ingredient.UnitOfMeasure);
        //            }
        //            //}
        //            //else
        //            //{
        //            //    Console.WriteLine("No recipes found. \nPlease press any key to continue.");
        //            //    Console.ReadKey();
        //            //}
        //            continueOn = "true";
        //        }
        //    } while (continueOn == "false");

        //    ///////// steps
        //    HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "SingleStepsList/" + RecipeToGet);

        //        //request.Headers.Add("SpecificRecipe", "cookies");
        //        request1.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

        //        using (HttpResponseMessage httpResponse1 = await httpClient.SendAsync(request1))
        //        {
        //            //httpResponse1.EnsureSuccessStatusCode();
        //            if (httpResponse1.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
        //            {
        //                throw new ArrayTypeMismatchException();
        //            }

        //            var steps = await httpResponse1.Content.ReadFromJsonAsync<List<StepDTO>>();

        //            if (steps != null)
        //            {
        //                Console.WriteLine("Steps:");
        //                foreach (var step in steps)
        //                {
        //                    //Console.WriteLine(ingredient.RecipeName);
        //                    Console.WriteLine(step.StepNumber + "\t    " + step.StepDescription);
        //                }
        //            }
        //            //else
        //            //{
        //            //    Console.WriteLine("No recipes found. \nPlease press any key to continue.");
        //            //    Console.ReadKey();
        //            //}

        //        }

        //    //////////////////////

        //    Console.WriteLine("\nPress any key to continue.");
        //    Console.ReadKey();
        //    Console.Clear();
        //}






    }
}
