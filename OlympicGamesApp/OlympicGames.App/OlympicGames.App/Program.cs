using OlympicGames.UI;

namespace OlympicGames.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Uri uri = new Uri("https://olympicgames.azurewebsites.net");
            IO io = new IO(uri);
            await io.BeginWebApp();
        }
    }
}