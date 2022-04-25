using StoreApp0.BusinessLogic;

namespace StoreApp0.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
  
        Task<Customer> GetCustomerById(int id);
        Task<int> CreateCustomer(string firstName, string lastName);



        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<int> CreateProduct(string productName, string productCatagory);
        
    }
}