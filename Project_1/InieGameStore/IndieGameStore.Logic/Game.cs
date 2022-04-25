using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieGameStore.Logic
{
    public class Game
    {
        //Fields
        public int ProductID {get;set;}
        public string Name { get;set;}
        public int Price { get;set;}

       

        //Constructors
        public Game() { }
        public Game(int pid, string name, int price)
        {
            ProductID = pid;
            Name = name;
            Price = price;
        }

        

        //Methods
        public int GetProductID()
        { return ProductID; }
        public string GetName()
        { return Name; }
        public int GetPrice()
        { return Price; }

        public void SetName(string name)
        { this.Name = name; }
        public void SetPrice(int price)
        { this.Price = price; }
    }
}
