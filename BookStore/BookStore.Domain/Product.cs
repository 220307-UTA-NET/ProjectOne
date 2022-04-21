using System;

namespace BookStore.Domain
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Product(int id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        /// <summary>
        /// An identifier for the Product.
        /// </summary>
        public int ID {get; set;}

        /// <summary>
        /// The name of the Product.
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        /// The price the Product is being sold at.
        /// </summary>
        public decimal Price {get; set;}
    }
}