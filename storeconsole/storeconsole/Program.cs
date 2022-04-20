using System;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using storeconsole.information;

namespace storeconsole
{

    class program


    {

        public static readonly HttpClient httpClient = new HttpClient();

        static int storeid1;

        public static List<status> statusList = new List<status>();


        public program() { }

        static async Task Main()
        {
            Uri uri = new Uri("https://christianspizza.azurewebsites.net");


            program program = new program();
            Console.Clear();
            Console.WriteLine("\n\nWELCOME DEAR CUSTOMER TO PIZZA'S CHRISTIAN  !!!!!");
            Console.WriteLine("\n Plase, select your nearest location  ");
            string storelocation_options = @"  

                [1] PIZZA'S CHRISTIAN  (NORTH DALLAS) 
                [2] PIZZA'S CHRISTIAN  (SOUTH DALLAS) 
                


                                    ";
            Console.WriteLine(storelocation_options);
            string[] arraylist_storelocation_options = { "", "PIZZA'S CHRISTIAN  (NORTH DALLAS)", "PIZZA'S CHRISTIAN  (SOUTH DALLAS)" };
            int storeid1 = int.Parse(Console.ReadLine());
            string storeid_selection = arraylist_storelocation_options[storeid1];

            Console.Clear();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string storeid2 = storeid1.ToString();


            HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "status");
            request2.Content = new StringContent(storeid2, Encoding.UTF8, "application/json");
            request2.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            int mashrooms = 0;
            int storeid3 = 0;
            int pineapples = 0;
            int salalmi = 0;
            int chicken = 0;
            int chessee = 0;
            using (HttpResponseMessage response = await httpClient.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                var status1 = await response.Content.ReadFromJsonAsync<List<status>>();
                foreach (var st in status1)
                {
                    storeid3 = st.storeid;
                    mashrooms = st.mashrooms;
                    pineapples = st.pineapples;
                    salalmi = st.salalmi;
                    chicken = st.chicken;
                    chessee = st.chessee;

                }
            }
            var inventory = new status(storeid3, mashrooms, pineapples, salalmi, chicken, chessee);
            statusList.Add(inventory);

            while (true)
            {


                Console.Clear();
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine($"WELCOME DEAR CUSTOMER TO {storeid_selection} !!!!!");
                Console.WriteLine("\n Please, select your role:  ");
                string roles = @"  

                [0] CUSTOMER    
                [1] CORPORATE
                [2] EXIT



                                    ";
                Console.WriteLine(roles);
                string[] roleslist = { "CUSTOMER", "CORPORATE" };
                int answer = int.Parse(Console.ReadLine());
                string Itemselected = roleslist[answer];


                switch (answer)
                {

                    case 0:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine($"Dear {Itemselected}, do you have and account with us ?(y/n)\n\n");
                            try
                            {
                                char ans1 = char.Parse(Console.ReadLine());
                                if (ans1.Equals('n'))
                                {

                                    Console.WriteLine("Hi my name is Andrea and I will help you to register. Please , type your name.\n");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Please , type your lastname.\n");
                                    string lastname = Console.ReadLine();

                                    var customer = new listcustomers(name, lastname);

                                    List<listcustomers> customers = new List<listcustomers>();
                                    customers.Add(customer);
                                    HttpResponseMessage Response = await httpClient.PostAsJsonAsync(uri.ToString() + "customers", customers);
                                    string result = Response.Content.ReadAsStringAsync().Result;
                                    Console.WriteLine(result);
                                    HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "customers");
                                    string object1 = JsonSerializer.Serialize<List<listcustomers>>(customers);
                                    request1.Content = new StringContent(object1, Encoding.UTF8, "application/json");
                                    int result1 = 0;
                                    using (HttpResponseMessage response = await httpClient.SendAsync(request1))
                                    {
                                        response.EnsureSuccessStatusCode();
                                        result1 = await response.Content.ReadFromJsonAsync<int>();
                                    }
                                    Console.WriteLine($"Dear {Itemselected}, you have been registered. Welcome to our Family!!!! From now,  your customer ID is {result1}. \n\n");
                                    Console.WriteLine("press any key to continue ");
                                    Console.ReadLine();
                                    continue;
                                }
                                if (ans1.Equals('y'))
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Dear {Itemselected}, please your customer ID \n");
                                    try
                                    {
                                        string customerid = Console.ReadLine();
                                        HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "customerid");
                                        request1.Content = new StringContent(customerid, Encoding.UTF8, "application/json");
                                        request1.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
                                        string customer_name = "";
                                        string customer_lastname = "";
                                        using (HttpResponseMessage response = await httpClient.SendAsync(request1))
                                        {
                                            response.EnsureSuccessStatusCode();

                                            var customer = await response.Content.ReadFromJsonAsync<List<listcustomers>>();

                                            foreach (var item in customer)
                                            {
                                                customer_name = item.name;
                                                customer_lastname = item.lastname;
                                                Console.WriteLine($"Welcome {item.name} {item.lastname}, here is our Menu options");
                                                Console.WriteLine("press any key to continue ");
                                                Console.ReadLine();

                                            }
                                        }

                                        int[] menu = await program.menu();
                                        int number_of_pieces = menu[0];
                                        Console.Clear();
                                        Console.WriteLine($"\n\n{customer_name}, you have selected {number_of_pieces} pieces. Your Total is ${number_of_pieces * 5}  ");
                                        Console.WriteLine("press any key to continue ");
                                        Console.ReadLine();

                                        var orders = new List<pizzaorders>();
                                        orders.Add(new pizzaorders(customer_name, customer_lastname, storeid1, DateTime.Now, customerid, number_of_pieces));
                                        Console.WriteLine(storeid1);
                                        HttpResponseMessage Response = await httpClient.PostAsJsonAsync(uri.ToString() + "pizzaorders", orders);
                                        string result = Response.Content.ReadAsStringAsync().Result;
                                        if (menu[1] == 1)
                                        {
                                            var inventory_mashrooms = new status(storeid1, -number_of_pieces * 2, 0, 0, -number_of_pieces * 2, -number_of_pieces * 2);
                                            statusList.Add(inventory_mashrooms);
                                        }
                                        if (menu[1] == 2)
                                        {
                                            var inventory_HAWAIIAN = new status(storeid1, 0, -number_of_pieces * 2, -number_of_pieces * 2, 0, -number_of_pieces * 2);
                                            statusList.Add(inventory_HAWAIIAN);
                                        }
                                        HttpResponseMessage updating_inventory = await httpClient.PostAsJsonAsync(uri.ToString() + "status", statusList);
                                        string updating_invantory_result = Response.Content.ReadAsStringAsync().Result;

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("bad input");
                                        Console.WriteLine("press any key to continue ");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("bad in input, please try again !!!!");
                                    Console.WriteLine("press any key to continue ");
                                    Console.ReadLine();
                                }

                            }

