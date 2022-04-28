
namespace StoreApplication.UI.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public ProductDTO(int ProductID, string ProductType, string ProductName, int Quantity, decimal Cost)
        {
            this.ProductID = ProductID;
            this.ProductType = ProductType;
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.Cost = Cost;

        }
        /*
        public ProductDTO(ProductDTO product) { 
            this.ProductID = product.ProductID;
            this.ProductType = product.ProductType;
            this.ProductName = product.ProductName; 
            this.Quantity = product.Quantity;   
            this.Cost = product.Cost;
        }
        */
        public void toString()
        {
            string str = "";
            str += this.ProductType.ToString() + "\t" + this.ProductName.ToString() + "\n";
            str += "\t\tunit price\t" + this.Cost.ToString() + "\n";
            str += "\t\tquantity\t" + this.Quantity.ToString() + "\n";
            str += "\t\tsubtotal\t" + (this.Quantity * this.Cost).ToString() + "\n";
        }
        
    }
}
