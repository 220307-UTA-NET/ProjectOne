using LibraryApp.UI.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;

namespace LibraryApp.UI
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
        public async Task StartAsync()
        {
            Console.WriteLine("Initializing library management tool...");
            bool running = true;
            do
            {
                int menuOpt = Menu();
                switch (menuOpt)
                {
                    case -1:
                        Console.WriteLine("Unrecognized input.\nYou had better try again (press enter).");
                        Console.ReadLine();
                        break;
                    case 0:
                        running = false;
                        break;
                        /*case 1:
                            await CreateNewMember();
                            break;
                        case 2:
                            await LookUpMemberRentals();
                            break;*/
                        case 3:
                            await LookUpAllMemberInfo();
                            break;
                        /*case 4:
                            await LookUpAllBooks();
                            break;
                        case 5:
                            await RentABook;
                            break;
                        case 6:
                            await ViewAllLoans;
                            break;
                        case 7:
                            await ReturnABook;
                            break;*/
                }
            } while (running == true);
        }

        private int Menu()
        {
            Console.Clear();
            int menuOpt = -1;
            Console.WriteLine("Welcome to the Very Local Library Management Tool\nWhat would you like to do" +
                " (select option by entering option number and pressing enter)?\nChoices include:\n1) Create" +
                " new member\n2) Look up member and their rentals by name\n3) Retrieve information of all me" +
                "mbers\n4) Look up all books\n5) Rent a book\n6) View all active rentals\n7) Return a book\n" +
                "0) Exit");
            string? choose = Console.ReadLine();
            Console.Clear();
            if (!int.TryParse(choose, out menuOpt))
            { menuOpt = -1; }
            return menuOpt;
        }

        private async Task LookUpAllMemberInfo()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString + "Members");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                var members = await response.Content.ReadFromJsonAsync<List<MembersDTO>>();
                if (members != null)
                {
                    Console.WriteLine("Members (ID#, first and last name): ");
                    foreach (var member in members)
                    { Console.WriteLine(member.memberID +", "+ member.firstName +" "+ member.lastName); }
                }
                else
                {
                    Console.WriteLine("Error: member table empty.");
                }
            }
            Console.WriteLine("\nAction completed, press the 'any' key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    
    }
}