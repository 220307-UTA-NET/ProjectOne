using System;
using RecipeBookApp.UI;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeBookApp.ConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Change to this uri later:
            // Uri uri = new Uri("https://revatureprojectone.azurewebsites.net");

            Uri uri = new Uri("https://localhost:7089");


            IO io = new IO(uri);

            await io.BeginAsync();

            //IO answer = new IO();
            //await io.CreateNewUserAcctAsync();

        }

    }
}