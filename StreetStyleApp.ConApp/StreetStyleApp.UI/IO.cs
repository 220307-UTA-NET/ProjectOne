using StreetStyleApp.UI.DTOs;
using System;
using System.Net.Http.Json;
using System.Net.Mime;
//using StreetStyleApp.ConApp.DTOs;

namespace StreetStyleApp.UI
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

        public async Task Begin()
        {
            Console.WriteLine("ConsoleApp Running...");
            bool loop = true;

            do 
            {
                int choice = MainMenu();
                switch(choice)
                {
                    case -1:
                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0: 
                        loop = false; break;
                    case 1:
                        await DisplayAllClothes();
                        break;
                    case 2:
                        await AddNewClothes();
                        break;
                }
            } while (loop == true);  
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Please choose an option of your choice: ");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All Clothes");
            Console.WriteLine("[2] - Add Clothes");
            Console.WriteLine("[3] - Delete Clothes");
            string? input = Console.ReadLine();
            Console.Clear();
            if (!int.TryParse(input, out choice))
            {
                choice = -1;
            }
            return choice;
        }

        private async Task DisplayAllClothes()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/Clothes");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            //HttpResponseMessage response;

            //try
            //{
            //    response = await httpClient.GetAsync($"{uri.ToString()}api/Clothes");
            //    Console.WriteLine(response.StatusCode);
            //    var result = response.Content.ReadAsStringAsync().Result;
            //    Console.WriteLine(result);
            //    //response = await httpClient.SendAsync(request);

            //    Console.WriteLine("Press any key to continue.");
            //    Console.ReadLine();
            //}
            //catch (HttpRequestException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("Press any key to continue.");
            //    Console.ReadLine();
            //}


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var clothes = await response.Content.ReadFromJsonAsync<List<ClothesDTO>>();

                if (clothes != null)
                {
                    Console.WriteLine("CLothes: ");
                    foreach (var clo in clothes)
                    {
                        Console.WriteLine("Clothing ID: " + clo.ClothingID);
                        Console.WriteLine("Clohting Item: " + clo.ClothingItem);
                        Console.WriteLine("Clothing Brand: " + clo.ClothingBrand);
                    }
                }
                else
                {
                    Console.WriteLine("No clothes found.");

                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task AddNewClothes()
        {
            bool loop = true;

        }




    }
}