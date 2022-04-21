
namespace StoreApplication.UI.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string? ProductType { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
