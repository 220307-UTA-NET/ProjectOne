using Games.ConApp.UI;

namespace GameStore.ConApp
{
    public class Program
    {
        // Fields

        // Constructors

        // Methods

        static async Task Main(string[] args)
        {
            Uri uri = new Uri("https://localhost:7171/");
            IO io = new IO(uri);

            await io.BeginAsync();

        }
    }
}