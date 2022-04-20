using System;
using DemoApp.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;

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
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayallCustomers();
                        break;



                }
            } while (loop == true);
        }


        //Account Methods


        private async Task DisplayCustomerInfo(string CustomerInfo)
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

                if (customerInfo != null)
                {
                    Console.WriteLine("customerInfo: ");
                    foreach (var c in customerInfo)
                    {
                        Console.WriteLine(" Name: " + c.custFirstName + c.custLastName);
                    }
                }
                else
                {
                    Console.WriteLine("No customer found.");

                }

            }

        }


        //private async Task DisplayAllCustomers()
        //{
        //    var info = "";



        //}

        private async Task DisplayallCustomers()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Cutomers");
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
                        Console.WriteLine("customer First Name: " + customer.custFirstName);
                        Console.WriteLine("Customer Last Name: " + customer.custLastName);
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

        //private async Task UpdateAccountInfo(AccountDTO account){ }

        //private async Task DeleteAccount(AccountDTO account){ }

        //private async Task UpdateCustomerInfo(CustomerDTO customer) { }

        //private async Task DeleteCustomer(CustomerDTO customer){ }
        
        private int MainMenu()
        {
            int choice = -1;
            Console.WriteLine("Please select the option of your choice:");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All Customers ");
            Console.WriteLine("[2] - Get a Customer's Info");
            Console.WriteLine("[3] - Update your address");
            //Console.WriteLine("[4] - Transfer Money between your accounts");
            string? input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }
           
            

        
    }
}

