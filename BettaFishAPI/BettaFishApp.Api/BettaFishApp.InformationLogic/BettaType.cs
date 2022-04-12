namespace BettaFishApp.InformationLogic
{
    public class BettaType
    {
        // Fields
        public int ID { get; set; }
        public string? tailType { get; set; }
        public string? description { get; set; }
        

        // Constructors
        public BettaType() { }

        public BettaType(int ID, string tailType, string description)
        {
            this.ID = ID;
            this.tailType = tailType;
            this.description = description;
           
        }

        // Methods
    }
}