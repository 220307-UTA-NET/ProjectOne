using IndieGameStoreConsole2.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace IndieGameApp.UI
{
    public class IO
    {
        //Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        //Constructors
        public IO(Uri uri)
        { this.uri = uri; }
        //Methods

        public async Task Begin()
        {
            Console.WriteLine("Welcome to the Indie Game Store!");
            bool loop = true;
            do
            {
                int choice = MainMenu();
                switch (choice)
                {
                    case -1:
                        loop = true;
                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Program Closed!");
                        loop = false; break;
                    case 1:
                        await GetAllCustomers();
                        break;
                    case 2:
                        await GetAllGames();
                        break;
                    case 3:
                        await GetAllOrders();
                        break;
                    case 4:
                        Console.WriteLine("Method is not ready");
                        await CreateNewCustomer();
                        break;
                    case 5:
                        Console.WriteLine("Method is not ready");
                        break;
                    case 6:
                        Console.WriteLine("Method is not ready");
                        break;
                }
            }
            while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Enter a number: ");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get all Customers");
            Console.WriteLine("[2] - Get all Games");
            Console.WriteLine("[3] - Get all Orders");
            Console.WriteLine("[4] - Create new customer");
            Console.WriteLine("[5] - Create new game");
            Console.WriteLine("[6] - Create new order");
            string? input = Console.ReadLine();
            Console.Clear();
            if (!int.TryParse(input, out choice))
            {
                choice = -1;
            }
            return choice;
        }

        private async Task GetAllCustomers()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Customer");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();

                if (customers != null)
                {
                    Console.WriteLine("UserID...UserName ");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer.CustomerID + "..." + customer.UserName);
                    }

                }
                else
                {
                    Console.WriteLine("No Users found.");

                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private async Task GetAllGames()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Games");
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
                    Console.WriteLine("GameID...Game...Price ");
                    foreach (var game in games)
                    {
                        Console.WriteLine(game.ProductID + "..." + game.Name + "...$" + game.Price);
                    }

                }
                else
                {
                    Console.WriteLine("No Users found.");

                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private async Task GetAllOrders()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Orders");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var orders = await response.Content.ReadFromJsonAsync<List<OrderDTO>>();

                if (orders != null)
                {
                    Console.WriteLine("OrderID...UserID...GameID ");
                    foreach (var order in orders)
                    {
                        Console.WriteLine(order.OrderID + "..." + order.customerID + "..." + order.productID);
                    }

                }
                else
                {
                    Console.WriteLine("No Users found.");

                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private async Task CreateNewCustomer()
        {
            Console.WriteLine("Enter UserName of new custoemr");
            string? userinput = Console.ReadLine();

            var newcustomer = new CustomerDTO()
            {
                UserName = userinput,
            };
            

            var json = JsonSerializer.Serialize(newcustomer);

            
            /*var request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "Customer");
            request.Headers.Accept.Add(new (MediaTypeNames.Application.Json));
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new (MediaTypeNames.Application.Json); */
            
            var requestContent = new StringContent(json, Encoding.UTF8,"application/json");
            


            try
            {
                
                var response = await httpClient.PostAsync(uri.ToString() + "Customer", requestContent);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var createdCustomer = JsonSerializer.Deserialize<CustomerDTO>(content);
                //response = await httpClient.PostAsync(uri.ToString() + "Customer", requestContent);
                Console.WriteLine(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();

        }
    }
}