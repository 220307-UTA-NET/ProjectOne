using Project1.UI;

namespace Project1ConsoleApp
{
    class Program
    {


        public static HttpClient httpClient = new HttpClient();



        static async Task Main(string[] args)
        {

            Uri uri = new Uri("https://localhost:7290");

            IO io = new IO(uri);

            await io.StartAysnc();


        }
    }
}