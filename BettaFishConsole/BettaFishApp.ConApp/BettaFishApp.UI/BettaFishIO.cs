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
        private int bTailID { get; set; }
        private string? bDescription { get; set; }


        public static readonly HttpClient httpClient = new HttpClient();
       

        // Constructors
        public BettaFishIO(Uri uri)
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
                        RegistrationDTO bettaregistration = GetUserInput();
                        await DisplayWebRegistrationAsync(bettaregistration);

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
            Console.WriteLine("Please select an option to explore:");
            Console.WriteLine("[0] : Exit");
            Console.WriteLine("[1] : Betta Type");
            Console.WriteLine("[2] : Betta Fun Facts");
            Console.WriteLine("[3] : Register With Us");


            string? input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }

        private async Task DisplayGetAllBettaTypeAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/type");
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
                        Console.WriteLine("\nType-" + bettatype.tail_ID + bettatype.tailType );
              
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

        //left off here
        public void GetBettaDesciption(BettaTypeDTO bettatype)
        {
            bTailID = bettatype.tail_ID;
            bDescription = bettatype.description;
        }

        private async Task DisplayGetAllBettaFunFactsAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "betta/funfacts");
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


        private async Task DisplayWebRegistrationAsync(RegistrationDTO bettaregistration)
        {
        
            using (HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri.ToString() + "betta/registration", bettaregistration))
            {
              
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully Posted.");
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

        public RegistrationDTO GetUserInput()
        {
            RegistrationDTO bettaregistration = new();

            Console.WriteLine("What is your first name?");
            bettaregistration.fName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            bettaregistration.lName = Console.ReadLine();

            Console.WriteLine("What is your email?");
            bettaregistration.email = Console.ReadLine();

            return bettaregistration;

        }

    }
    
}
