using ComputerStore.UI.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;

namespace ComputerStore.UI
{
    public class IO
    {
        //Fields
        private readonly Uri uri;
        public static readonly HttpClient httpClient = new HttpClient();
        //Constroctors
        public IO(Uri uri)
        {
            this.uri = uri;
        }

        //Methods

        public async Task BeginAsync()
        {

            Console.WriteLine("The IO is beginning now...!");
            bool loop = true;
            do
            {
                int choic = MainMenu();
                switch (choic)
                {
                    case -1:

                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false;
                        break;
                    case 1:
                        await DisplayAllComputers();
                        break;
                    case 2:
                        await AddComputer();

                        break;
                }
            }
            while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();

            int choice = -1;
            Console.WriteLine("Please Select the Option of Your Choice!");
            Console.WriteLine("[0] - to exit");
            Console.WriteLine("[1] - to get all Computers");
            Console.WriteLine("[2] - to add new Computer");
            Console.WriteLine("[3] - to Delete a Computer");

            string input = Console.ReadLine();
            Console.Clear();


            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }

        private async Task DisplayAllComputers()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Computer_Makes_");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            /* try
               {response = await httpClient.SendAsync(request);}
               catch (HttpRequestException ex)
               {
                   Console.WriteLine(ex.Message);
                   Console.WriteLine("Press any key to continue.");
                   Console.ReadLine();
               }*/

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var Computer_Makes = await response.Content.ReadFromJsonAsync<List<DTOs.ComputerDTO>>();


                Console.WriteLine("Computers: ");
                foreach (var computer in Computer_Makes)
                {
                    Console.WriteLine("Computer Name: " + computer.Name);
                    Console.WriteLine("Computer Type: " + computer.Type_Name);
                    Console.WriteLine("Computer Price: " + computer.Price);
                }
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        private async Task AddComputer()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri.ToString() + "Computer_Makes_");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var Computer_Makes = await response.Content.ReadFromJsonAsync<List<DTOs.ComputerDTO>>();

                string? Computer_Make_Name = "";
                string? Computer_Make_Type = "";
                string? Computer_Make_Price = "";
                string? OS_ID = "";
                string? Type_ID = "";
                Console.WriteLine("What is the Computer Make Name? ");
                Computer_Make_Name = Console.ReadLine();
                Console.WriteLine("What is the Computer Make Type? ");
                Computer_Make_Type= Console.ReadLine();
                Console.WriteLine("What is the Computer Price? ");
                Computer_Make_Price = Console.ReadLine();
                Console.WriteLine("What OS is the Computer? Choose a number:  1- Windows | 2- Mac | 3- Ubuntu");
                OS_ID = Console.ReadLine();
                Console.WriteLine("What is the Type of Computer? Choose a number:  1- Desktop | 2- Laptop");
                Type_ID = Console.ReadLine();

                List<DTOs.ComputerDTO> computerInfo = new List<DTOs.ComputerDTO>();
              //  computerInfo.Add(Computer_Make_Name = "Amin", Computer_Make_Type = "OS", Computer_Make_Price = "1200", OS_ID = "1", Type_ID = "2");
                foreach(DTOs.ComputerDTO computerDTO in Computer_Makes)
                {
                    computerDTO.Name = Computer_Make_Name;
                    computerDTO.Type_Name = Computer_Make_Type;
                    computerDTO.Price = int.Parse(Computer_Make_Price);
                    computerDTO.OS = int.Parse(OS_ID);
                    computerDTO.Type = int.Parse(Type_ID);
                }



            }

        }
    }
}