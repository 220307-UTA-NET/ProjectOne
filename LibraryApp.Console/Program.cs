using LibraryApp.UI;
using System;

namespace LibraryApp.Runner
{
    class Program
    {
        //Fields
        //Constructors
        //MEthods
        static async Task Main(string[] args)
        {
            Uri uri = new Uri("https://localhost:7110/");
            IO io = new IO(uri);
            await io.BeginAsync();
        }
    }
}