using BettaFishDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;


namespace BettaFishApp.UI
{
    public class IO
    {
        // Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        // Constructors
        public IO(Uri uri)
        {
            this.uri = uri;
        }


        // Methods
        public async Task BeginAsync()
        {
            Console.WriteLine("Welcome to the Betta Fish Information Website!");
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
                        await DisplayGetAllBettaFunFactsAsync();
                        break;
                    case 3:
                        await DisplayWebRegistrationAsync();
                        break;

                }
            } while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Betta Fish Information Website!");
            Console.WriteLine("\nPlease select an option to explore:");
            Console.WriteLine("[0] : Exit");
            Console.WriteLine("[1] : Betta Type");
            Console.WriteLine("[2] : Betta Fun Facts");
            Console.WriteLine("[3] : Register");

            string? input = Console.ReadLine();
            Console.Clear();
            
            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }

        private async Task DisplayGetAllBettaTypeAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/BettaType");
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
                    Console.WriteLine("BETTA TYPES");
                    foreach (var bettatype in bettatypes)
                    {
                        Console.WriteLine("Type: " + bettatype.tailType);
                    }
                }
                else
                {
                    Console.WriteLine("No Betta Type Information Found.");
                }
            }
            Console.WriteLine("\nPress any KEY to return to the MAIN MENU. Thank you..");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task DisplayGetAllBettaFunFactsAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/BettaFunFacts");
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
                    Console.WriteLine("BETTA FUN FACTS");
                    foreach (var bettafunfact in bettafunfacts)
                    {
                        Console.WriteLine("Fun Fact: " + bettafunfact.funFact);
                    }
                }
                else
                {
                    Console.WriteLine("No Betta Fun Fact Found.");

                }
            }
            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task DisplayWebRegistrationAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/Registration");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var registrations = await response.Content.ReadFromJsonAsync<List<RegistrationDTO>>();

                if (registrations != null)
                {
                    Console.WriteLine("Register with us for up to date information on Bettas");
                    foreach (var registration in registrations)
                    {
                        Console.WriteLine("What's your first name?: " + registration.fName);
                        Console.ReadLine();

                        Console.WriteLine("What's your last name?: " + registration.lName);
                        Console.ReadLine();

                        Console.WriteLine("What's your email?: " + registration.email);
                        Console.ReadLine();

                    }
                }
                else
                {
                    Console.WriteLine("You already have an account with us.");

                }
            }
            Console.WriteLine("\nYour account has been created. Thank you.");
            Console.WriteLine("\nPress any key to return to the MAIN MENU. Thank you.");
            Console.ReadLine();
            Console.Clear();
        }



    }
}
