using System;
using DemoApp.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json.Serialization;
using System.Text.Json;
using DemoApp.UI.DTOs;

namespace DemoApp.UI
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

        public async Task BeginAsync()
        {
            Console.WriteLine("Welcome to your Bank Management System ");
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
                        continue;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayallCustomers();
                        continue;

                    case 2:
                        Console.WriteLine("Enter your First Name or Last Name or Customer ID to Retreive customer info");
                        string s = Console.ReadLine();
                        
                        await DisplayCustomerInfo(s);
                        continue;

                    case 3:
                        Console.WriteLine("Enter your customer ID to update your address");
                        int custID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your new address to update your answer");
                        string address = Console.ReadLine();
                        await UpdateCustomerAddress(custID, address);
                        continue;

                    case 4:
                        await CreateNewCustomer();
                        continue;

                    case 5:
                        await CreateNewAccount();
                        continue;

                }
            } while (loop == true);
        }


        //Account Methods


        private async Task CreateNewCustomer()
        {
            Console.WriteLine("Please enter your first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter your address");
            string address  = Console.ReadLine();
            Console.WriteLine("Please enter your date of birth");
            string dob = Console.ReadLine();
            int IsVerified = 1;
            int custID = 17;

            CustomerDTO customer = new CustomerDTO(custID, IsVerified, firstName, lastName, address, dob);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + $"api/Customer");
            request.Content = JsonContent.Create(customer);

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine(customer.custFirstName + " " + customer.custLastName + " was added. Enter any key to continue");
                Console.ReadLine();

            }
        }

        //private async Task DoTranaction()
        //{
        //    AccountDTO fromAccount = reateNewAccount();
        //    decimal amount = Decimal.Parse(Console.ReadLine());
        //    TransactionType transactionType = new TransactionType();
        //    transactionType.FromAccount = fromAccount;

            
        //}

        private async Task CreateNewAccount()
        {
            var rand = new Random();
            int random = rand.Next(100, 999);
            Console.WriteLine("Enter the customer's id");
            string input = Console.ReadLine();
            List<CustomerDTO> customer = await DisplayCustomerInfo(input);

            if (customer.Count == 0)
            {
                //Console.WriteLine("No Customer Found!!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please enter your account type, enter 1 for chacking, 2 for saving");
            int accountType = Int32.Parse(Console.ReadLine());


            AccountDTO account = new AccountDTO(random, customer[0].custId, accountType, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy- MM-dd HH:mm:ss"), 1, 0.01M);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + $"api/Account");
            request.Content = JsonContent.Create(account);
            //Console.WriteLine(JsonSerializer.Serialize(request.Content));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine(" new account is registered " + account.accountNumber + " Enter any key to continue");
                Console.ReadLine();

            }

        }



        private async Task<List<CustomerDTO>> DisplayCustomerInfo(string CustomerInfo)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + $"api/Customer/{CustomerInfo}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var customerInfo = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();

                if (customerInfo.Count != 0)
                {
                    Console.WriteLine("customerInfo: ");
                    foreach (var c in customerInfo)
                    {
                        Console.WriteLine("ID: " + c.custId + "\n" + "Name: " + c.custFirstName + " " + c.custLastName + "\n" + "Address: " +c.custAddress + "\n"+ "Date of Birth: " + c.dob + "\n");
                    }
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("No customer found.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                }
                return customerInfo;
            }

        }

        private async Task UpdateCustomerAddress(int custID, string address )
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri.ToString() + $"api/Customer/{custID}/{address}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"Customer address was changed to {address}. Press any key to continue...");
                Console.ReadLine();


            }


        }



        private async Task DisplayallCustomers()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/Customer");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                 List <CustomerDTO> customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();

                if (customers != null)
                {
                    Console.WriteLine("Customers: ");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine( customer.custFirstName + " " + customer.custLastName);
                        
                    }
                }
                else
                {
                    Console.WriteLine("No customer found.");

                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();

        }

        
        
        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Please select the option of your choice:");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All Customers");
            Console.WriteLine("[2] - Get a Customer's Info");
            Console.WriteLine("[3] - Update your address");
            Console.WriteLine("[4] - Add new customer");
            Console.WriteLine("[5] - Create New Account");
           
            string? input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }      
    }
}

