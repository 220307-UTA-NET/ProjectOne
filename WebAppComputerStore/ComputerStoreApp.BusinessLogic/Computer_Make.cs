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

        // Constructors
        public Computer_Make() { }

        public Computer_Make(int ID, string Name, decimal Price, int Type, int OS)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Type = Type;
            this.OS = OS;
        }
    }
}