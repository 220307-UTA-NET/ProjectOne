namespace BettaFishApp.InformationLogic
{
    public class BettaType
    {
        // Fields
        public int tail_ID { get; set; }
        public string? tailType { get; set; }
        public string? description { get; set; }


        // Constructors
        public BettaType() { }

        public BettaType(int tail_ID, string tailType, string description)
        {
            this.tail_ID = tail_ID;
            this.tailType = tailType;
            this.description = description;
          

        }

        // Methods
    }
}