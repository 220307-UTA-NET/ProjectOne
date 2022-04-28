using System;
using System.Net.Http.Json;
using System.Net.Mime;
using StoreApplication.UI.DTOs;
using System.Text.Json.Serialization;
using System.Text.Json;


namespace StoreApplication.UI
{
    public class IO
    {
        // Fields
        private readonly Uri _uri;
        private static readonly HttpClient httpClient = new HttpClient();

        // Constructor
        public IO(Uri uri)
        {
            this._uri = uri;
        }


        public async Task placeOrder()
        {

        }

        // place order. => add order and customer information in the database
        public async Task placeOrder(string phoneNumber)
        {

        }

        // add a new customer in the customer database
        public async Task addCustomer(string phoneNumber)
        {
            //Customer customer = new Customer("Jackie", "Jane", "240-550");
            var rand = new Random();

            Console.Write("Enter first name => ");
            string fname = Console.ReadLine();
            Console.Write("Enter last name => ");
            string lname = Console.ReadLine();
            Console.Write("Enter the street number and name => ");
            string street = Console.ReadLine();
            Console.Write("Enter the zipcode of the customer => ");
            string zipcode = Console.ReadLine();
            CustomerDTO customer = new CustomerDTO(rand.Next(100, 501), fname, lname, phoneNumber, zipcode);
            //PostCustomer(customer);
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this._uri.ToString() + "Customers");
            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.PostAsJsonAsync(this._uri.ToString() + "Customers", customer))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                // Deserialize the customer from the response body
                var customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();

