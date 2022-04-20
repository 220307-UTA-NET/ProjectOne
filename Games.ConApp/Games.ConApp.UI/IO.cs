namespace Games.ConApp.UI;
public class IO
{
    // Fields
    private readonly Uri uri;

    // Constructors
    public IO (Uri uri)
    {
        this.uri = uri;
    }

    // Methods

    public void Begin()
    {
        Console.WriteLine("Begginingggg");

        bool loop = true;

        do
        {
            int choice = MainMenu();
            switch(choice)
            {
                case 0: loop = false; break;
            }
        } while (loop == true);
    }
}

