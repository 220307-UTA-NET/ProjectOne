using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using MuseumConsole.DTOs;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;

namespace Museum.UI
{

    public class IO
    {
        //Feilds
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();
        //Constructors
        public IO (Uri uri)
        {
            this.uri = uri;
        }

        //methods
        public async Task BeginAsync()
        {
            Console.WriteLine("app    running");
            bool loop = true;

            do {
                int choice = MainMenu();
                switch(choice)
                {
                    case -1:
                        Console.WriteLine("Bad input, please try again");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayAllPersonsAsync();
                        break;
                    case 2:
                        await DisplayPersonAsync();
                        break;
                    case 3:
                        await CreatePersonAsync();
                        break;
                    case 4:
                        await DeletePersonAsync();
                        break;

                }
            } while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            
            Console.WriteLine("Plse select the option of your choice");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All People");
            Console.WriteLine("[2] - Get a person ");
            Console.WriteLine("[3] - Create a person ");
            Console.WriteLine("[4] - Delete a person ");
            string? input = Console.ReadLine();
            Console.Clear();
            if (!int.TryParse(input, out choice))
            {
                choice = -1 ;
            }
            
            return choice;
        }

        private async Task DisplayAllPersonsAsync()
        {
        
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "lee");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));



            //try
            //{
            //    response = await httpClient.SendAsync(request);

            //}

            //catch (HttpRequestException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("Press any key to continue.");
            //    Console.ReadLine();
            //}


            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();

                }

                var persons = await response.Content.ReadFromJsonAsync<List<PersonDTO>>();




                if (persons != null)
                {
                    foreach (var person in persons)
                    {
                        Console.WriteLine("Person ID Number: " + person.Id);
                        Console.WriteLine("Person Firstname: " + person.FirstName);
                        Console.WriteLine("Person Lastname: " + person.Lastname);
                        Console.WriteLine("Person Salary: " + person.Salary);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No persons found.");
                }
            }

            Console.WriteLine("\n Press any key to continue.");
            Console.ReadLine();

            Console.Clear();

        }

       //public async Task<List<RoomDTO>> GetRooms(int[] adjRoomIDs)
       //{
       //         var information = "";

       //         HttpResponseMessage response = await client.GetAsync($"room/adjacent?roomIDs={adjRoomIDs[0]}&roomIDs={adjRoomIDs[1]}&roomIDs={adjRoomIDs[2]}");
       //         if (response.IsSuccessStatusCode)
       //         {
       //             information = response.Content.ReadAsStringAsync().Result;
       //         }
       //         else
       //         {
       //             Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
       //         }
       //         List<RoomDTO> otherRooms = JsonSerializer.Deserialize<List<RoomDTO>>(information);
       //         return otherRooms;
       //}
            
        private async Task DisplayPersonAsync()
        {


            var information = "";
          

            Console.WriteLine("Input  First name of person");
            var FirstName = Console.ReadLine();

            while (string.IsNullOrEmpty(FirstName))
            {
                Console.WriteLine("Name can't be empty! Input First name once more");
                FirstName = Console.ReadLine();
            }

            Console.WriteLine("Input  Last name of person");
            var LastName = Console.ReadLine();

            while (string.IsNullOrEmpty(LastName))
            {
                Console.WriteLine("Name can't be empty! Input Last name once more");
                LastName = Console.ReadLine();
            }



            HttpResponseMessage response = await httpClient.GetAsync(uri.ToString() + $"Person?FirstName={FirstName}&LastName={LastName}");
            {
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    information = response.Content.ReadAsStringAsync().Result;

                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                List<PersonDTO> persons = JsonSerializer.Deserialize<List<PersonDTO>>(information);




                if (persons != null)
                {
                    foreach (var person in persons)
                    {
                        Console.WriteLine("Person Firstname: " + person.FirstName);
                        Console.WriteLine("Person Salary: " + person.Salary);
                    }
                }
                else
                {
                    Console.WriteLine("No persons found.");
                }
            }
            Console.WriteLine("\n Press any key to continue.");
            Console.ReadLine();

            Console.Clear();

        }

        private async Task CreatePersonAsync()
        {
            PersonDTO testperson = new PersonDTO();
            testperson.FirstName = "Larry";
            testperson.Lastname = "Flynt";
            testperson.Salary = 23442;
            testperson.VisitList = 456;

            Console.WriteLine("Input  First name of person");
            var FirstName = Console.ReadLine();

            while (string.IsNullOrEmpty(FirstName))
            {
                Console.WriteLine("Name can't be empty! Input First name once more");
                FirstName = Console.ReadLine();
            }

            Console.WriteLine("Input  Last name of person");
            var LastName = Console.ReadLine();

            while (string.IsNullOrEmpty(LastName))
            {
                Console.WriteLine("Name can't be empty! Input Last name once more");
                LastName = Console.ReadLine();
            }

            Console.WriteLine("Input  Salary of person");
            var Salary = Console.ReadLine();

            while (string.IsNullOrEmpty(Salary))
            {
                Console.WriteLine("Salary can't be empty! Input Last Salary once more");
                Salary = Console.ReadLine();
            }

            Console.WriteLine("Input  VisitList of person");
            var VisitList = Console.ReadLine();

            while (string.IsNullOrEmpty(VisitList))
            {
                Console.WriteLine("Visit List can't be empty! Input Last Visit List once more");
                VisitList = Console.ReadLine();
            }

            testperson.FirstName = FirstName;
            testperson.Lastname = LastName;
            testperson.Salary = Int32.Parse(Salary);
            testperson.VisitList = Int32.Parse(VisitList);

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri.ToString() + "Person", testperson);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                string idnumber = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("the id number of this new person is " + idnumber); 
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


        }

        private async Task DeletePersonAsync()
        {
            string id = "";

            Console.WriteLine("Input  Id number of person to be deleted");
            var idnumber = Console.ReadLine();

            while (string.IsNullOrEmpty(idnumber))
            {
                Console.WriteLine("Name can't be empty! Input Id number once more");
                idnumber = Console.ReadLine();
            }

            id = idnumber.ToString();

            HttpResponseMessage response = await httpClient.DeleteAsync(uri.ToString() + "Person?" + $"Id={id}");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
              
                Console.WriteLine($"the person with id number {id} is deleted.");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
