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

            Uri uri = new Uri("https://localhost:7094/");
            BettaFishIO bettaFishIO = new BettaFishIO(uri);
            await bettaFishIO.BeginAsync();
            Console.WriteLine("Thank you for visting!");



        }
    }
}