                if (customers != null)
                {
                    Console.WriteLine("Consumer ID \t Firt Name \t LastName \t Phone Number \t Zipcode\n");
                    foreach (var cust in customers)
                    {
                        Console.WriteLine(cust.CustomerID + "\t" + cust.FirstName + "\t" + cust.LastName
                     + "\t" + cust.PhoneNumber + "\t" + cust.Zipcode);
                    }
                }
                else
                {
                    Console.WriteLine("No customers found.");

                }
            }
        }

        // search customer by name
        public async Task searchCustomer()
        {
            Console.WriteLine("\nSearch a customer by name");
            Console.Write("Enter first name => ");
            string fname = Console.ReadLine();
            Console.Write("Enter last name => ");
            string lname = Console.ReadLine();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + $"Customer/getCustomer/{fname}/{lname}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                if (response.IsSuccessStatusCode)
                {
                    var customer = await response.Content.ReadFromJsonAsync<CustomerDTO>();
                    if (customer != null)
                    {
                        Console.WriteLine("Customer info:" + customer.CustomerID + "\t" + customer.FirstName + "\t" +
                                           customer.LastName + "\t" + customer.PhoneNumber + "\t" + customer.Zipcode);
                    }
                    else { Console.WriteLine("no orders found"); }
                }
            }
        }


        // This method displays details of an order
        public async Task displayOrder()
        {
            Console.WriteLine("\nDISPLAY DETAILS OF AN ORDER");
             bool isIn;
            ProductDTO product;

            Console.Write("Enter the ID of a customer =>  ");
            string str = Console.ReadLine();
            int id;

            do
            {
                // input validation to check for numeric value
                while (!int.TryParse(str, out id))
                {
                    Console.WriteLine("Invalid input.You should only enter a numeric.");
                    Console.Write("Enter the ID of a customer =>  ");
                    str = Console.ReadLine();
                }

                product = await helperFuncOrderDetails(id);

                if (product == null)
                {
                    isIn = false;
                    Console.WriteLine("The customer with the id number " + id.ToString() + " did not make any purchase in any");
                    Console.WriteLine("store locations. Enter another customer id, or press enter to exit");
                    Console.Write("Enter the ID of a customer =>  ");
                    str = Console.ReadLine();
                }
                else
                {
                    isIn = true;
                    str = string.Empty;
                }

            } while (!isIn && (str != string.Empty));

            if (isIn)
            {
                Console.WriteLine("Welcome to Best Technology Store");
                product.toString();
            }
        }


        // display all order history of a customer
        public async Task displayOrder(string str1, string str2)
        {
            Console.WriteLine("\nDISPLAY ALL ORDER HISTORY OF A CUSTOMER");

            bool isIn;
            List<OrderDTO> orders;

            Console.Write("Enter the ID of a customer =>  ");
            string str = Console.ReadLine();
            int id;

            do {
                

                // input validation to check for numeric value
                while (!int.TryParse(str, out id))
                {
                    Console.WriteLine("Invalid input.You should only enter a numeric.");
                    Console.Write("Enter the ID of a customer =>  ");
                    str = Console.ReadLine();
                }

                orders = await helperFuncCustomer(id);

                if (orders.Count <= 0)
                {
                    isIn = false;
                    Console.WriteLine("The customer with the id number " + id.ToString() + " did not make any purchase in any");
                    Console.WriteLine("store locations. Enter another customer id, or press enter to exit");
                    Console.Write("Enter the ID of a customer =>  ");
                    str = Console.ReadLine();
                }
                else { 
                    isIn = true;
                    str = string.Empty;
                }

            } while (!isIn && (str != string.Empty));

            if (isIn)
            {
                foreach (OrderDTO order in orders)
                {
                    Console.WriteLine(order.OrderID + "\t" + order.CustomerID + "\t" + order.ProductID
                                + "\t" + order.Location + "\t" + order.Time);
                }
            }

        }


        // display all orders history of a store location
        public async Task displayOrder(string str1, string str2, string str3)
        {

            int[] opts = { 1, 2, 3, 4, 5 };
            Console.WriteLine("\nDISPLAY ALL ORDER HISTORY OF A STORE LOCATION");

            Console.WriteLine("\npress [1] to display of the store located at 12 Orchestra Terrace Germantown 99362");
            Console.WriteLine("press [2] to display of the store located at 89 Jefferson Way Portland 97201");
            Console.WriteLine("press [3] to display of the store located at 87 Polk St San Francisco 94117");
            Console.WriteLine("press [4] to display of the store located at 722 DaVinci Blvd Kirkland 98034");
            Console.WriteLine("press [5] to display of the store located at 50 Chiro Rd Portland 97219");

            Console.Write("Enter a number between [1], [2], [3], [4] and [5] to point to the name the store =>  ");
            int opt = int.Parse(Console.ReadLine());
            while (!Array.Exists(opts, x => x == opt))
            {
                Console.Write("Input error. Enter a valid input => ");
                opt = int.Parse(Console.ReadLine());
            }

            switch (opt)
            {
                case 1:
                    await helperFuncLocation("12 Orchestra Terrace Germantown 99362");
                    break;

                case 2:
                    await helperFuncLocation("89 Jefferson Way Portland 97201");
                    break;

                case 3:
                    await helperFuncLocation("87 Polk St San Francisco 94117");
                    break;

                case 4:
                    await helperFuncLocation("722 DaVinci Blvd Kirkland 98034");
                    break;

                case 5:
                    await helperFuncLocation("50 Chiro Rd Portland 97219");
                    break;
            }
        }

        public async Task displayAllProduct()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this._uri.ToString() + "Product");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))  /////////////////////////////
            {
                response.EnsureSuccessStatusCode();       /////////////////////////

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                // marker

               var products = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();

                if (products != null)
                {
                    Console.WriteLine("Product ID \t Product type \t Product name \t Quantity \t Price\n");
                    foreach (var product in products)
                    {
                        Console.WriteLine(product.ProductID + "\t" + product.ProductType + "\t" + product.ProductName
                     + "\t" + product.Quantity + "\t" + product.Cost);
                    }
                }
                else
                {
                    Console.WriteLine("No products found.");

                }
            }
        }


        /********************* Helper Functions **********************************/

        // This is a helper function for displayOrder.
        // Display all orders history of a store location.
        private async Task helperFuncLocation (string str)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + $"Order/byCustomer/{str}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
                    if (orders != null)
                    {
                        Console.WriteLine("All order history at " + str.ToString() + ".\n");
                        Console.WriteLine("Order ID \t Customer ID \t Product ID \t Location\t Time");
                        foreach (var order in orders)
                        {
                            Console.WriteLine(order.OrderID + "\t" + order.CustomerID + "\t" + order.ProductID
                                     + "\t" + order.Location + "\t" + order.Time);
                        }
                    }
                    else { Console.WriteLine("no orders found"); }
                }
            }
        }

        // This is a helper function for displayOrder.
        // Display all orders history of a store customer.
        private async Task<List<OrderDTO>> helperFuncCustomer(int id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + $"Order/byCustomer/{id}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            List<OrderDTO>? orderss = null;
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
                    orderss = orders.ToList();
                }
            }
            return orderss;
        }


        // This is a helper function for displayOrder.
        // Display an order details of a customer.
        private async Task<ProductDTO> helperFuncOrderDetails(int id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + $"Order/{id}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            ProductDTO? product = null;
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadFromJsonAsync<ProductDTO>();
                }
            }
            return product;
        }
    }
}