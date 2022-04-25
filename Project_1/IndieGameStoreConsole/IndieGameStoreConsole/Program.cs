using IndieGameStore.DataInfrastructure;
using IndieGameStore.Logic;

namespace IndieGameStoreConsole
{
    public class Program
    {

        static void Main()
        {
            Console.WriteLine("Welcome to the Indie Game Store!");
            Console.WriteLine("________________________________");
            MainMenu();
        }
        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("MainMenu:");
                Console.WriteLine("Enter a number");
                Console.WriteLine("[0] - Exit Application");
                Console.WriteLine("[1] - Place an Order");
                Console.WriteLine("[2] - Add New Customer");
                Console.WriteLine("[3] - Add New Game");
                Console.WriteLine("[4] - List All Games");
                Console.WriteLine("[5] - List All Users");
                Console.WriteLine("[6] - List All Orders");

                int? input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Application Closed");
                        break;
                    case 1:
                        Console.WriteLine("__________Place an Order__________");
                        //PlaceOrderMethod():Should give user ability to add an order and it's details to the database
                        PlaceOrder();
                        break;
                    case 2:
                        Console.WriteLine("__________Add New Customer__________");
                        //AddNewCustomerMethod():Should give user the ability to add a new customer and their details to the database
                        AddCustomer();
                        break;
                    case 3:
                        Console.WriteLine("__________Add New Game__________");
                        AddGame();
                        break;
                    case 4:
                        Console.WriteLine("__________List of Games__________");
                        //DatabaseMehod():Should give user the ability to search and make changes to database
                        ListGames();
                        break;
                    case 5:
                        Console.WriteLine("__________List of Users__________");
                        //DatabaseMehod():Should give user the ability to search and make changes to database
                        ListUsers();
                        break;
                    case 6:
                        Console.WriteLine("__________All Orders__________");
                        //DatabaseMehod():Should give user the ability to search and make changes to database
                        ListOrders();
                        break;

                }

            }
        }
        static void ListGames()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            Console.WriteLine("All Avaliable Games");
            IRepository gamerepo = new SqlRepository(connectionString);
            IEnumerable<Game> games = gamerepo.GetAllGames();
            Console.WriteLine("GameID...Game Name...Price");
            foreach (Game game in games)
            { Console.WriteLine(game.GetProductID() + "..." + game.GetName() + "...$" + game.GetPrice()); }
        }
        static void ListUsers()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            Console.WriteLine("All Users");
            IRepository userrepo = new SqlRepository(connectionString);
            IEnumerable<Customer> customers = userrepo.GetAllCustomers();
            Console.WriteLine("CustomerID...UserName");
            foreach(Customer customer in customers)
            { Console.WriteLine(customer.GetID() + "..." + customer.GetUserName()); }
        }
        static void ListOrders()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            Console.WriteLine("All Orders");
            IRepository orderrepo = new SqlRepository(connectionString);
            IEnumerable<Order> orders = orderrepo.GetAllOrders();
            Console.WriteLine("OrderID...UserID...GameID");
            foreach(Order order in orders)
            { Console.WriteLine(order.GetOrderID() + "..." + order.GetCustomerID() + "..." + order.GetProductID());}
        }
        static void AddCustomer()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            Console.WriteLine("Adding Customer...");
            IRepository customerrepo = new SqlRepository(connectionString);
            Customer newcustomer = new Customer();
            Console.WriteLine("Enter a new UserName: ");
            string? userName = Console.ReadLine();
            newcustomer.SetUserName(userName);
            newcustomer = customerrepo.CreateNewCustomer(userName);
            Console.WriteLine(userName + " Was added to users list!");
        }
        static void AddGame()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            Console.WriteLine("Adding Game..."); 
            IRepository gamerepo = new SqlRepository(connectionString);
            Game newgame = new Game();
            Console.WriteLine("Enter name of new Game: ");
            string? gameName = Console.ReadLine();
            newgame.SetName(gameName);
            Console.WriteLine("What is the price? ");
            int gamePrice = int.Parse(Console.ReadLine());
            newgame.SetPrice(gamePrice);
            newgame = gamerepo.CreateNewGame(gameName, gamePrice);
            Console.WriteLine(gameName + " Was added to the list of games and is $" + gamePrice);
        
        }
        static void PlaceOrder()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            IRepository orderrepo = new SqlRepository(connectionString);
            Console.WriteLine("Creating Order...");
            Order NewOrder = new Order();
            Console.WriteLine("Enter the game ID you wish to buy: ");
            int gameID = int.Parse(Console.ReadLine());
            
            NewOrder.GetProductID();
            Console.WriteLine("Enter user ID: ");
            int userID = int.Parse(Console.ReadLine());
            NewOrder.GetCustomerID();
            NewOrder = orderrepo.CreateNewOrder(gameID, userID);
            Console.WriteLine("A new order was placed for user: " + userID + " for game: " + gameID);
            
        }
    }
}
