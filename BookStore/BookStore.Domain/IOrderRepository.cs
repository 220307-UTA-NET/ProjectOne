using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public interface IOrderRepository
    {
        // CRUD Order

        /// <summary>
        /// Returns the list of all Orders from the database.
        /// </summary>
        /// <returns> List<Order> toReturn </returns>
        public List<Order> GetAllOrders();

        /// <summary>
        /// Returns the specific Order matching the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Order o </returns>
        public Order GetOrderByID(int id);

        /// <summary>
        /// Returns the list of Orders placed by the Customer matching the given ID.
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns> List<Order> toReturn </returns>
        public List<Order> GetOrdersByCustomerID(int customerID);

        /// <summary>
        /// Returns the list of Orders placed at the Location matching the given ID.
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns> List<Order> toReturn </returns>
        public List<Order> GetOrdersByLocationID(int locationID);

        /// <summary>
        /// Adds the given Order to the database.
        /// </summary>
        /// <param name="o"></param>
        public void AddOrder(Order o);

        /// <summary>
        /// Updates the given Order in the database.
        /// </summary>
        /// <param name="o"></param>
        public void UpdateOrder(Order o);

        /// <summary>
        /// Deletes the given Order from the database.
        /// </summary>
        /// <param name="o"></param>
        public void DeleteOrder(Order o);
    }
}
