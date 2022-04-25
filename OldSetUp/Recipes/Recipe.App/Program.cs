using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Logic;
using Recipe.DataInfrastructure;

namespace Recipe.App
{
    class Program
    {
        static void Main()
        {
            //User kelly = new User("kelly0211", "password123", "kelly", "keng");

            string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project1.txt");

            IRepository repo = new SqlRepository(connectionString);

            RecipeInfo objOfRecipeInfo = new RecipeInfo(repo);
            Console.WriteLine(objOfRecipeInfo.ListAllUserNames());

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            RecipeObj macaron = new RecipeObj("macaron", "French method", "dessert", 4, "almonds", 7);





        }
    }
}



//using SqlConnection connection = new SqlConnection
//    (this._connectionString);
//connection.Close();


//IEnumerable<User> listObj = repo.ListOfUsers();
//foreach (User userName in listObj)
//{
//    Console.WriteLine(userName);
//}

//Console.WriteLine(listnames);
//Console.WriteLine(repo.ListOfUsernames());
//string usernames = repo.ListOfUsernames();
////foreach (User user in usernames)
////{
////    Console.WriteLine(user);
////}
//Console.Write(usernames);



//RecipeObj macaron = new RecipeObj("macaron", "French method", string Course, double Rating, string KeyIngredient, int LevelOfDifficulty);
