using System;
using Museum.UI;

namespace MuseumConsole
{
    class Program
    {
       


        static async Task Main(string[] args)
        {
            Uri uri = new Uri("https://museumapp.azurewebsites.net/");
            //Uri uri = new Uri("https://localhost:7102/");
            IO io = new IO(uri);
            await io.BeginAsync();
        }
    }
}


