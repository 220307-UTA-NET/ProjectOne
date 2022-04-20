using BettaFishDTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BettaFishApp.UI
{
    public class BettaFishIO
    {
        // Fields
        private readonly Uri uri;



        public static readonly HttpClient httpClient = new HttpClient();




        // Constructors
        public BettaFishIO(Uri uri)
        {
            this.uri = uri;
        }


        // Methods
        public async Task BeginAsync()
        {
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Incorrect Input, please try again.");
                        Console.WriteLine("Press any KEY to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayGetAllBettaTypeAsync();
                        break;
                    case 2:
                        await DisplayBettaDescriptionAsync();
                        break;
                    case 3:
                        await DisplayGetAllBettaFunFactsAsync();
                        break;
                    case 4:
                        BettaStoriesDTO bettastories = GetUserInput2();
                        await GetBettaStoriesAsync(bettastories);
                        break;
                    case 5:
                        await DisplayBettaFanStoryAsync();
                        break;
                    case 6:
                        RegistrationDTO bettaregistration = GetUserInput();
                        await GetWebRegistrationAsync(bettaregistration);
                        break;
                    case 7:
                        await DisplayBettaFanAsync();
                        break;
                    case 8:
                        await DisplayBettaStores();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please try again.");
                        break;


                }
            } while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Betta Fish Fan Website!");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please select an OPTION to explore:");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n[0] : Exit");
            Console.WriteLine("\n[1] : Betta Type");
            Console.WriteLine("\n[2] : Betta Descriptions");
            Console.WriteLine("\n[3] : Betta Fun Facts");
            Console.WriteLine("\n[4] : Share Your Betta Story");
            Console.WriteLine("\n[5] : View Your Betta Stories");
            Console.WriteLine("\n[6] : Register With Us");
            Console.WriteLine("\n[7] : View Betta Fan");
            Console.WriteLine("\n[8] : Store Locations");


            string? input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }

        private async Task DisplayGetAllBettaTypeAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/get/type");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var bettatypes = await response.Content.ReadFromJsonAsync<List<BettaTypeDTO>>();

                if (bettatypes != null)
                {

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("BETTA TYPES");
                    foreach (var bettatype in bettatypes)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n[Type]" + " " + "[" + bettatype.tail_ID + "]" +  ":"  + bettatype.tailType);

                    }
                }
                else
                {
                    Console.WriteLine("No Betta Type Information Found.");
                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any KEY to return to the MAIN MENU. Thank you..");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task DisplayBettaDescriptionAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/get/description");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var bettadescriptions = await response.Content.ReadFromJsonAsync<List<BettaTypeDTO>>();

                if (bettadescriptions != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("BETTA DESCRIPTION");
                    foreach (var bettadescription in bettadescriptions)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nType" + "[" + bettadescription.tail_ID + "]" + "[" + bettadescription.tailType + "]" + "\n" + bettadescription.description);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nPress ENTER to continue.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("No Betta Type Information Found.");
                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any KEY to return to the MAIN MENU. Thank you..");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task DisplayGetAllBettaFunFactsAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/get/funfacts");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var bettafunfacts = await response.Content.ReadFromJsonAsync<List<BettaFunFactsDTO>>();

                if (bettafunfacts != null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("BETTA FUN FACTS");
                    foreach (var bettafunfact in bettafunfacts)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFun Fact:" + "[" + bettafunfact.fact_ID + "]" + bettafunfact.funFact);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadLine();

                    }

                }
                else
                {
                    Console.WriteLine("No Betta Fun Fact Found.");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task GetBettaStoriesAsync(BettaStoriesDTO bettastories)
        {

            using (HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri.ToString() + "betta/stories", bettastories))
            {

                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYour story was successfully posted.");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task DisplayBettaFanStoryAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/view/fanstories");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var bettafanstories = await response.Content.ReadFromJsonAsync<List<BettaStoriesDTO>>();

                if (bettafanstories != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("BETTA STORIES");
                    foreach (var bettafanstorie in bettafanstories)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFan Story:" + "[" + bettafanstorie.story_ID + "]" + "\nName of Betta:" 
                            + "[" + bettafanstorie.nameOfBetta + "]" +  ":" + bettafanstorie.story);
                    }

                }
                else
                {
                    Console.WriteLine("No Betta Fun Fact Found.");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();

        }

        private async Task GetWebRegistrationAsync(RegistrationDTO bettaregistration)
        {
        
            using (HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri.ToString() + "betta/registration", bettaregistration))
            {
              
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYour registration was successful.");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();
        }   

        private async Task DisplayBettaFanAsync()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/view/registration");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var viewregistrations = await response.Content.ReadFromJsonAsync<List<RegistrationDTO>>();

                if (viewregistrations != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("BETTA FAN");
                    foreach (var viewregistration in viewregistrations)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFan:" + "[" + viewregistration.registration_ID + "]"  + "Name of Fan:" + "[" + viewregistration.lName + 
                            " " + viewregistration.fName + "]");

                    }

                }
                else
                {
                    Console.WriteLine("No Betta Fun Fact Found.");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();

        }

        private async Task DisplayBettaStores()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/get/storelocation");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var storelocations = await response.Content.ReadFromJsonAsync<List<BettaStoreLocationDTO>>();

                if (storelocations != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("BETTA STORE LOCATIONS");
                    foreach (var storelocation in storelocations)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nStore:" + "[" + storelocation.store_ID + "]" + "\nName of Store:"
                            + "[" +  storelocation.storeName + "]" + " " + storelocation.storeAddress);
                    }

                }
                else
                {
                    Console.WriteLine("No Betta Fun Fact Found.");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();


        }

        public RegistrationDTO GetUserInput()
        {

            RegistrationDTO bettaregistration = new();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BETTA FAN REGISTRATION");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWhat is your first name?");
            bettaregistration.fName = Console.ReadLine();

            Console.WriteLine("\nWhat is your last name?");
            bettaregistration.lName = Console.ReadLine();

            Console.WriteLine("\nWhat is your email?");
            bettaregistration.email = Console.ReadLine();

            return bettaregistration;


        }

        public BettaStoriesDTO GetUserInput2()
        {
            BettaStoriesDTO bettastories = new();

            Console.WriteLine("What is your Betta's name?");
            bettastories.nameOfBetta = Console.ReadLine();

            Console.WriteLine("\nPlease share your story?");
            bettastories.story = Console.ReadLine();

            return bettastories;
        }



    }
    
}
