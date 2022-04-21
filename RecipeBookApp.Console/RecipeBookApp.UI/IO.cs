
using RecipeBookApp.UI.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeBookApp.UI
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

        // Methods
        public async Task BeginAsync()
        {
            Console.WriteLine("RecipeBook.App.ConApp has started...");
            bool loop = true;

            do
            {
                int option = MainMenu();

                switch (option)
                {
                    case 404:
                        Console.WriteLine("Invalid response.\nPlease press any key and try again.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayAllUsersAsync();
                        break;

                    case 2:
                        await CreateNewUserAcctAsync();
                        Console.WriteLine("Finished case 2.");
                        break;
                    default:
                        Console.WriteLine("maybe over.");
                        break;
                }
            } 
            while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int option;
            Console.WriteLine("Please select from the options below:");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get details for every account.");
            Console.WriteLine("[2] - Create a new account.");
            Console.WriteLine("[3] - ");
            string? input  = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out option))
            { option = 404; }
            return option;
        }


        private async Task DisplayAllUsersAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "userAccount");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));



            using (HttpResponseMessage httpResponse = await httpClient.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var users = await httpResponse.Content.ReadFromJsonAsync<List<UserDTO>>();

                if (users != null)
                {
                    Console.WriteLine("User Accounts:  ");
                    foreach (var user in users)
                    {
                        Console.WriteLine("Username: " + user.Username);
                    }
                }
                else
                {
                    Console.WriteLine("No accounts found. \nPlease press any key to continue.");
                    
                    //Console.
                    Console.ReadLine();
                    
                        //"to be associated with this username. ");
                }
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public async Task CreateNewUserAcctAsync()
        {
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "userAccount");
            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "userAccount");

            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            ////////////////////////

            Console.Write("\nPlease enter your first name:    ");
            string? FirstName = Console.ReadLine(); // maybe put in try-parse

            Console.Write("\nPlease enter you last name:    ");
            string? LastName = Console.ReadLine();

            Console.Write("\nPlease choose a username:    ");  // add method to check against other usernames
            string? Username = Console.ReadLine();

            Console.Write("\nPlease choose a password:    ");  // need to add second input for verification
            string? UserPassword = Console.ReadLine();
            
            var acctInfo = new UserDTO(Username, UserPassword, FirstName, LastName);
            
            List<UserDTO> acctInfoList = new List<UserDTO>();
            acctInfoList.Add(acctInfo);
            
            //Console.WriteLine("The acct into is:    " + acctInfoList);   
            //Console.ReadLine();
////
//            foreach (var user in acctInfoList)
//            {
//                Console.WriteLine(user);
//            }
            HttpResponseMessage Response = await httpClient.PostAsJsonAsync(uri.ToString() + "userAccount", acctInfoList);

            //Console.WriteLine("The Response sent is:    " + Response);
            //Console.ReadLine();

            string response =  Response.Content.ReadAsStringAsync().Result;

            if (response != null)
            {
                Console.WriteLine(response);
            }
            else
            { Console.WriteLine("there is no response");
                Console.ReadLine();
            }
            


            //request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
        }

    }

}