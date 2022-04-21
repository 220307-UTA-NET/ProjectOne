using System.Net.Mime;
using System.Net.Http.Json;
using OlympicGames.UI.DTOs;
using System.Text.RegularExpressions;

namespace OlympicGames.UI
{
    public class IO
    {
        private readonly Uri uri;
        private static readonly HttpClient httpclient = new HttpClient();
        private string name;
        //int result = 0;

        public IO(Uri uri)
        {
            this.uri = uri;
        }
        public async Task BeginWebApp()
        {
            await Onboarding(); //Introduction
            await RegisterConsumer(); //Register Consumer
            await Menu(); //Choice selection
        }

        private async Task Onboarding()
        {
            HttpRequestMessage http_request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Onboarding");
            http_request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage http_response = await httpclient.SendAsync(http_request))
            {
                http_response.EnsureSuccessStatusCode();
                if (http_response.Content.Headers.ContentType?.MediaType == MediaTypeNames.Application.Json)
                {
                    var info = await http_response.Content.ReadFromJsonAsync<List<OnboardingDTO>>();
                    if (info != null)
                    {
                        Console.WriteLine("\nThe Olympic Games Web Application!\n----------------------------------------------");
                        foreach (var piece in info)
                        {
                            Console.WriteLine(piece.Description);
                            Console.WriteLine("\nDeveloper: " + piece.Author);
                            Console.WriteLine("Database Entry Date: " + piece.Date);
                            Console.WriteLine("Resource: " + piece.Source);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No information found");
                    }
                }
                else if (http_response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
            }
        }

        private async Task RegisterConsumer()
        {
            Console.WriteLine("\n\nTake a moment to register in order to fully utilize Olympic Games. This will allow your history to be tracked");
            bool condition = true;
            while (condition == true)
            {
                Console.Write("Please enter your full name: ");
                name = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z]+[\s][a-zA-Z]+$");
                Match match = regex.Match(name);
                if (name != null && name.Length > 2 && match.Success)
                {
                    using (HttpResponseMessage response = await httpclient.PostAsJsonAsync(uri.ToString() + "Register", name))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("\nThank you for registering with the Olympic Games Web Application! You have been successfully registered and now your history is being tracked.");
                            Console.WriteLine("\nPress any key to go to the main menu");
                            Console.ReadKey();
                            Console.Clear();
                            condition = false;                           
                        }
                        else
                        {
                            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                        }
                    }                   
                }
                else
                {
                    Console.WriteLine("\nThere was an issue with your formatting. Please type your name again");
                }
            }
        }

        private async Task Menu()
        {
            bool condition = true;
            int result = 0;
            Console.WriteLine("Welcome to the Olympic Games Web Application, " + name + "!!!" + "\n\nPlease choose an option: ");
            Console.WriteLine("-------------------------------------------");
            while (condition == true)
            {
                Console.WriteLine("Learn more about medals in Olympic Games history                     [1]"); //GETs information about medal history
                Console.WriteLine("Search medals won by specific countries                              [2]"); //GETs country info via user input
                Console.WriteLine("Search medals won by specific competitors                            [3]"); //GETS competitor info via user input           

                Console.WriteLine("View and update your search history                                  [6]"); //GETs user history and allows user to remove parts      
                Console.WriteLine("View and remove your history from the app                            [7]"); //GETS history and allows user to DELETE history
                Console.WriteLine("Exit the Olympic Games Web Application                               [8]"); //Exits the Olympic Games Web Application
                Console.Write("Your selection: ");
                bool input = int.TryParse(Console.ReadLine(), out result); 
                if (input == false)
                {
                    Console.WriteLine("Input error. Please type a number...\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (result > 7 || result <= 0)
                {
                    Console.WriteLine("Invalid selection. Please type a number within range...\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    condition = false;                  
                }
            }
            switch (result)
            {
                case 1:
                   await GetMedalDescriptionAsync();
                   Console.Clear();
                   await Menu();
                  break;
              case 2:
                    await GetSpecificCountryMedals();
                    Console.Clear();
                    await Menu();
                    break;
              case 3:
                  break;
              default:
                  Console.WriteLine("Error in switch");
                  break;
            }         
        }

        private async Task GetMedalDescriptionAsync()         
        {
            Console.Clear();
            HttpRequestMessage http_request2 = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "MedalDescription");
            http_request2.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage http_response2 = await httpclient.SendAsync(http_request2))
            {
                http_response2.EnsureSuccessStatusCode();
                if (http_response2.Content.Headers.ContentType?.MediaType == MediaTypeNames.Application.Json)
                {
                    var info = await http_response2.Content.ReadFromJsonAsync<List<OnboardingDTO>>();
                    if (info != null)
                    {
                        Console.WriteLine("\nThe Olympic Games Medals History!\n----------------------------------------------");
                        foreach (var piece in info)
                        {
                            Console.WriteLine(piece.Description);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No information found");
                    }
                }
                else if (http_response2.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
            }
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        private async Task GetSpecificCountryMedals()
        {
            Console.Clear();
            HttpRequestMessage http_request2 = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "MedalDescription/MedalStats");
            http_request2.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage http_response2 = await httpclient.SendAsync(http_request2))
            {
                http_response2.EnsureSuccessStatusCode();
                if (http_response2.Content.Headers.ContentType?.MediaType == MediaTypeNames.Application.Json)
                {
                    var info = await http_response2.Content.ReadFromJsonAsync<List<MedalDTOs>>();
                    if (info != null)
                    {
                        Console.WriteLine("\nThe Olympic Games Medals History!\n----------------------------------------------");
                        foreach (var piece in info)
                        {
                            Console.WriteLine(piece.Country_Name);
                            Console.WriteLine(piece.Gold_Medals);
                            Console.WriteLine(piece.Silver_Medals);
                            Console.WriteLine(piece.Bronze_Medals);
                            Console.WriteLine(piece.Total_Medal);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No information found");
                    }
                }
                else if (http_response2.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
            }
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}