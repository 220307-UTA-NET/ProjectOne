namespace ComputerStoreApp.BusinessLogic
{
    public class Computer_Make
    {
        // Fields
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Type { get; set; }
        public int OS { get; set; }
        public string Type_Name { get; set; }
        public string OS_Name { get; set; }

        // Constructors
        public Computer_Make() { }

        public Computer_Make(string OS_Name, string Type_Name, Decimal Price, string Name)
        {
            this.OS_Name = OS_Name;
            this.Type_Name = Type_Name;
            this.Price = Price;
            this.Name = Name;

        }

        public Computer_Make(int ID, string Name, decimal Price, int Type, int OS, string Type_Name, string OS_Name)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Type = Type;
            this.OS = OS;
            this.Type_Name = Type_Name;
            this.OS_Name = OS_Name;
        }
    }
}