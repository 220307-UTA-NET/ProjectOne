using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public interface IProductRepository
    {
        // CRUD Product

        /// <summary>
        /// Returns the list of all Products in the database.
        /// </summary>
        /// <returns> List<Product> toReturn </returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// Returns the specific Product matching the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Product p </returns>
        public Product GetProductByID(int id);

        /// <summary>
        /// Returns the list of Products matching the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns> List<Product> toReturn </returns>
        public List<Product> GetProductByName(string name);

        /// <summary>
        /// Adds the given Product to the database.
        /// </summary>
        /// <param name="p"></param>
        public void AddProduct(Product p);

        /// <summary>
        /// Updates the given Product in the database.
        /// </summary>
        /// <param name="p"></param>
        public void UpdateProduct(Product p);

        /// <summary>
        /// Deletes the given Product from the database.
        /// </summary>
        /// <param name="p"></param>
        public void DeleteProduct(Product p);
    }
}
