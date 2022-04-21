using System;
using StoreApplication.UI;

namespace ConsoleApp.app
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            Uri uri = new Uri("https://localhost:7224/");

            IO io = new IO(uri);

            ///**********************************************************************************************///

            await io.displayAllProduct();


            //    // Based on phone number, we will know it is a new customer or an existing customer
            //    Console.WriteLine("WELCOME TO TECHNOLOGY REVOLUTION");

            //    Console.WriteLine("\nThe list of the products available at the store locations\n");
            //    await io.displayAllProduct();

            //    Console.WriteLine("\npress [1] to place orders to store for a customer");
            //    Console.WriteLine("press [2] to search customers by name");
            //    Console.WriteLine("press [3] to display details of an order");
            //    Console.WriteLine("press [4] to display all order history of a store location");
            //    Console.WriteLine("press [5] to display all order history of a customer\n");
            //    Console.Write("Enter a number =>  ");
            //    string str = Console.ReadLine();
            //    int opt = int.Parse(str);
            //    // Declaring an array of integers
            //    int[] opts = { 1, 2, 3, 4, 5 };
            //    //string[] letters = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //    bool isIn = true;

            //    // Input validation
            //    while (!Array.Exists(opts, x => x == opt))
            //    {
            //        Console.Write("Input error. Enter a valid input or press [enter] to exit => ");
            //        str = Console.ReadLine();
            //        if (string.IsNullOrEmpty(str))
            //        {
            //            isIn = false;
            //            break;
            //        }
            //        opt = int.Parse(str);
            //    }



            //    // Switch statement
            //    switch (opt)
            //    {
            //        case 1:
            //            // 1.place orders to store locations for customers
            //            Console.Write("\nEnter your phone number to place an order. => ");
            //            string phoneNumber = Console.ReadLine();

            //            while (!allDigits(phoneNumber))
            //            {
            //                Console.Write("\nInput error. Enter your phone number to place an order. => ");
            //                phoneNumber = Console.ReadLine();
            //            }

            //            // Input validation for phone number

            //            // if the phone number entered is in the database, 
            //            //    place the customer order
            //            await io.placeOrder();

            //            // otherwise,
            //            //   => add the new customer in the database, then place the order
            //            await io.addCustomer(phoneNumber);
            //            await io.placeOrder();
            //            break;

            //        case 2:
            //            await io.searchCustomer();
            //            break;

            //        case 3:
            //            // display order details
            //            await io.displayOrder();
            //            break;

            //        case 4:
            //            // display all order history of a store location
            //            await io.displayOrder("order history of a", "store", "location");
            //            break;

            //        case 5:
            //            await io.displayOrder("order history of a", "customer");
            //            break;
            //    }

            //}


            ///********************** static helper function **********************///
            static bool allDigits(string str)
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
                return true;
            }
        }
    }
}
