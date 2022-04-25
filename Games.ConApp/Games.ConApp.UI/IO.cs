using System.Net.Http.Json;
using System.Net.Mime;
using Games.ConApp.DTOs;

namespace Games.ConApp.UI
{
    public class IO
    {
        // Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        // Constructors
        public IO (Uri uri)
        {
            this.uri = uri;
        }

        // Methods

        public async Task BeginAsync()
        {
            Console.WriteLine("Begginingggg");

            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch(choice)
                {
                    case -1: Console.WriteLine("Unknown input. Try again"); break;
                    case 0: loop = false; break;
                    case 1: await GetAllGamesAsync(); break;
                }
            } while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1; 
            Console.WriteLine("Please make a selection");
            Console.WriteLine("[1] Return games library.");
            Console.WriteLine("[0] - Exit");
            string? input = Console.ReadLine();
            Console.Clear(); ;
            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }

        private async Task GetAllGamesAsync()

        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Game");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();


                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var games = await response.Content.ReadFromJsonAsync<List<GameDTO>>();

                if (games != null)
                {
                    Console.WriteLine("Games: ");
                    foreach (var game in games)
                    {
                        Console.WriteLine("Game title: " + game.title + " - " + game.genre);
                    }
                }
                else
                {
                    Console.WriteLine("No games found");
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();

        }
    }
}

