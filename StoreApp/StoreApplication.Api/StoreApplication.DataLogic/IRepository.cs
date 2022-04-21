using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApplication.BusinessLogic;


namespace StoreApplication.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<IEnumerable<Customer>> GetCustomer(string firstname);
        Task<IEnumerable<Customer>> AddCustomer(Customer cust);
        Task<IEnumerable<Customer>> DeleteCustomer(string firstname);

    }
}
