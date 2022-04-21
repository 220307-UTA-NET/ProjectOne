using System;
using System.Net.Http.Json;
using System.Net.Mime;
using StoreApplication.UI.DTOs;


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

        //public async Task placeOrder()
        //{

        //}

        //public async Task searchCustomer()
        //{
        //    Console.WriteLine("\nSearch a customer by name");
        //    Console.Write("Enter first name => ");
        //    string fname = Console.ReadLine();
        //    Console.Write("Enter last name => ");
        //    string lname = Console.ReadLine();

        //    Customer customer = this.repo.GetCustomer(fname, lname);

        //    if (customer.GetCustomerID() == 0)
        //    {
        //        Console.WriteLine("\nThe customer does not exist");
        //    }
        //    else
        //    {
        //        string str = "";
        //        Console.WriteLine("\nThe customer information");
        //        str += customer.GetCustomerID() + "\t" + customer.GetFirstName() + "\t" + customer.GetLastName();
        //        str += "\t" + customer.GetPhoneNumber() + "\t" + customer.GetZipcode();
        //        Console.WriteLine(str);
        //    }
        //}

        //public async Task displayOrder()
        //{
        //    //Order order = new Order();
        //    Console.WriteLine("\nDisplay details of an order");
        //    Console.Write("Enter a customer ID => ");
        //    int id = int.Parse(Console.ReadLine());
        //    Product product = this.repo.GetOrderDetails(id);
        //    Console.WriteLine(product.getProduct());
        //}

        //// display all order history of a customer
        //public async Task displayOrder(string str1, string str2)
        //{
        //    Console.WriteLine("\nDISPLAY ALL ORDER HISTORY OF A CUSTOMER");
        //    Console.Write("Enter the ID of a customer =>  ");
        //    int id = int.Parse(Console.ReadLine());

        //    IEnumerable<OrderDTO> orders = this.repo.GetAllOrdersCust(id);

        //    HttpResponseMessage response = await httpClient.GetAsync(id);
        //    response.EnsureSuccessStatusCode();

        //    bool isIn = true;
        //    string str;
        //    while (!orders.Any())
        //    {
        //        Console.WriteLine("Invalid customer ID. Enter the ID of a customer");
        //        Console.WriteLine("You may Press [enter] to exit");
        //        str = Console.ReadLine();
        //        if (string.IsNullOrEmpty(str))
        //        {
        //            isIn = false;
        //            break;
        //        }
        //        id = int.Parse(str);
        //        orders = this.repo.GetAllOrdersCust(id);
        //    }
        //    if (isIn == true)
        //    {
        //        foreach (Orders order in orders)
        //        {
        //            Console.WriteLine(order.GetOrderID() + "\t" + order.GetCustomerID() + "\t" + order.GetProductID()
        //                     + "\t" + order.GetLocation() + "\t" + order.GetTime());
        //        }
        //    }
        //}


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

            Console.Write("Enter the name the store =>  ");
            int opt = int.Parse(Console.ReadLine());
            while (!Array.Exists(opts, x => x == opt))
            {
                Console.Write("Input error. Enter a valid input => ");
                opt = int.Parse(Console.ReadLine());
            }

            //IEnumerable<OrdersDTO> orders = null; ;

            switch (opt)
            {
                case 1:
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + "Orders/1");
                    request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

                    using (HttpResponseMessage response1 = await httpClient.SendAsync(request))
                    {
                        response1.EnsureSuccessStatusCode();

                        if (response1.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                        {
                            throw new ArrayTypeMismatchException();
                        }
                        if (response1.IsSuccessStatusCode)
                            {
                               var orders = await response1.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
                                if (orders != null)
                                {
                                    Console.WriteLine("All order history at Orchestra Terrace Germantown 99362\n");
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
                  // HttpResponseMessage response1 = await httpClient.GetAsync("");
                    

                    break;

                case 2:
                    HttpResponseMessage response2 = await httpClient.GetAsync("89 Jefferson Way Portland 97201");
                    response2.EnsureSuccessStatusCode();
                    if (response2.IsSuccessStatusCode)
                    {
                        var orders = await response2.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();

                        if (orders != null)
                        {
                            Console.WriteLine("All order history at 89 Jefferson Way Portland 97201\n");
                            Console.WriteLine("Order ID \t Customer ID \t Product ID \t Location\t Time");
                            foreach (var order in orders)
                            {
                                Console.WriteLine(order.OrderID + "\t" + order.CustomerID + "\t" + order.ProductID
                                         + "\t" + order.Location + "\t" + order.Time);
                            }
                        }
                        else { Console.WriteLine("no orders found"); }
                    }
                    break;

                case 3:
                    HttpResponseMessage response3 = await httpClient.GetAsync("87 Polk St San Francisco 94117");
                    response3.EnsureSuccessStatusCode();
                    if (response3.IsSuccessStatusCode)
                    {
                        var orders = await response3.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();

                        if (orders != null)
                        {
                            Console.WriteLine("All order history at 87 Polk St San Francisco 94117\n");
                            Console.WriteLine("Order ID \t Customer ID \t Product ID \t Location\t Time");
                            foreach (var order in orders)
                            {
                                Console.WriteLine(order.OrderID + "\t" + order.CustomerID + "\t" + order.ProductID
                                         + "\t" + order.Location + "\t" + order.Time);
                            }
                        }
                        else { Console.WriteLine("no orders found"); }
                    }
                    break;

                case 4:
                    HttpResponseMessage response4 = await httpClient.GetAsync("722 DaVinci Blvd Kirkland 98034");
                    response4.EnsureSuccessStatusCode();
                    if (response4.IsSuccessStatusCode)
                    {
                        var orders = await response4.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();

                        if (orders != null)
                        {
                            Console.WriteLine("All order history at 722 DaVinci Blvd Kirkland 98034\n");
                            Console.WriteLine("Order ID \t Customer ID \t Product ID \t Location\t Time");
                            foreach (var order in orders)
                            {
                                Console.WriteLine(order.OrderID + "\t" + order.CustomerID + "\t" + order.ProductID
                                         + "\t" + order.Location + "\t" + order.Time);
                            }
                        }
                        else { Console.WriteLine("no orders found"); }
                    }
                    break;

                case 5:
                    HttpResponseMessage response5 = await httpClient.GetAsync("50 Chiro Rd Portland 97219");
                    response5.EnsureSuccessStatusCode();
                    if (response5.IsSuccessStatusCode)
                    {
                        var orders = await response5.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
                        if (orders != null)
                        {
                            Console.WriteLine("All order history at 50 Chiro Rd Portland 97219\n");
                            Console.WriteLine("Order ID \t Customer ID \t Product ID \t Location\t Time");
                            foreach (var order in orders)
                            {
                                Console.WriteLine(order.OrderID + "\t" + order.CustomerID + "\t" + order.ProductID
                                         + "\t" + order.Location + "\t" + order.Time);
                            }
                        }
                        else { Console.WriteLine("no orders found"); }
                    }
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

        //public void displaySubOrder()
        //{
        //    Product product = new Product();
        //    string str = "";
        //    //str += 
        //}
    }
}