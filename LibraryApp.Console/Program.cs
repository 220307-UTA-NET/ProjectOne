using LibraryApp.UI;
using System;

namespace LibraryApp.Runner
{
    class Program
    {
        //Starts/runs the user input portion of the console app
        static async Task Main(string[] args)
        {
            //If running locally, change the commenting on the lines starting with "Uri uri..."
            //Uri uri = new Uri("https://localhost:7110/");
            //Edit this next line with the location of the deployed API
            //If you used azure, you should only need to swap out the prefix (p1api)
            Uri uri = new Uri("https://p1api.azurewebsites.net");
            IO io = new IO(uri);
            await io.BeginAsync();
        }
    }
}