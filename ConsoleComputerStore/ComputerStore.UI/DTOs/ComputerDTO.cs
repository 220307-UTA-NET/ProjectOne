namespace ComputerStore.UI.DTOs
{
    public class ComputerDTO
    {
        // Fields
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Type { get; set; }
        public int OS { get; set; }
        public string? Type_Name { get; set; }
        public string? OS_Name { get; set; }
        

        // Constructors 
        public ComputerDTO()
        {

        }
        public ComputerDTO(string CM_Name, decimal CM_Price, string Type_Name, string OS_Name)
        {
            this.Name = CM_Name;
            this.Price = CM_Price;
            this.Type_Name = Type_Name;
            this.OS_Name = OS_Name;
        }
    }
}
