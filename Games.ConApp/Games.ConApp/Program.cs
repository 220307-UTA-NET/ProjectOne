using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Games.ConApp.DTOs;
using Games.ConApp.UI;

namespace GameStore.ConApp
{
    public class Program
    {
        // Fields

        public static readonly HttpClient httpClient = new HttpClient();

        // Constructors

        // Methods

        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:7171/");
            IO io = new IO();

            io.Begin();

            //HttpClient client = new HttpClient();

            //// If method is async, we await the Task
            //// **********************Change URL here**********************
            //string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

            //// Deserialize JSON from URL to ToDo object
            //List <ToDo> todo = JsonSerializer.Deserialize<List<ToDo>>(response);

            ////Console.WriteLine(response);

            //// iterates through all *items* in *todo*(which is a ToDo List) and prints out the name field
            //foreach (var item in todo)
            //{
            //    Console.WriteLine(item.title);
            //}

        }
    }
}