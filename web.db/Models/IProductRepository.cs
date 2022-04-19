namespace web.db.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        void CreateProduct(Product product);
    }
}