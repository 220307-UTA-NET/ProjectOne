using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public interface IRepository
    {
        //Task<List<Account>>GetAllAccounts();
        //Task<List<Account>> GetTransaction();

        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomer(string input);
        Task AddCustomer(Customer customer);

        //Task<Branch> GetBranch(int id);
        //Task<List<Branch>> GetAllLocations();
        
        Task<List<Transaction>> GetAllTransactions();
        //Task<List<Transaction>> GetTransaction(string input);

        Task<List<Employee>> GetEmployee(string input);
        Task<List<Employee>> GetAllEmployees();

    }
}