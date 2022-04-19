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

            
            Uri uri = new Uri("https://bettafishinformation.azurewebsites.net");
            

            BettaFishIO bettaFishIO = new BettaFishIO(uri);
            await bettaFishIO.BeginAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THANK YOU FOR VISTING!");

        }
    }
}
