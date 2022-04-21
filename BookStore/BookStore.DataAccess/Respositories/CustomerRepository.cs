using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookStore.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookStoreDbContext _context;
        public CustomerRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        // CRUD Customer

        /// <summary>
        /// Returns the list of all Customers in the database.
        /// </summary>
        /// <returns> List<Customer> list </returns>
        public List<Domain.Customer> GetAllCustomers()
        {
            var x = _context.Set<Customer>().AsEnumerable();
            List<Domain.Customer> list = new List<Domain.Customer>();

            foreach (var i in x)
            {
                var c = new Domain.Customer(i.FirstName, i.LastName, (int)i.DefaultLocationId) { ID = i.Id };
                list.Add(c);
            }

            return list;
        }

        /// <summary>
        /// Returns a specific Customer with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Customer x </returns>
        public Domain.Customer GetCustomerByID(int id)
        {
            var c = _context.Set<Customer>().Find(id);
            var x = new Domain.Customer(c.FirstName, c.LastName) { ID = c.Id, FirstName = c.FirstName, LastName = c.LastName, DefaultLocationID = (int)c.DefaultLocationId };

            return x;
        }

        /// <summary>
        /// Returns a list of Customers that have the given first and last name.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns> List<Customer> toReturn </returns>
        public List<Domain.Customer> GetCustomerByName(string first, string last)
        {
            var customers = _context.Set<Customer>().Where(x => x.FirstName == first && x.LastName == last).ToList();
            List<Domain.Customer> toReturn = new List<Domain.Customer>();

            foreach (var c in customers)
            {
                var x = new Domain.Customer(c.Id, c.FirstName, c.LastName, (int)c.DefaultLocationId);
                toReturn.Add(x);
            }

            return toReturn;
        }

        /// <summary>
        /// Adds the given Customer as a new Customer to the database.
        /// </summary>
        /// <param name="c"></param>
        public void AddCustomer(Domain.Customer c)
        {
            Customer entity = new Customer() { FirstName = c.FirstName, LastName = c.LastName, DefaultLocationId = c.DefaultLocationID };
            _context.Set<Customer>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the given Customer in the database.
        /// </summary>
        /// <param name="c"></param>
        public void UpdateCustomer(Domain.Customer c)
        {
            var entity = _context.Customers.SingleOrDefault(x => x.Id == c.ID);
            if (entity != null)
            {
                entity.FirstName = c.FirstName;
                entity.LastName = c.LastName;
                entity.DefaultLocationId = c.DefaultLocationID;
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the given Customer from the database.
        /// </summary>
        /// <param name="c"></param>
        public void DeleteCustomer(Domain.Customer c)
        {
            var entity = _context.Customers.SingleOrDefault(x => x.Id == c.ID);
            if (entity != null)
            {
                _context.Set<Customer>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
