using IndieGameApp.UI;

namespace IndieGameStoreConsole2
{
    public class Program
    {
        //fields

        //Constructors


        //Methods
        static async Task Main()
        {
            Uri uri = new Uri("https://localhost:7107");
            IO io = new IO(uri);

            await io.Begin();


        }

    }
}