                            catch (Exception n1)
                            {
                                Console.WriteLine("bad input, please be serious !!!!!");
                                Console.WriteLine("press any key to continue ");
                                Console.ReadLine();
                                continue;
                            }


                        }



                        break;

                    case 1:

                        Console.WriteLine("checking inventory !!!!!!!");
                        Console.WriteLine("store number ?");
                        string storeid = Console.ReadLine();
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "status");
                        request.Content = new StringContent(storeid, Encoding.UTF8, "application/json");
                        request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
                        using (HttpResponseMessage response = await httpClient.SendAsync(request))
                        {
                            response.EnsureSuccessStatusCode();
                            if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                            {
                                throw new ArrayTypeMismatchException();
                            }

                            var status1 = await response.Content.ReadFromJsonAsync<List<status>>();
                            if (status1 != null)
                            {
                                Console.WriteLine("my current inventory is:");
                                foreach (var st in status1)
                                {
                                    Console.WriteLine($"storeid: {st.storeid}  mashrooms: {st.mashrooms}  pineapples: {st.pineapples}  salalmi: {st.salalmi} chicken: {st.chicken} chessee: {st.chessee}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No devices found.");

                            }

                            break;
                        }




                }

                Console.WriteLine("\n\nDo you need to do something else ?(y/n)");
                char c = char.Parse(Console.ReadLine());
                if (c.Equals('y')) { continue; }
                else { break; }





            }



        }
        public async Task<int[]> menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("From the following options what kind of pizza would you like to order?");
                string Inventory = @"  

                 
                                [1] MUSHROOM PIZZA 
                                [2] HAWAIIAN PIZZA 
                                [3] EXIT



                                                   ";
                Console.WriteLine(Inventory);
                int answer = int.Parse(Console.ReadLine());
                if (answer == 1 || answer == 2 || answer == 3)
                {
                    switch (answer)
                    {
                        case 1:

                            Console.WriteLine($"mushroom pizza price : $5 ");
                            Console.WriteLine("how pieces you want ?\n");
                            try
                            {
                                int mashrooms = 0;
                                foreach (var item in statusList) { mashrooms = item.mashrooms; }
                                int number_of_pieces = int.Parse(Console.ReadLine());
                                if ((mashrooms / 2) > number_of_pieces)
                                {
                                    int[] menu = { number_of_pieces, answer };
                                    return menu;
                                }
                                else
                                {
                                    Console.WriteLine("we dont have enough ingredients to have your order ready!!!!!!!. Try again !!!");
                                    Console.ReadLine();
                                    continue;
                                }

                            }
                            catch (Exception l)
                            {

                                Console.WriteLine("Bad input, press any key to continue ");
                                Console.ReadLine();
                                continue;
                            }
                            break;

                        case 2:
                            Console.WriteLine("hawaiian pizza price : $5");
                            Console.WriteLine("how pieces you want ?\n");
                            try
                            { //////////////////////////////////////////////////////////////////////////
                                int HAWAIIAN = 0;
                                foreach (var item in statusList) { HAWAIIAN = item.pineapples; }
                                int number_of_pieces = int.Parse(Console.ReadLine());
                                if ((HAWAIIAN / 2) > number_of_pieces)
                                {
                                    int[] menu = { number_of_pieces, answer };
                                    return menu;
                                }
                                else
                                {
                                    Console.WriteLine("we dont have enough ingredients to have your order ready!!!!!!!. Try again !!!");
                                    Console.ReadLine();
                                    continue;
                                }


                                //////////////////////////////////////////////////////////////////////////

                            }
                            catch (Exception l)
                            {

                                Console.WriteLine("Bad input, press any key to continue ");
                                Console.ReadLine();
                                continue;
                            }
                            break;
                        case 3:
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("wrong input");
                    Console.WriteLine("press any key to continue ");
                    Console.ReadLine();
                    continue;
                }

            }


        }

    }




}