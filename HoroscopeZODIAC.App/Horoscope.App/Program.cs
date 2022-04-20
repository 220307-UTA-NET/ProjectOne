using System;
using Horoscope.DataInfrastructure;
using Horoscope.Logic;

namespace Horoscope.App
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=tcp:220307-rev-projects.database.windows.net,1433;Initial Catalog=RevProjects;Persist Security Info=False;User ID=Aure70;Password=FirstBreak7070!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            IRepository repo = new SqlRepository(connectionString);

            Horoscope myHoroscope = new Horoscope(repo);



            {
                Console.WriteLine("Welcome to The Zodiac App!");

                while (true)
                {
                    Console.WriteLine("Please choose a function: ");
                    Console.WriteLine("[1] - Create New Zodiac Client");
                    Console.WriteLine("[2] - Get User's Zodiac Sign");
                    Console.WriteLine("[3] - Date Range List For Each Zodiac");
                    Console.WriteLine("[4] - Capricorn");
                    Console.WriteLine("[5] - Aquarius");
                    Console.WriteLine("[6] - Pisces");
                    Console.WriteLine("[7] - Aries");
                    Console.WriteLine("[8] - Taurus");
                    Console.WriteLine("[9] - Gemini");
                    Console.WriteLine("[10] - Cancer");
                    Console.WriteLine("[11] - Leo");
                    Console.WriteLine("[12] - Virgo");
                    Console.WriteLine("[13] - Libra");
                    Console.WriteLine("[14] - Scorpio");
                    Console.WriteLine("[15] - Sagittarius");
                    Console.WriteLine("[0] - Exit");

                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 0:
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            Console.Clear();
                            return;

                        case 1:
                            CreateNewClient();
                            break;

                        case 2:
                            Zodiac();
                            break;

                        case 3:
                            ZodiacDatesList();
                            break;

                        case 4:
                            Capricorn();
                            break;

                        case 5:
                            Aquarius();
                            break;

                        case 6:
                            Pisces();
                            break;

                        case 7:
                            Aries();
                            break;
                        case 8:
                            Taurus();
                            break;
                        case 9:
                            Gemini();
                            break;
                        case 10:
                            Cancer();
                            break;
                        case 11:
                            Leo();
                            break;
                        case 12:
                            Virgo();
                            break;
                        case 13:
                            Libra();
                            break;
                        case 14:
                            Scorpio();
                            break;
                        case 15:
                            Sagittarius();
                            break;


                        default:
                            Console.WriteLine("Bad input: Input was not a valid option.");
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                }
            }
            void CreateNewClient()
            {

                Console.WriteLine("Enter customer's Zodiac Sign.");
                string ZODIAC_SIGN = Console.ReadLine();

                Console.WriteLine("Enter customer's First Name.");
                string FIRST_NAME = Console.ReadLine();


                Console.WriteLine("Enter customer's Last Name.");
                string LAST_NAME = Console.ReadLine();

                Console.WriteLine("Enter customer's Birthday in month and day format example: Jul-4th");
                string BIRTH_DATE = Console.ReadLine();

                Console.WriteLine("Enter customer cell phone number, example format: 555-555-5555");
                string PHONE_NUMBER = Console.ReadLine();

                Client tmpClient = repo.CreateNewClient(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER);

                Console.WriteLine("Client Added. Success.");

                Console.WriteLine("Press Any Key To Return To Menu. ");
                Console.ReadKey();
                Console.Clear();
            }
            void Zodiac()
            {
                int ID;
                Console.WriteLine("Enter User's ID ex: 1, 2, 3,,,,,10");
                Console.ReadLine();
                ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(repo.GetUserZodiac);



            }
            void ZodiacDatesList()
            {
                Console.WriteLine("Capricorn: Dec-22nd to Jan-19th");
                Console.WriteLine("Aquarius: Jan-20th to Feb-18th");
                Console.WriteLine("Pisces: Feb-19th to Mar-20th");
                Console.WriteLine("Aries: Mar-21st to Apr-19th");
                Console.WriteLine("Taurus: Apr-20th to May-20th");
                Console.WriteLine("Gemini: May-21st to Jun-20th");
                Console.WriteLine("Cancer: Jun-21st to Jul-22nd");
                Console.WriteLine("Leo: Jun-23rd to Aug-22nd");
                Console.WriteLine("Virgo: Aug-23rd to Sep-22nd");
                Console.WriteLine("Libra: Sep-23rd to Oct-22nd");
                Console.WriteLine("Scorpio: Oct-23rd to Nov-21st");
                Console.WriteLine("Sagittarius: Nov-22nd to Dec-21st");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press Any Key To Return To Menu");
                Console.ReadKey();
                Console.Clear();
            }
               
            async Task Capricorn()
            { 
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Capricorn&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);

                   
                }

            }
           

            async Task Aquarius()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Aquarius&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Pisces()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Pisces&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }

            async Task Aries()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Aries&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }

            async Task Taurus()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Taurus&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Gemini()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Gemini&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Cancer()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Cancer&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Leo()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Leo&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Virgo()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Virgo&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Libra()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Libra&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Scorpio()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Scorpio&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            async Task Sagittarius()
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=Sagittarius&day=today"),
                    Headers =
    {
        { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
        { "X-RapidAPI-Key", "299bdbb5c1msh5010e38c5103014p164829jsn4dffd6a8379f" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
        }
    }
}




