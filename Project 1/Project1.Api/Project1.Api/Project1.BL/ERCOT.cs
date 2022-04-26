namespace Project1.BL
{
    public class ERCOT
    {
        public int ERCOT_ID { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public int Peak_MegaWatts { get; set; }
        public int Monthly_Total_Energy { get; set; }

        public ERCOT() { }

        public ERCOT(int ERCOT_ID, int Year, string Month, int Peak_MegaWatts, int Monthly_Total_Energy)
        {
            this.ERCOT_ID = ERCOT_ID;
            this.Year = Year;
            this.Month = Month;
            this.Peak_MegaWatts = Peak_MegaWatts;
            this.Monthly_Total_Energy = Monthly_Total_Energy;
        }
    }
}