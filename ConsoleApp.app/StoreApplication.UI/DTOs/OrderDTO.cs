
namespace StoreApplication.UI.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
    }
}
