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
        public async Task BeginAsync()
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
                        break;*/
                    case 2:
                        Console.WriteLine("Please enter the Member ID # to retreive their rental history.");
                        string? memberInp = Console.ReadLine();
                        int memberID = 0;
                        if (!int.TryParse(memberInp, out memberID))
                        {
                            await LookUpMemberRentalsAsync(memberID);
                        }
                        else Console.WriteLine("Incompatible input");
                        Console.ReadKey();
                        break;
                    case 3:
                        await LookUpAllMemberInfoAsync();
                        break;
                    case 4:
                        await LookUpAllBooksAsync();
                        break;
                    /*case 5:
                        await RentABook;
                        break;
                    case 6:
                        await ViewAllLoans;
                        break;
                    case 7:
                        await ReturnABook;
                        break;*/
                    case 8:
                        Console.WriteLine("What is the member's first name?");
                        string inpFName = Console.ReadLine();
                        Console.WriteLine("What is the member's last name?");
                        string inpLName = Console.ReadLine();
                        await LookUpCustomerInfoAsync(inpFName, inpLName);
                        break;
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
                "8) Look up member account info from name\nj0) Exit");
            string? choose = Console.ReadLine();
            Console.Clear();
            if (!int.TryParse(choose, out menuOpt))
            { menuOpt = -1; }
            return menuOpt;
        }

        private async Task LookUpAllMemberInfoAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "allmembers");
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
                    Console.WriteLine("Members (ID#, full name, phone ): ");
                    foreach (var member in members)
                    { Console.WriteLine(member.memberID +", "+ member.fName +" "+ member.lName +", "+member.phone); }
                }
                else
                {
                    Console.WriteLine("Error: member table empty.");
                }
            }
            Console.WriteLine("\nAction completed, press the 'any' key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        private async Task LookUpAllBooksAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "allbooks");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }
                var books = await response.Content.ReadFromJsonAsync<List<BooksDTO>>();
                if (books != null)
                {
                    Console.WriteLine("Books (ID#, title, author, price of replacement, In (1) or Out (0)): ");
                    foreach (var book in books)
                    { Console.WriteLine(book.bookID + ", " + book.title + ", " + book.author + ", $" + book.price + ", " + book.inOut ); }
                }
                else
                {
                    Console.WriteLine("Error: books table empty.");
                }
            }
            Console.WriteLine("\nAction completed, press the 'any' key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        private async Task LookUpMemberRentalsAsync( int memberID )
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri.ToString() + "userrentals");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            using (HttpResponseMessage resp = await httpClient.SendAsync(request))
            {
                resp.EnsureSuccessStatusCode();
                if (resp.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                { throw new ArrayTypeMismatchException();}
                var rentals = await resp.Content.ReadFromJsonAsync<List<RentalsDTO>>();
                if (rentals != null)
                {
                    Console.WriteLine("Rental ID, member ID, name, book ID, title, rental date, returned date: ");
                    foreach (var rental in rentals)
                    {
                        Console.WriteLine(rental.rentalID + ", " + rental.memberID + ", " + rental.fName + " " + rental.lName + ", " + rental.bookID + ", " + rental.title + ", " + rental.OutDate + ", " + rental.InDate);
                    }
                }
                else
                {
                    Console.WriteLine("Error: rentals table empty.");
                }
            }
        }
        private async Task LookUpCustomerInfoAsync(string inpFName, string inpLName)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "allmembers");
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
                    Console.WriteLine("Members (ID#, full name, phone ): ");
                    foreach (var member in members)
                    {
                        if (member.fName == inpFName && member.lName == inpLName)
                        {
                            Console.WriteLine(member.memberID + ", " + member.fName + " " + member.lName + ", " + member.phone);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: member table empty.");
                }
            }
            Console.WriteLine("\nAction completed, press the 'any' key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
