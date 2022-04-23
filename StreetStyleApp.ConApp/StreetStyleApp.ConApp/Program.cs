using StreetStyleApp.UI;
using System;

namespace StreetStyleApp.ConApp
{
    class Program
    { 
        // Fields
        

        // Constructors


        // Methods
        static async Task Main(string[] args)
        {
           
            Uri uri = new Uri("https://localhost:7024");

            IO io = new IO(uri);

            await  io.Begin();



        }
    }
}