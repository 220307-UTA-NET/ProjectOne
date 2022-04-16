using System;
using System.IO;
using Project1.UI;
using Project1.DTOs;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project1.ConsoleApp
{
    class Program
    {
       // public static readonly HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {

            Uri uri = new Uri("https://localhost:7080");
            IO io = new IO(uri);
            io.BeginAsync();            
        }
    }
}