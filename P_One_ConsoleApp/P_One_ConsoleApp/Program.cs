
using P_One_UI;

namespace P_One_ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            //localhost for testing
            //client.BaseAddress = new Uri("https://localhost:7083/");
            //URI for deployment to Azure
            client.BaseAddress = new Uri("https://projectonedang.azurewebsites.net/");
            Game game = new Game(client);
            await game.StartGame();
            
        }
    }
}
