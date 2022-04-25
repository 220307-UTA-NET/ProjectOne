using StoreApp0.BusinessLogic;

namespace StoreApp0.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        //Task<Customer> GetCustomerByName(string Name);
        Task<Customer> GetCustomerById(int id);
        Task<int> CreateCustomer(string firstName, string lastName);



        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<int> CreateProduct(string productName, string productCatagory);
        //Task CreateProduct(string? productName, object productCatagory);
       // Task CreateProduct(object productName, object productCatagory);
    }
}