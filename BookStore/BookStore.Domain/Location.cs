using System.Collections.Generic;

namespace BookStore.Domain
{
    public class Location
    {
        public Location()
        {
            Inventory = new Dictionary<Product, int>();
        }

        public Location(int id)
        {
            Inventory = new Dictionary<Product, int>();
            ID = id;
        }

        public Location(string name)
        {
            Name = name;
            Inventory = new Dictionary<Product, int>();
        }

        /// <summary>
        /// An identifier for the Location.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the Location.
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        /// The inventory of products at the Location, where the key is the Product and the value is the amount of that Product in stock.
        /// </summary>
        public Dictionary<Product, int> Inventory { get; set; }

        /// <summary>
        /// Sets the amount of a Product in the inventory based on the given Product object.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="amount"></param>
        /// <returns> bool indicating success or failure </returns>
        public bool SetProductAmount(Product p, int amount)
        {
            if (p == null || amount < 0) 
            {
                return false;
            }
            
            Inventory[p] = amount;
            return true;
        }

        /// <summary>
        /// Sets the amount of a Product in the inventory based on the given Product ID.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="amount"></param>
        /// <returns> bool indicating success or failure </returns>
        public bool SetProductAmount(int productID, int amount)
        {
            if (productID < 1 || amount < 0) 
            {
                return false;
            }

            Product p = null;
            foreach(var kv in Inventory)
            {
                if(kv.Key.ID == productID)
                {
                    p = kv.Key;
                    break;
                }
            }

            if (p == null)
            {
                return false;
            }

            Inventory[p] = amount;
            return true;
        }

        /// <summary>
        /// Gets the amount of a Product based on the given Product object.
        /// </summary>
        /// <param name="p"></param>
        /// <returns> int </returns>
        public int GetProductAmount(Product p)
        {
            if (p == null || !Inventory.ContainsKey(p)) 
            {
                return -1;
            }
            return Inventory[p];
        }

        /// <summary>
        /// Gets the amount of a Product based on the given Product ID.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns> int </returns>
        public int GetProductAmount(int productID)
        {
            if (productID < 1)
            {
                return -1;
            }

            Product p = null;
            foreach (var kv in Inventory)
            {
                if (kv.Key.ID == productID)
                {
                    p = kv.Key;
                    break;
                }
            }

            if(p == null)
            {
                return -1;
            }
            return Inventory[p];
        }

        /// <summary>
        /// Reduces the amount of stock for the given Product by the given amount.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="amount"></param>
        /// <returns> bool indicating success or failure </returns>
        public bool WithdrawProduct(Product p, int amount)
        {
            if (p == null || amount < 1 || amount > Inventory[p])
            {
                return false;
            }
            else
            {
                Inventory[p] -= amount;
                return true;
            }
        }

        /// <summary>
        /// Reduces the amount of stock for the Product matching the given Product ID by the given amount.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="amount"></param>
        /// <returns> bool indicating success or failure </returns>
        public bool WithdrawProduct(int productID, int amount)
        {
            if (productID >= 1 && amount >= 1)
            {
                Product p = null;
                foreach (var kv in Inventory)
                {
                    if (kv.Key.ID == productID)
                    {
                        p = kv.Key;
                        break;
                    }
                }
                if(p == null || !Inventory.ContainsKey(p) || amount > Inventory[p])
                {
                    return false;
                }
                Inventory[p] -= amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the given Product from the inventory entirely.
        /// </summary>
        /// <param name="p"></param>
        /// <returns> bool indicating success or failure </returns>
        public bool RemoveProduct(Product p)
        {
            if (p == null || !Inventory.ContainsKey(p))
            {
                return false;
            }
            return Inventory.Remove(p);
        }

        /// <summary>
        /// Removes the Product matching the given ID from the inventory entirely.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns> bool indicating success or failure </returns>
        public bool RemoveProduct(int productID)
        {
            Product p = null;
            foreach (var kv in Inventory)
            {
                if (kv.Key.ID == productID)
                {
                    p = kv.Key;
                    break;
                }
            }
            if (p == null)
            {
                return false;
            }
            return Inventory.Remove(p);
        }
    }
}