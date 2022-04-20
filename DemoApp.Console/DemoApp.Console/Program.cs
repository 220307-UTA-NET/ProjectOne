using System;
using System.IO;
using DemoApp.UI;
using DemoApp.DTOs;
using System.Text.Json;
using System.Threading.Tasks;

namespace DempApp.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
        

            Uri uri = new Uri("https://localhost:37133");

            DemoApp.UI.IO io = new IO(uri);

            await io.BeginAsync();



        }
    }

}


