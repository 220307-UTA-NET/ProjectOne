using Microsoft.AspNetCore.Mvc;
using web.db.Models;

namespace web.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get() {
            return _repository.Products;
        }

        [HttpGet("{id}")]
        public Product Get(long id) {
            Product p = _repository.Products.FirstOrDefault(p => p.ProductID == id);
            if (p == null) {
                Response.StatusCode = 404;
            }
            return p;
        }

        [HttpPost]
        public void Post([FromBody] Product product) {
            if (product.ProductID != null)
            {
                Response.StatusCode = 400;
                Response.WriteAsync("Error 400: Bad Request, Product ID must be null when you want to create a new product.");
            } else 
            {
                _repository.CreateProduct(product);
            }
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Product product) {
            _repository.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void Delete(long id) {
            _repository.DeleteProduct(_repository.Products.FirstOrDefault(p => p.ProductID == id));
        }
    }
}
