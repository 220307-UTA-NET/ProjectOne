using IndieGameStore.Logic;



namespace IndieGameStore.DataInfrastructure
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        
        Task<IEnumerable<Game>> GetAllGames();
        

        Task<IEnumerable<Order>> GetAllOrders();

        Task<IEnumerable<Customer>> CreateNewCustomer(string UserName);
        Task<IEnumerable<Game>> CreateNewGame(string Name, int Price);
        Task<IEnumerable<Order>> CreateNewOrder(int CustomerID, int ProductID);
    }
}