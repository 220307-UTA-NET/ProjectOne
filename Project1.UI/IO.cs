using System.Net.Mime;
using System.Net.Http.Json;
using Project1.DTOs;

namespace Project1.UI
{
    public class IO
    {
        //Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        //Constructors

        public IO (Uri uri)
        {
            this.uri = uri;
        }


        //Methods

        public async void BeginAsync()
        {
            Console.WriteLine("Welcome to Kevin Lee's Bank");
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch (choice)
                {
                    
                    case 0:
                        Console.WriteLine("Thank you for using Kevin Lee's Bank. Please come again.");
                        loop = false; break;
                    case 1:
                        await findingInformation();
                        break;
                    case 2:
                        await Register();
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please type the valid input!");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                }
            } while (loop == true);
        }

        private int MainMenu()
        {
            int choice = -1;
            Console.WriteLine("Please select the option of your choice");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Finding information");
            Console.WriteLine("[2] - Register");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }     

        private async Task findingInformation()
        {           
            Console.WriteLine("Select a number which information you want to see.");
            bool searchComplete = false;

            do
            {
                int findingSectionChoice = -1;
                Console.WriteLine("[0] - Back to main menu");
                Console.WriteLine("[1] - User Information");
                Console.WriteLine("[2] - Account Information");

                string? findingSectionInput = Console.ReadLine();

                if (!int.TryParse(findingSectionInput, out findingSectionChoice))
                { findingSectionChoice = -1; }

                switch(findingSectionChoice)
                {
                    case 0:
                        MainMenu();
                        break;

                    case 1:
                        await DisplayAllUsersAsync();
                        break;

                    case 2:
                        await DisplayAllAccountsAsync();
                        break;

                    default:
                        Console.WriteLine("Invalid input! Please type the valid input!");
                        break;
                }

            } while (!searchComplete);            
        }

        private async Task Register()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "/registeruser");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {

            }



        }

        private async Task DisplayAllUsersAsync()
        {
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "getallusers");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
               
                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                
                var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
               
                if (users != null)
                {
                    Console.WriteLine("Users: ");
                    foreach (var user in users)
                    {
                        Console.WriteLine("First Name: " + user.bankUserFirstName);
                        Console.WriteLine("Last Name: " + user.bankUserLastName);
                        Console.WriteLine("Username: " + user.bankUserUsername);
                        Console.WriteLine("Password: " + user.bankUserPassword);
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, this user does not exist in our system");
                }
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }


        private async Task DisplayAllAccountsAsync()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "getallaccounts");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {

                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var accounts = await response.Content.ReadFromJsonAsync<List<AccountDTO>>();

                if (accounts != null)
                {
                    Console.WriteLine("Account: ");
                    foreach (var account in accounts)
                    {
                        Console.WriteLine("UserId: "+ account.bankUserId);
                        Console.WriteLine("Balance: " + account.bankAccountBalance);                        
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, the account does not exist in our system");
                }
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }

    }
}