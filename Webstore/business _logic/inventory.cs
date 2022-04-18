namespace business__logic
{
    public class inventory

    {   public int storeid { get; set; }
        public int mashrooms { get; set; }
        public int pineapples { get; set; } 
        public int salalmi { get; set; }
        public int chicken { get; set; }    
        public int chessee { get; set; }
        public inventory(int storeid, int mashrooms, int pineapples, int salalmi, int chicken, int chessee)
        {
            this.storeid = storeid;
            this.mashrooms = mashrooms;
            this.pineapples = pineapples;
            this.salalmi = salalmi;
            this.chicken = chicken;
            this.chessee = chessee;
        }

        
    }
}