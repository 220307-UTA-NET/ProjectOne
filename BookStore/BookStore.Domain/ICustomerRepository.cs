using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public interface ICustomerRepository
    {
        // CRUD Customer

        /// <summary>
        /// Returns a list of all Customers in the database.
        /// </summary>
        /// <returns> List<Customer> toReturn </returns>
        public List<Customer> GetAllCustomers();

        /// <summary>
        /// Returns the specific Customer matching the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Customer c </returns>
        public Customer GetCustomerByID(int id);

        /// <summary>
        /// Returns the list of Customers matching the given first and last names.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns> List<Customer> toReturn </returns>
        public List<Customer> GetCustomerByName(string first, string last);

        /// <summary>
        /// Adds the given Customer to the database.
        /// </summary>
        /// <param name="c"></param>
        public void AddCustomer(Customer c);

        /// <summary>
        /// Updates the given Customer in the database.
        /// </summary>
        /// <param name="c"></param>
        public void UpdateCustomer(Customer c);

        /// <summary>
        /// Deletes the given Customer from the database.
        /// </summary>
        /// <param name="c"></param>
        public void DeleteCustomer(Customer c);
    }
}
