using BettaFishApp.UI;
using System;

namespace BettaFishApp.ConApp
{
    class Program
    {
        // Fields


        // Constructors


        // Methods
        static async Task Main(string[] args)
        {

            Uri uri = new Uri("https://localhost:7198");

            IO io = new IO(uri);

            await io.BeginAsync();



        }
    }
}
