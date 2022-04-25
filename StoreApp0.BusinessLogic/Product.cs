

namespace StoreApp0.BusinessLogic
{
	public class Product
	{
		public int ProductId { get; set; }
		public String? ProductName { get; set; }
		public String? productCatagory { get; set; }

		public Product(int id, String productName, String productCatagory)
		{
			this.ProductId = id;
			this.ProductName = productName;
			this.productCatagory = productCatagory;
		}

		public Product()
		{ }

	}
}

