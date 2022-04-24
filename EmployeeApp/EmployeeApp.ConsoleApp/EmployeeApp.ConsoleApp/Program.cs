using EmployeeApp.UI;
using System;

namespace EmployeeApp.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Uri uri = new Uri("https://localhost:7000");
            Uri uri = new Uri("http://revdeploymentdemo.azurewebsites.net");

            IO io = new IO(uri);

            await io.BeginAsync();
        }
    }
}