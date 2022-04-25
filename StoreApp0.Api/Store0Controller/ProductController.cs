using StoreApp0.BusinessLogic;
using StoreApp0.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using StoreApp0.Api.DTO;

namespace StoreApp0.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
      
        private readonly IRepository _repository;
        private readonly ILogger<ProductController> _logger;

      
        public ProductController(IRepository repository, ILogger<ProductController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromBody] AddProductDTO product)
        {

            var id = await _repository.CreateProduct(product.ProductName, product.ProductCatagory);
            if (id == 0)
            {
                return BadRequest("Product can not be created");
            }
            return Ok(id);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById([FromRoute] int id)
        {
            ProductDTO productDTO;
            try
            {
                var product = await _repository.GetProductById(id);
                if (product == null)
                    return NotFound($"CProduct with Id={id} doesn't exists");
                productDTO = new ProductDTO()
                {
                    Id = product.ProductId,
                    ProductName = product.ProductName,
                    ProductCatagory= product.productCatagory
                };

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting devices named {id}.", id);
                return StatusCode(500);
            }
            return Ok(productDTO);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsAsyc()
        {
            List<ProductDTO> productDTOs = null;
            try
            {
                var products = await _repository.GetAllProducts();
                if (!products.Any())
                    return NotFound("No Product exist");
                productDTOs = new List<ProductDTO>();
                foreach (var product in products)
                    productDTOs.Add(new ProductDTO()
                    {
                        Id = product.ProductId,
                        ProductName = product.ProductName,
                        ProductCatagory = product.productCatagory
                    });
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting devices.");
                return StatusCode(500);
            }
            return Ok(productDTOs);
        }
    }
}
