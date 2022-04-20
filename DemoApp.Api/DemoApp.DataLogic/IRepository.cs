using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public interface IRepository
    {
        //Task<List<Account>>GetAllAccounts();
        //Task<List<Account>> GetAccount(int input);

        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomer(string input);
        Task AddCustomer(Customer customer);
        Task UpdateCustomerAddress(Customer customer);
        Task DeleteCustomer(int CustomerId);

        
        
        Task<List<Transaction>> GetAllTransactions();
        //Task<List<Transaction>> GetTransaction(int input);

        Task<List<Employee>> GetEmployee(string input);
        Task<List<Employee>> GetAllEmployees();


        //Task<Branch> GetBranch(int id);
        //Task<List<Branch>> GetAllLocations();
    }
}