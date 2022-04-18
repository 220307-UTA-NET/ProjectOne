using System.Net.Mime;
using System.Net.Http.Json;
using Project1.DTOs;
using System.Text.Json;

namespace Project1.UI
{
    public class IO
    {
        //Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        //Constructors

        public IO(Uri uri)
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
                       await RegisterUser(new UserDTO() {bankUserFirstName = "Luke", bankUserLastName  = "Skywalker", bankUserUsername  = "Jedi", bankUserPassword  = "Knight"});
                        break;

                    case 3:
                        await NewAccount(new AccountDTO() { bankAccountBalance = 5000, bankUserId = 5});
                        break;

                    case 4:
                        await UpdateUser(new UserDTO() { bankUserFirstName = "Luke", bankUserLastName = "Skywalker", bankUserUsername = "Jedi", bankUserPassword = "Knight" });
                        break;

                    case 5:
                        await UpdateAccount(new AccountDTO() { bankAccountBalance = 5000, bankUserId = 5 });
                        break;
                    case 6:
                        break;
                    case 7:
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
            Console.WriteLine("[2] - Register User");
            Console.WriteLine("[3] - Make New Account");
            Console.WriteLine("[4] - Update User");
            Console.WriteLine("[5] - Update Account");
            Console.WriteLine("[6] - Delete User");
            Console.WriteLine("[7] - Delete Account");
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

                switch (findingSectionChoice)
                {
                    case 0:
                        MainMenu();
                        searchComplete = true;
                        break;

                    case 1:
                        DisplayAllUsersAsync();
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

        private async Task RegisterUser(UserDTO User)
        {
            var information = "";
            HttpResponseMessage response = httpClient.PostAsJsonAsync(uri.ToString() + "registeruser", User).Result;
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("New user successfully registered");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //var users = JsonSerializer.Deserialize<List<UserDTO>>(information);


            //if (users != null)
            //{
            //    Console.WriteLine("Here are the list of Bank Users: ");
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine("First Name: " + user.bankUserFirstName);
            //        Console.WriteLine("Last Name: " + user.bankUserLastName);
            //        Console.WriteLine("Username: " + user.bankUserUsername);
            //        Console.WriteLine("Password: " + user.bankUserPassword);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Sorry, the user does not exist in our system");
            //}

            //Console.WriteLine("\nPress any key to continue");
            //Console.ReadLine();


        }

        private async Task NewAccount(AccountDTO Account)
        {
            var information = "";
            HttpResponseMessage response = httpClient.PostAsJsonAsync(uri.ToString() + "newaccount", Account).Result;
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("New account successfully registered");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private async Task UpdateUser(UserDTO User)
        {
            var information = "";
            HttpResponseMessage response = httpClient.PutAsJsonAsync(uri.ToString() + "updateuser", User).Result;
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("User Updated Successful");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private async Task UpdateAccount(AccountDTO Account)
        {
            var information = "";
            HttpResponseMessage response = httpClient.PutAsJsonAsync(uri.ToString() + "updateaccount", Account).Result;
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Account Updated Successful");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }



        private void DisplayAllUsersAsync()
        {

            /* HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "getallusers");
             request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

             using (HttpResponseMessage response = await httpClient.SendAsync(request))
             {
                 response.EnsureSuccessStatusCode();

                 if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                 {
                     throw new ArrayTypeMismatchException();
                 }

                 var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();*/

            var information = "";
            HttpResponseMessage response = httpClient.GetAsync(uri.ToString() + "getallusers").Result;
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            var users = JsonSerializer.Deserialize<List<UserDTO>>(information);


            if (users != null)
            {
                Console.WriteLine("Here are the list of Bank Users: ");
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
                Console.WriteLine("Sorry, the user does not exist in our system");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }


        private async Task DisplayAllAccountsAsync()
        {

            /* HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "getallaccounts");
             request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

             using (HttpResponseMessage response = await httpClient.SendAsync(request))
             {

                 response.EnsureSuccessStatusCode();

                 if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                 {
                     throw new ArrayTypeMismatchException();
                 }

                 var accounts = await response.Content.ReadFromJsonAsync<List<AccountDTO>>();*/

            var information = "";
            HttpResponseMessage response = httpClient.GetAsync(uri.ToString() + "getallaccounts").Result;
            if (response.IsSuccessStatusCode)
            {
                information = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            var accounts = JsonSerializer.Deserialize<List<AccountDTO>>(information);

            if (accounts != null)
            {
                Console.WriteLine("Here are the list of Bank Accounts: ");
                foreach (var account in accounts)
                {
                    Console.WriteLine("UserId: " + account.bankUserId);
                    Console.WriteLine("Balance: " + account.bankAccountBalance);
                }
            }
            else
            {
                Console.WriteLine("Sorry, the account does not exist in our system");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }
    }

}
