using StoreApplicationApp.UI.DTOs;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace StoreApplicationApp.UI
{
    public class IO
    {
        //Field
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();


        //Constructors
        public IO(Uri uri) => this.uri = uri;

        //Methods
        public async Task BeginAsync()
        {
            Console.WriteLine("ConsoleApp Running...");
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayAllCustomersAsync();
                        break;
                    case 2:
                        Console.WriteLine("Enter Customer First Name");
                        string? searchString = Console.ReadLine();
                        await DisplayACustomerAsync(searchString);
                        break;
                    case 3:
                        Console.WriteLine("Please give firstname,lastname,phone,product,location,amountspent,Id");
                        await PostACustomerAsync();
                        break;

                }
            } while (loop == true);
        }
        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Please select the option of your choice");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All Customer Information");
            Console.WriteLine("[2] - Get A Customer Information");
            Console.WriteLine("[3] - Add A Customer Information");
            string? input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }
        
        // [TestMethod]

        private async Task DisplayAllCustomersAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Customers");
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
                    Console.WriteLine("Customers: ");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine("Customer FirstName: " + " \t " + customer.firstname + "\t" + "Customer Lastname: " + "\t" + customer.lastname + "\t" + "Phone: " + " \t " + customer.phone
                            + "\t" + "Product: " + "\t" + customer.product + "\t" + "Location: " + "\t" + customer.location + "\t" + "AmountSpent: " + "\t" + customer.amountspent + "\t" + "ID: " + "\t" + customer.ID);
                    }
                }
                else
                {
                    Console.WriteLine("No customers found.");

                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        // [TestMethod]

        private async Task DisplayACustomerAsync(String searchstring)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Customer?id=" + searchstring);
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
                    Console.WriteLine("Customer Records: ");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine("Customer FirstName: " + " \t " + customer.firstname + "\t" + "Customer Lastname: " + "\t" + customer.lastname + "\t" + "Phone: " + " \t " + customer.phone
                            + "\t" + "Product: " + "\t" + customer.product + "\t" + "Location: " + "\t" + customer.location + "\t" + "AmountSpent: " + "\t" + customer.amountspent + "\t" + "ID: " + "\t" + customer.ID);
                    }
                }
                else
                {
                    Console.WriteLine("No customers found.");

                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        // [TestMethod]

        private async Task PostACustomerAsync()
        {
            var customer = new CustomerDTO();
            Console.WriteLine("Enter customer firstname");
            customer.firstname = Console.ReadLine();
            Console.WriteLine("Enter customer lastname");
            customer.lastname = Console.ReadLine();
            Console.WriteLine("Enter customer phone");
            customer.phone = Console.ReadLine();
            Console.WriteLine("Enter customer product");
            customer.product = Console.ReadLine();
            Console.WriteLine("Enter customer location");
            customer.location = Console.ReadLine();
            Console.WriteLine("Enter customer amountspent");
            customer.amountspent = Console.ReadLine();
            Console.Write("Enter customer ID");
            customer.ID = Console.ReadLine();

            var custo = JsonSerializer.Serialize(customer);
            Console.WriteLine(uri.ToString() + "Customer/CreateRecord");
            //Console.WriteLine(custo);
            var request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "Customer/CreateRecord");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(custo, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
       
    }
}
