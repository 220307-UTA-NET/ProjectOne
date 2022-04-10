using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Logic;
using Recipe.DataInfrastructure;
using Recipe.Logic;

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

        }
    }
}


