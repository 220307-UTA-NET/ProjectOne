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
                    case 3:
                        await DeleteClothes();
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
            int newClothingID = 0;
            string newClothingItem = "";
            string newClothingBrand = "";
            // Create an ID
            bool loop = true;
            do
            {
                Console.WriteLine("Enter an ID: ");
                string Input = Console.ReadLine();

                if (Int32.Parse(Input) == 0)
                {
                    Console.WriteLine("ID cannot be 0. Input another ID.");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("ID added!");
                    newClothingID = Convert.ToInt32(Input);
                    Console.ReadLine();
                    loop = false;
                }
                Console.Clear();

            } while (loop == true);

            bool loop2 = true;
            do
            {
                Console.WriteLine("Enter a Clothing Item: ");
                newClothingItem = Console.ReadLine();

                if (newClothingItem == null)
                {
                    Console.WriteLine("Enter a valid clothing item.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Clothing item added!");
                    Console.ReadLine();
                    loop2 = false;
                }
            } while (loop2 == true);
            Console.Clear();

            bool loop3 = true;
            do
            {
                Console.WriteLine("Enter a Clothing Brand: ");
                newClothingBrand = Console.ReadLine();

                if (newClothingBrand == null)
                {
                    Console.WriteLine("Enter a valid clothing Brand.");
                }
                else
                {
                    Console.WriteLine("Clothing Brand added!");
                    Console.ReadLine();
                    loop3 = false;
                }
            } while (loop3 == true);
            Console.Clear();

            //HttpResponseMessage response;

            //try
            //{
            //    response = await httpClient.GetAsync($"{uri.ToString()}api/Clothes");
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/AddClothes");
            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            await HttpPost(new ClothesDTO()
            {
                ClothingID = newClothingID,
                ClothingItem = newClothingItem,
                ClothingBrand = newClothingBrand
            });
        }

        public async Task HttpPost(ClothesDTO newClothingDTO)
        {
            using (HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{uri.ToString()}api/AddClothes", newClothingDTO))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                else
                {
                    Console.WriteLine("Error!");
                }

                //var clothes = await response.Content.ReadFromJsonAsync<List<ClothesDTO>>();

                //if (clothes != null)
                //{
                //    Console.WriteLine("CLothes: ");
                //    foreach (var clo in clothes)
                //    {
                //        Console.WriteLine("Clothing ID: " + clo.ClothingID);
                //        Console.WriteLine("Clothing Item: " + clo.ClothingItem);
                //        Console.WriteLine("Clothing Brand: " + clo.ClothingBrand);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("No clothes found.");

                //}
                Console.WriteLine("\nNew clothes has been created!");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private async Task DeleteClothes()
        {
            int ClothingID = 0;
            bool loop = true;
            do
            {
                Console.WriteLine("Enter a Clothing ID: ");
                ClothingID = Int32.Parse(Console.ReadLine());

                if (ClothingID == null)
                {
                    Console.WriteLine("Enter a valid clothing ID.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Clothing item deleted!");
                    Console.ReadLine();
                    loop = false;
                }
            } while (loop == true);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri.ToString() + $"api/DeleteClothes?ID={ClothingID}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
            }
        }
    }
}