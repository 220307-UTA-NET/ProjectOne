using StoreApp0.BusinessLogic;

namespace StoreApp0.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        //Task<Customer> GetCustomerByName(string Name);
        Task<Customer> GetCustomerById(int id);
        Task<int> CreateCustomer(string firstName, string lastName);
    }
}