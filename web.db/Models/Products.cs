namespace web.db.Models
{
    public class Product
    {
        public long? ProductID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; } = String.Empty;
    }
}