using ComputerStore.UI;

namespace ConsoleComputerStore
{
    public class Program
    {
        //Fields

      

        //Constrocturs

        //Methods
        static async Task Main(string[] args)
        {
            Uri uri = new Uri("https://localhost:7024");
            
            IO io = new IO(uri);

           await io.BeginAsync();
        }
    }
}