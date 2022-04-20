namespace StreetStyleApp.BusinessLogic
{
    public class Clothes
    {
        // Fields
        public int ClothingID { get; set; }
        public string? ClothingItem { get; set; }
        public string? ClothingBrand { get; set; }

        // Constructors
        public Clothes() { }

        public Clothes(int ClothingID, string ClothingItem, string ClohtingBrand)
        {
            this.ClothingID = ClothingID;
            this.ClothingItem = ClothingItem;   
            this.ClothingBrand = ClohtingBrand;
        }

        // Methods
    }
}