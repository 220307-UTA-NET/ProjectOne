using Project1.UI.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Project1.UI
{
    public class IO
    {

        private readonly Uri uri;

        public static readonly HttpClient httpclient = new HttpClient();

        public IO (Uri uri)
        {
            this.uri = uri;
        }

        public async Task StartAysnc()
        {
            Console.WriteLine("ConsoleApp Running... \n ");
            Console.WriteLine("Welcome to the NEISO Energy Report!");
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayNEISOAsync();
                        break;
                    case 2:
                        await InsertNEISODataAsync();
                        break;
                    case 3:
                        await UpdateNEISODataAsync();
                        break;
                    case 4:
                        await DeleteNEISODataAsync();
                        break;
                }
            } while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Select an option for the energy report: ");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get NEISO Energy Report");
            Console.WriteLine("[2] - Insert NEISO Energy Data");
            Console.WriteLine("[3] - Update NEISO Energy Data");
            Console.WriteLine("[4] - Delete NEISO Energy Data");
            string? input = Console.ReadLine();
            Console.Clear();
           

            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }

        private async Task DisplayNEISOAsync()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + $"NEISO/Get");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            
            using (HttpResponseMessage response = await httpclient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var energy = await response.Content.ReadFromJsonAsync<List<NEISODTO>>();

                if (energy != null)
                {
                    Console.WriteLine("Energy Report: ");
                    foreach (var report in energy)
                    {
                        Console.WriteLine("*******************");
                        Console.WriteLine("NEISO ID: " + report.NEISO_ID);
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Forcast Date: " + report.Forcast_Date);
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Hour: " + report.Hour);
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Reliability Region: " + report.Reliability_Region);
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Mega Watts: " + report.Mega_Watts);
                        Console.WriteLine("*******************");
                        Console.WriteLine("");
                    }
                }
                else if (energy.Count == 0)
                {
                    Console.WriteLine("No reports found. \n");

                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task InsertNEISODataAsync()
        {
            String allowedNumber = @"^\d+$";
            String allowedRegion = @"^.*[a-zA-Z]";

            DateTime Forcast_Date;
            Forcast_Date = DateTime.Now;

            int Hour;
            string Reliability_Region;
            int MegaWatts;

            Console.WriteLine("Please enter the Hour for the report:  ");
            Hour = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (!Regex.IsMatch($"{Hour}", allowedNumber))
            {
                Console.WriteLine("Please enter a valid Hour. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please enter the Region for the report: ");
            Reliability_Region = Console.ReadLine();
            Console.WriteLine("");
            if (!Regex.IsMatch($"{Reliability_Region}", allowedRegion))
            {
                Console.WriteLine("Please enter a valid Region Name. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please enter the Mega Watts:  ");
            MegaWatts = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (!Regex.IsMatch($"{MegaWatts}", allowedNumber))
            {
                Console.WriteLine("Please enter valid Wattage. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            NEISODTO neiso = new NEISODTO();
            neiso.Forcast_Date = Forcast_Date;
            neiso.Hour = Hour;
            neiso.Reliability_Region = Reliability_Region;
            neiso.Mega_Watts = MegaWatts;

            HttpResponseMessage response = await httpclient.PostAsJsonAsync(uri.ToString() + "NEISO/Post", neiso);
            response.EnsureSuccessStatusCode();
        
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task UpdateNEISODataAsync()
        {
            String allowedNumber = @"^\d+$";
            String allowedRegion = @"^.*[a-zA-Z]";

            int NEISO_ID;
            DateTime Forcast_Date;
            Forcast_Date = DateTime.Now;

            int Hour;
            string Reliability_Region;
            int MegaWatts;

            Console.WriteLine("Please enter the NEISO ID for the energy report: ");
            NEISO_ID = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (!Regex.IsMatch($"{NEISO_ID}", allowedNumber))
            {
                Console.WriteLine("Please enter valid ID. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please enter the Hour for the report:  ");
            Hour = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (!Regex.IsMatch($"{Hour}", allowedNumber))
            {
                Console.WriteLine("Please enter a valid Hour. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please enter the Region for the report: ");
            Reliability_Region = Console.ReadLine();
            Console.WriteLine("");
            if (!Regex.IsMatch($"{Reliability_Region}", allowedRegion))
            {
                Console.WriteLine("Please enter a valid Region Name. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please enter the Mega Watts:  ");
            MegaWatts = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (!Regex.IsMatch($"{MegaWatts}", allowedNumber))
            {
                Console.WriteLine("Please enter valid Wattage. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            NEISODTO neiso = new NEISODTO();
            neiso.NEISO_ID = NEISO_ID;
            neiso.Forcast_Date = Forcast_Date;
            neiso.Hour = Hour;
            neiso.Reliability_Region = Reliability_Region;
            neiso.Mega_Watts = MegaWatts;

            HttpResponseMessage response = await httpclient.PutAsJsonAsync(uri.ToString() + "NEISO/Put", neiso);
            response.EnsureSuccessStatusCode();


            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        private async Task DeleteNEISODataAsync()
        {
            String allowedNumber = @"^\d+$";

            int NEISO_ID;
      
            Console.WriteLine("Please enter the ID for the report:  ");
            NEISO_ID = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (!Regex.IsMatch($"{NEISO_ID}", allowedNumber))
            {
                Console.WriteLine("Please enter valid ID. \n");
                Console.WriteLine("Press any key to continue. \n");
                Console.ReadLine();
                return;
            }

            NEISODTO neiso = new NEISODTO();
            neiso.NEISO_ID = NEISO_ID;

            HttpResponseMessage response = await httpclient.DeleteAsync(uri.ToString() + $"NEISO/Delete/{NEISO_ID}");
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}