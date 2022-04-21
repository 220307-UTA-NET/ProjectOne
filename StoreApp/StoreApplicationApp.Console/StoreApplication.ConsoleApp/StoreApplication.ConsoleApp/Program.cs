using System;
using StoreApplicationApp.UI;

namespace StoreApplication.ConsoleApp
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            Console.WriteLine("hi");
            Uri uri = new Uri("https://localhost:7261");
            IO io = new IO(uri);
            await io.BeginAsync();
        }
    }
}