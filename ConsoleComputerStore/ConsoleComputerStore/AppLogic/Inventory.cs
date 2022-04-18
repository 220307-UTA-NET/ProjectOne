using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleComputerStore.AppLogic
{
    public class Inventory
    {
        int ID;
        string Computer_Make_Name;
        string Computer_Make_Type;
        string Computer_Make_OS;
        decimal Computer_Make_Price;

        // Constructors 

        public Inventory() { }

        public Inventory(string ComputerName, string ComputerType, string ComputerOS, decimal ComputerPrice)
        {
            this.Computer_Make_Name = ComputerName;
            this.Computer_Make_Type = ComputerType;
            this.Computer_Make_OS = ComputerOS;
            this.Computer_Make_Price = ComputerPrice;
        }

        // Methods

        //Getters
        public string GetComputerName() { return this.Computer_Make_Name; }
        public string GetComputerType() { return this.Computer_Make_Type; }
        public string GetComputerOS() { return this.Computer_Make_OS; }
        public decimal GetComputerPrice() { return this.Computer_Make_Price; }

    }
}
